#define _WIN32_WINNT 0x0501
#include <platform.hpp>

extern "C"
{
#include <math.h>
#include <stdio.h>
#include <string.h>
#include <stdint.h>
#include <stdlib.h>
#include <unistd.h>
#include <setjmp.h>
#include <sys/stat.h>
#include <sys/types.h>
#if __APPLE__
#include <malloc/malloc.h>
#else
#include <malloc.h>
#endif
#include <errno.h>
#include <stdarg.h>
#include <fcntl.h>
#ifndef WIN32
#include <arpa/inet.h>
#include <netdb.h>
typedef int SOCKET;
#endif
#include <poll.h>

#include "inet_pton.h"
}

#ifdef WIN32
#include <winsock2.h>
#include <ws2tcpip.h>
//#include <mstcpip.h>
typedef int socklen_t;
//#define errno WSAGetLastError()

#include <tlhelp32.h>
#include <dwmapi.h>
#endif


#include <theora/theoraenc.h>
#include <theora/theora.h>

#include <exception>

using ::abs;
using namespace std;

//#define errfail(wut) { printf(#wut " fail (line #%03i): (%i) %s\n", __LINE__, errno, strerror(errno)); goto killswitch; }
#ifdef WIN32
#define wsafail(func)\
{\
    wchar_t *s = NULL;\
    FormatMessageW\
    (\
        FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,\
        NULL, WSAGetLastError(), MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPWSTR)&s, 0, NULL\
    );\
    printf(#func " fail (line #%03i): (%i) %S\n", __LINE__, WSAGetLastError(), s);\
    LocalFree(s);\
    goto killswitch;\
}

#define winfail(func)\
{\
    wchar_t *s = NULL;\
    FormatMessageW\
    (\
        FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,\
        NULL, GetLastError(), MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPWSTR)&s, 0, NULL\
    );\
    printf(#func " fail (line #%03i): (%i) %S\n", __LINE__, GetLastError(), s);\
    LocalFree(s);\
    goto killswitch;\
}

#else
#define wsafail(func) { printf(#func " fail (line #%03i): (%i) %s\n", __LINE__, errno, strerror(errno)); goto killswitch; }
#endif

#define errfail(func) { printf(#func " fail (line #%03i): (%i) %s\n", __LINE__, errno, strerror(errno)); goto killswitch; }


#ifdef WIN32
HWND wnd = nullptr;
HWND hrc = nullptr;

struct handle_data
{
    unsigned long process_id;
    unsigned int refc;
    int flags;
    char* title;
    HWND best_handle;
};

BOOL is_main_window(HWND handle)
{   
    return GetWindow(handle, GW_OWNER) == (HWND)0 && IsWindowVisible(handle);
}

BOOL CALLBACK enum_windows_callback(HWND handle, LPARAM lParam)
{
    struct handle_data* data = (struct handle_data*)lParam;
    unsigned long process_id = 0;
    GetWindowThreadProcessId(handle, &process_id);
    if (data->process_id != process_id) return TRUE;
    if ((data->flags & 1) && !is_main_window(handle)) return TRUE;
    
    if(data->title)
    {
        char buf[0x80];
        GetWindowText(handle, buf, 0x80);
        printf("- - Title: '%s'\n", buf);
        if(strstr(buf, data->title) != buf) return TRUE;
    }
    
    if(data->refc--) return TRUE;
    
    data->best_handle = handle;
    return FALSE;   
}

HWND find_window(unsigned long process_id, unsigned int nth, int flags, char* title)
{
    struct handle_data data;
    data.process_id = process_id;
    data.best_handle = 0;
    data.refc = nth;
    data.flags = flags;
    data.title = title;
    EnumWindows(enum_windows_callback, (LPARAM)&data);
    return data.best_handle;
}

HWND getwin(char* procname, unsigned int nth, int flags, char* title)
{
    printf("Finding process: PN=%s T='%s' N=%i F=%i\n", procname ? procname : "<nullptr>", title ? title : "<nullptr>", nth, flags);
    
    PROCESSENTRY32 pe;
    HANDLE snapshot;
    HWND wnd;
    
    pe.dwSize = sizeof(pe);
    
    snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    
    wnd = 0;

    if(Process32First(snapshot, &pe))
    {
        while(Process32Next(snapshot, &pe))
        {
            if(!procname || strstr(pe.szExeFile, procname) == pe.szExeFile)
            {
                printf("- %04i: %s\n", pe.th32ProcessID, pe.szExeFile);
                wnd = find_window(pe.th32ProcessID, nth, flags, title);
                
                if(wnd) break;
            }
        }
    }
    CloseHandle(snapshot);
    
    return wnd;
}
#endif


int pollsock(SOCKET sock, int wat, int timeout = 0)
{
#ifdef WIN32
    fd_set fd;
    fd.fd_count = 1;
    fd.fd_array[0] = sock;
    TIMEVAL t;
    t.tv_sec = timeout / 1000;
    t.tv_usec = (timeout % 1000) * 1e6;
    int ret = select(1, (wat & POLLIN) ? &fd : nullptr , nullptr, (wat & POLLERR) ? &fd : nullptr, &t);
    if(ret == SOCKET_ERROR) return (wat & POLLERR) == POLLERR;
    return ret ? wat : 0;
#else
    struct pollfd pd;
    pd.fd = sock;
    pd.events = wat;
    
    if(poll(&pd, 1, timeout) == 1)
        return pd.revents & wat;
#endif
    return 0;
}

class bufsoc
{
public:
    
    struct packet
    {
        u32 packetid : 8;
        u32 size : 24;
        u8 data[0];
    };
    
    SOCKET sock;
    u8* buf;
    int bufsize;
    int recvsize;
    
    bufsoc(SOCKET sock, int bufsize = 1024 * 1024)
    {
        this->bufsize = bufsize;
        buf = new u8[bufsize];
        
        recvsize = 0;
        this->sock = sock;
    }
    
    ~bufsoc()
    {
        delete[] buf;
    }
    
    int avail()
    {
        return pollsock(sock, POLLIN) == POLLIN;
    }
    
    int readbuf(int flags = 0)
    {
        u32 hdr = 0;
        int ret = recv(sock, (char*)&hdr, 4, flags);
        if(ret < 0) return -errno;
        if(ret < 4) return -1;
        *(u32*)buf = hdr;
        
        packet* p = pack();
        
        int mustwri = p->size;
        int offs = 4;
        while(mustwri)
        {
            ret = recv(sock, (char*)(buf + offs), mustwri, flags);
            if(ret <= 0) return -errno;
            mustwri -= ret;
            offs += ret;
        }
        
        recvsize = offs;
        return offs;
    }
    
    int wribuf(int flags = 0)
    {
        int mustwri = pack()->size + 4;
        int offs = 0;
        int ret = 0;
        while(mustwri)
        {
            ret = send(sock, (char*)(buf + offs) , mustwri, flags);
            if(ret < 0) return -errno;
            mustwri -= ret;
            offs += ret;
        }
        
        return offs;
    }
    
    packet* pack()
    {
        return (packet*)buf;
    }
    
    int errformat(char* c, ...)
    {
        int len = 0;
        
        packet* p = pack();
        
        va_list args;
        va_start(args, c);
        len = vsnprintf((char*)(p->data + 1), 256, c, args);
        va_end(args);
        
        if(len < 0)
        {
            puts("wat");
            return -1;
        }
        
        printf("Packet error %i: %s\n", p->packetid, (char*)(p->data + 1));
        
        p->data[0] = p->packetid;
        p->packetid = 1;
        p->size = (len * sizeof(char)) + 2;
        
        return wribuf();
    }
};


int port = 6957;
SOCKET sock = 0;
struct sockaddr_in sao;
socklen_t sizeof_sao = sizeof(sao);
bufsoc* soc = 0;
bufsoc::packet* p = 0;
int ret = 0;

extern "C" int _kbhit();

ogg_page ogb;
ogg_stream_state ogv;
ogg_packet ogp;

th_info vidinfo;
th_comment vidcomm;
th_ycbcr_buffer vidbuf;
th_enc_ctx* enc = 0;

u8 imgbuf[240 * 320 * 4];
u8 yuuy[256 * 320];
u8 uuuy[256 * 320];
u8 vuuy[256 * 320];


void rgb3_yuv(u8* y, u8* u, u8* v, u8* src)
{
    for(size_t line = 0; line != 320; line++)
    {
        if(!(line & 1))
        {
            size_t x = 240;
            
            while(1)
            {
                x--;
                
                size_t o = ((x * 320) + line) * 3;
                uint8_t r = src[o];
                uint8_t g = src[o + 1];
                uint8_t b = src[o + 2];

                *(y++) = ((66*r + 129*g + 25*b) >> 8) + 16;

                *(u++) = ((-38*r + -74*g + 112*b) >> 8) + 128;
                *(v++) = ((112*r + -94*g + -18*b) >> 8) + 128;
                
                
                o -= 320 * 3;
                x--;
                
                r = src[o];
                g = src[o + 1];
                b = src[o + 2];

                *(y++) = ((66*r + 129*g + 25*b) >> 8) + 16;
                
                if(!x) break;
            }
            
            y += 16;
            u += 8;
            v += 8;
        }
        else
        {
            size_t x = 239;
            size_t o = ((x * 320) + line) * 3;
            
            do
            {
                uint8_t r = src[o];
                uint8_t g = src[o + 1];
                uint8_t b = src[o + 2];
                
                o -= 320 * 3;

                *(y++) = ((66*r + 129*g + 25*b) >> 8) + 16;
            }
            while(x--);
            
            y += 16;
        }
    }
}

void rgb4_yuv(u8* y, u8* u, u8* v, u8* src)
{
    for(size_t line = 0; line != 320; line++)
    {
        if(!(line & 1))
        {
            size_t x = 240;
            
            while(1)
            {
                x--;
                
                size_t o = ((x * 320) + line) * 4;
                uint8_t r = src[o + 2];
                uint8_t g = src[o + 1];
                uint8_t b = src[o + 0];

                *(y++) = ((66*r + 129*g + 25*b) >> 8);

                *(u++) = ((-38*r + -74*g + 112*b) >> 8) + 128;
                *(v++) = ((112*r + -94*g + -18*b) >> 8) + 128;
                
                
                o -= 320 * 4;
                x--;
                
                r = src[o];
                g = src[o + 1];
                b = src[o + 2];

                *(y++) = ((66*r + 129*g + 25*b) >> 8);
                
                if(!x) break;
            }
            
            y += 16;
            u += 8;
            v += 8;
        }
        else
        {
            size_t x = 239;
            size_t o = ((x * 320) + line) * 4;
            
            do
            {
                uint8_t r = src[o];
                uint8_t g = src[o + 1];
                uint8_t b = src[o + 2];
                
                o -= 320 * 4;

                *(y++) = ((66*r + 129*g + 25*b) >> 8);
            }
            while(x--);
            
            y += 16;
        }
    }
}


int main(int argc, char** argv)
{
    if(argc < 2)
    {
        printusage:
        
        printf("%s <FILE | -> <IP Address>\n%s + <IP Address> [exe]", argv[0], argv[0]);
        return 1;
    }
    
    FILE* f = fopen(argv[1], "rb");
    if(f <= 0)
    {
        if(argv[1][0] != '\0' && argv[1][1] == '\0')
        {
            if(argv[1][0] == '-')
            {
#ifdef WIN32
                _setmode(_fileno(stdin), _O_BINARY);
#endif
                puts("using stdin");
                f = stdin;
            }
            else if(argv[1][0] == '+')
            {
                puts("screen capture");
                f = nullptr;
            }
            else
            {
                puts("No valid input found");
                return 1;
            }
        }
        else
        {
            puts("Invalid filename");
        }
    }
    
    if(!f)
    {
#ifdef WIN32
        if(argc > 3)
        {
            puts("Finding window");
            
            int nth = 0;
            int flag = 0;
            
            char* p = argv[3];
            char c = *p;
            if(c >= '0' && c <= '9') //window index
            {
                nth = c - '0';
                c = *(++p);
            }
            else if(c == '*') { flag |= 1; c = *(++p); } //main window
            
            if(c == '+') { flag |= 2; c = *(++p); }      //fullscreen crop
            
            if     (c == ':') wnd = getwin(nullptr, nth, flag, p + 1); //by title
            else if(c == '!') wnd = getwin(p + 1, nth, flag, nullptr); //by exe
            else              wnd = getwin(p + 1, nth, flag, p + 1);   //both
            
            printf("Result HWND: %08X\n", wnd);
            puts("press ENTER to continue");
            getchar();
            
            if(!wnd)
            {
                printf("No matching window for pattern '%s'\n", argv[3]);
                //return 1;
            }
            
            if(flag & 2)
            {
                hrc = wnd;
                wnd = 0;
            }
        }
#endif
    }
    
    if(!inet_pton4(argv[2], (unsigned char*)&sao.sin_addr))
    {
        printf("Malformatted IP address: '%s'\n", argv[2]);
        return 1;
    }
    
#ifdef WIN32
    
    static int(WINAPI*NtQuerySystemTime)(u64* timeptr) = (int(WINAPI*)(u64*))GetProcAddress(GetModuleHandle("ntdll"), "NtQuerySystemTime");
    
    u64 systime = 0;
    u64 timediff = 0;
    NtQuerySystemTime(&systime);
    int framecnt = 0;
    int pktcnt = 0;
    int bytes = 0;
    
    FILE* fo = fopen("FileStream_debug.ogg", "wb");
    
    WSADATA socHandle;
    
    ret = WSAStartup(MAKEWORD(2,2), &socHandle);
    if(ret)
    {
        printf("WSAStartup failed: %i\n", ret);
        return 1;
    }
    
    BITMAP bmp;
    
    //TODO find window
    
    HDC srcdc = GetDC(wnd);
    HDC memdc = CreateCompatibleDC(srcdc);
    HBITMAP img = CreateCompatibleBitmap(srcdc, 320, 240);
    SelectObject(memdc, img);
    //SetStretchBltMode(memdc,HALFTONE); SetBrushOrgEx(memdc, 0, 0, NULL);
    SetStretchBltMode(memdc,COLORONCOLOR);
    
    
#endif
    
    sao.sin_family = AF_INET;
    sao.sin_port = htons(port);
    
    sock = socket(AF_INET, SOCK_STREAM, IPPROTO_IP);
    if(sock <= 0) wsafail(socket);
    soc = new bufsoc(sock, 0x200000);
    p = soc->pack();
    
    ret = connect(sock, (sockaddr*)&sao, sizeof_sao);
    if(ret < 0) wsafail(connect); 
    
    puts("Connected");
    
    if(!f)
    {
        puts("Initing video encoder");
        
        long dummy = 8 * 1024 * 180;
        
        ogg_stream_init(&ogv, 0x6956F00F);
        
        th_info_init(&vidinfo);
        vidinfo.frame_width = 240;
        vidinfo.frame_height = 320;
        vidinfo.pic_width = 240;
        vidinfo.pic_height = 320;
        vidinfo.pixel_fmt = TH_PF_420;
        vidinfo.pic_x = 0;
        vidinfo.pic_y = 0;
        vidinfo.target_bitrate = dummy;
        vidinfo.quality = 0;
        vidinfo.fps_numerator = 60;
        vidinfo.fps_denominator = 1;
        vidinfo.aspect_numerator = 1;
        vidinfo.aspect_denominator = 1;
        
        puts("decoder_alloc");
        enc = th_encode_alloc(&vidinfo);
        if(!enc) errfail(th_encode_alloc);
        th_info_clear(&vidinfo);
        
#define thfail(wat) if((thr = th_encode_ctl(enc, wat, &dummy, sizeof(dummy)))) printf("th_encode_ctl(%s) fail: %i\n", #wat, thr);
        
        int thr = 0;
        
        thfail(TH_ENCCTL_SET_BITRATE);
        //dummy >>= 8;
        //thfail(TH_ENCCTL_SET_RATE_BUFFER);
        //dummy = 2;
        //thfail(TH_ENCCTL_SET_SPLEVEL);
        dummy = TH_RATECTL_DROP_FRAMES;
        thfail(TH_ENCCTL_SET_RATE_FLAGS);
        
#undef thfail
        
        th_comment_init(&vidcomm);
        vidcomm.vendor = "FileStreamer/PaintController by Sono v0.0_dev2";
        
        while(th_encode_flushheader(enc, &vidcomm, &ogp) > 0)
            ogg_stream_packetin(&ogv, &ogp);
        
        while(ogg_stream_pageout(&ogv, &ogb) > 0 || ogg_stream_flush(&ogv, &ogb) > 0)
        {
            printf("Writing header packet: 0%08X 0x%08X\n", ogb.header_len, ogb.body_len);
            memcpy(&p->data[0], ogb.header, ogb.header_len);
            memcpy(&p->data[ogb.header_len], ogb.body, ogb.body_len);
            p->size = ogb.header_len + ogb.body_len;
            p->packetid = 2;
            if(soc->wribuf() < p->size) wsafail(soc->wribuf);
            fwrite(ogb.header, 1, ogb.header_len, fo);
            fwrite(ogb.body, 1, ogb.body_len, fo);
        }
        
        //puts("press ENTER to continue");
        //getchar();
    }
    
    while(true)
    {
        if(!soc->avail()) goto nocoffei;
        
        ret = soc->readbuf();
        if(ret <= 0) wsafail(soc->readbuf);
        
        switch(p->packetid)
        {
            case 0xFF:
            {
                printf("DebugMSG (0x%X):", p->size);
                int i = 0;
                while(i < p->size)
                {
                    printf(" %08X", *(u32*)&p->data[i]);
                    i += 4;
                }
                putchar('\n');
                
                break;
            }
            
            default:
                printf("Unknown packet: %i\n", p->packetid);
                break;
        }
        
        
        nocoffei:
        
        p->packetid = 2;
        
        if(f)
        {
            p->size = fread(&p->data[0], 1, 0x8000, f);
            if(p->size <= 0)
            {
                puts("EOF reached");
                //getchar();
                break;
            }
            
            if(soc->wribuf() < p->size) wsafail(soc->wribuf);
        }
        else
        {
            RECT rekt;
            if(hrc)
            {
                GetClientRect(hrc, &rekt);
                ClientToScreen(hrc, (POINT*)&rekt.left);
                ClientToScreen(hrc, (POINT*)&rekt.right);
            }
            else if(wnd) GetClientRect(wnd, &rekt);
            else
            {
                rekt.left = 0;
                rekt.right = GetSystemMetrics(SM_CXSCREEN);
                rekt.top = 0;
                rekt.bottom = GetSystemMetrics(SM_CYSCREEN);
            }
            
            //if
            //(!
                StretchBlt(memdc, 0, 0, 320, 240, srcdc, rekt.left, rekt.top, rekt.right - rekt.left, rekt.bottom - rekt.top, SRCCOPY)
            /*)
            {
                winfail(StretchBlt);
            }*/;
            
            int imgs = GetBitmapBits(img, 240 * 320 * 4, imgbuf);
            imgs /= 240 * 320;
            
            /*if(imgs == 3)
            {
                rgb3_yuv(yuuy, uuuy, vuuy, imgbuf);
            }
            else */if(imgs == 4)
            {
                rgb4_yuv(yuuy, uuuy, vuuy, imgbuf);
            }
            else
            {
                printf("Invalid Bpp: %i\n", imgs);
                winfail(GetBitmapBits);
            }
            
            vidbuf[0].width = 240;
            vidbuf[1].width = 120;
            vidbuf[2].width = 120;
            vidbuf[0].height = 320;
            vidbuf[1].height = 160;
            vidbuf[2].height = 160;
            vidbuf[0].stride = 256;
            vidbuf[1].stride = 128;
            vidbuf[2].stride = 128;
            vidbuf[0].data = yuuy;
            vidbuf[1].data = uuuy;
            vidbuf[2].data = vuuy;
            
            if(th_encode_ycbcr_in(enc, vidbuf)) errfail(th_encode_ycbcr_in);
            framecnt++;
            
            while(th_encode_packetout(enc, 0, &ogp) > 0)
                ogg_stream_packetin(&ogv, &ogp);
            
            //if(ogv.body_fill >= 0x400)
            if(ogg_stream_flush(&ogv, &ogb) > 0 && ogb.body_len)
            {
                //printf("Writing data page: 0%08X\n", ogb.body_len);
                memcpy(&p->data[0], ogb.header, ogb.header_len);
                memcpy(&p->data[ogb.header_len], ogb.body, ogb.body_len);
                p->size = ogb.header_len + ogb.body_len;
                p->packetid = 2;
                bytes += p->size;
                fwrite(ogb.header, 1, ogb.header_len, fo);
                fwrite(ogb.body, 1, ogb.body_len, fo);
                if(soc->wribuf() < p->size) wsafail(soc->wribuf);
                pktcnt++;
            }
            
            if(_kbhit())
            {
                if(fo)
                {
                    while(th_encode_packetout(enc, 1, &ogp) > 0)
                        ogg_stream_packetin(&ogv, &ogp);
                    
                    if(ogg_stream_flush(&ogv, &ogb) > 0)
                    {
                        fwrite(ogb.header, 1, ogb.header_len, fo);
                        fwrite(ogb.body, 1, ogb.body_len, fo);
                        fflush(fo);
                    }
                }
                break;
            }
            
            NtQuerySystemTime(&timediff);
            timediff -= systime;
            if(timediff >= 1e7)
            {
                systime += 1e7;
                printf("fps=%3i, %8.2fKB/s, pktcnt=%3i\n", framecnt, bytes / 1024.0F, pktcnt);
                framecnt = 0;
                bytes = 0;
                pktcnt = 0;
            }
        }
        
        /*if(f != stdin)
        {
            ret = 0x2400000;
            while(--ret);
        }*/
    }
    
    killswitch:
    
    if(f > 0 && f != stdin) fclose(f);
    
    if(fo) fclose(fo);
    
    if(soc) delete soc;
    
#ifdef WIN32
    WSACleanup();
#endif
    
    return 0;
}
