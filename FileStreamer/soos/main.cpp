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
#define errno WSAGetLastError()
#endif

#include <exception>

using ::abs;
using namespace std;

//#define errfail(wut) { printf(#wut " fail (line #%03i): (%i) %s\n", __LINE__, errno, strerror(errno)); goto killswitch; }
#ifdef WIN32
#define errfail(func)\
{\
    wchar_t *s = NULL;\
    FormatMessageW\
    (\
        FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,\
        NULL, errno, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPWSTR)&s, 0, NULL\
    );\
    printf(#func " fail (line #%03i): (%i) %S\n", __LINE__, errno, s);\
    LocalFree(s);\
    goto killswitch;\
}
#else
#define errfail(func) { printf(#func " fail (line #%03i): (%i) %s\n", __LINE__, errno, strerror(errno)); goto killswitch; }
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




int main(int argc, char** argv)
{
    if(argc < 2)
    {
        printusage:
        
        printf("%s < - | + >\n%s <FILE> <IP Address>\n", argv[0], argv[0]);
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
        }
        else
            errfail(fopen);
    }
    
    if(argc <3) goto printusage;
    
    if(!inet_pton4(argv[2], (unsigned char*)&sao.sin_addr))
    {
        printf("Malformatted IP address: '%s'\n", argv[2]);
        return 1;
    }
    
#ifdef WIN32
    
    WSADATA socHandle;
    
    ret = WSAStartup(MAKEWORD(2,2), &socHandle);
    if(ret)
    {
        printf("WSAStartup failed: %i\n", ret);
        return 1;
    }
    
#endif
    
    sao.sin_family = AF_INET;
    sao.sin_port = htons(port);
    
    sock = socket(AF_INET, SOCK_STREAM, IPPROTO_IP);
    if(sock <= 0) errfail(socket);
    soc = new bufsoc(sock, 0x200000);
    p = soc->pack();
    
    ret = connect(sock, (sockaddr*)&sao, sizeof_sao);
    if(ret < 0) errfail(connect); 
    
    puts("Connected");
    
    
    
    while(true)
    {
        if(!soc->avail()) goto nocoffei;
        
        ret = soc->readbuf();
        if(ret <= 0) errfail(soc->readbuf);
        
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
        p->size = fread(&p->data[0], 1, 0x8000, f);
        if(p->size <= 0)
        {
            puts("EOF reached");
            //getchar();
            break;
        }
        
        if(soc->wribuf() < p->size) errfail(soc->wribuf);
        
        /*if(f != stdin)
        {
            ret = 0x2400000;
            while(--ret);
        }*/
    }
    
    killswitch:
    
    if(f > 0 && f != stdin) fclose(f);
    
    if(soc) delete soc;
    
#ifdef WIN32
    WSACleanup();
#endif
    
    return 0;
}
