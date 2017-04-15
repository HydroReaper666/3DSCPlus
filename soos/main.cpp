#include <3ds.h>

extern "C"
{
#include <stdio.h>
#include <string.h>
#include <stdint.h>
#include <stdlib.h>
#include <unistd.h>
#include <setjmp.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <malloc.h>
#include <errno.h>
#include <stdarg.h>
#include <fcntl.h>
#include <poll.h>
#include <arpa/inet.h>
    
#include "net.h"
#include "inet_pton.h"
}

static jmp_buf __exc;
static int  __excno;


#include <exception>

#include <theora/theoradec.h>
#include <theora/theora.h>

#define hangmacro()\
({\
    puts("Press a key to exit...");\
    while(aptMainLoop())\
    {\
        hidScanInput();\
        if(hidKeysDown())\
        {\
            goto killswitch;\
        }\
        gspWaitForVBlank();\
    }\
})

static int haznet = 0;

int wait4wifi()
{
    haznet = 0;
    u32 wifi = 0;
    hidScanInput();
    if(hidKeysHeld() & KEY_SELECT) return 0;
    if(ACU_GetWifiStatus(&wifi) >= 0 && wifi) haznet = 1;
    return haznet;
}

void screenoff()
{
    gspLcdInit();\
    GSPLCD_PowerOffBacklight(GSPLCD_SCREEN_BOTH);\
    gspLcdExit();
}

void screenon()
{
    gspLcdInit();\
    GSPLCD_PowerOnBacklight(GSPLCD_SCREEN_BOTH);\
    gspLcdExit();
}


int pollsock(int sock, int wat, int timeout = 0)
{
    struct pollfd pd;
    pd.fd = sock;
    pd.events = wat;
    
    if(poll(&pd, 1, timeout) == 1)
        return pd.revents & wat;
    return 0;
}

void _ded()
{
    gfxSetScreenFormat(GFX_TOP, GSP_RGB565_OES);
    gfxSetDoubleBuffering(GFX_TOP, false);
    gfxSwapBuffers();
    gfxSwapBuffers();
    gfxFlushBuffers();
    
    puts("\e[0m\n\n- The application has crashed\n\n");
    
    try
    {
        throw;
    }
    catch(std::exception &e)
    {
        printf("std::exception: %s\n", e.what());
    }
    catch(Result res)
    {
        printf("Result: %08X\n", res);
        //NNERR(res);
    }
    catch(int e)
    {
        printf("(int) %i\n", e);
    }
    catch(...)
    {
        puts("<unknown exception>");
    }
    
    puts("\n");
    
    hangmacro();
    
    killswitch:
    longjmp(__exc, 1);
}

class bufsoc
{
public:
    
    typedef struct
    {
        u32 packetid : 8;
        u32 size : 24;
        u8 data[0];
    } packet;
    
    int sock;
    u8* buf;
    int bufsize;
    int recvsize;
    
    bufsoc(int sock, int bufsize = 1024 * 1024)
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
        int ret = recv(sock, &hdr, 4, flags);
        if(ret < 0) return -errno;
        if(ret < 4) return -1;
        *(u32*)buf = hdr;
        
        packet* p = pack();
        
        int mustwri = p->size;
        int offs = 4;
        while(mustwri)
        {
            ret = recv(sock, buf + offs , mustwri, flags);
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
            ret = send(sock, buf + offs , mustwri, flags);
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
        char* wat = nullptr;
        int len = 0;
        
        va_list args;
        va_start(args, c);
        len = vasprintf(&wat, c, args);
        va_end(args);
        
        if(len < 0)
        {
            puts("out of memory");
            return -1;
        }
        
        packet* p = pack();
        
        printf("Packet error %i: %s\n", p->packetid, wat);
        
        p->data[0] = p->packetid;
        p->packetid = 1;
        p->size = len + 2;
        strcpy((char*)(p->data + 1), wat);
        delete wat;
        
        return wribuf();
    }
};

ogg_sync_state ogs;
ogg_page ogb;
ogg_stream_state ogv;
ogg_packet ogp;

int nohdr = 1;
int th_hdr = 0;
int starving = 0;

int y2y, y2u;
Y2RU_ConversionParams yparam;

th_info vidinfo;
th_comment vidcomm;
th_setup_info* vidsetup = 0;
th_dec_ctx* vctx = 0;

Handle yrhand = 0;

int main()
{
  // =====[PROGINIT]=====
  
  gfxInit(GSP_BGR8_OES, GSP_BGR8_OES, false);
  
  gfxSetDoubleBuffering(GFX_TOP, false);
  gfxSetDoubleBuffering(GFX_BOTTOM, false);
  
  acInit();
  y2rInit();
  
  inbuf = new struct packet;
  outbuf = new struct packet;
  
  // =====[VARS]=====
  
  int ret = 0;
  int cy = 0;
  u32 kDown;
  u32 kHeld;
  u32 kUp;
  u8* fbTopLeft;
  u8* fbTopRight;
  u8* fbBottom;
  PrintConsole console;
  u32 timer = 0;
  u32 altkey = 0;
  const u16 port = 6956;
  int connectd = 0;
  int altmode = 0;
  
  int socks = 0;
  bufsoc* soc = nullptr;
  struct sockaddr_in sais;
  socklen_t sizeof_sais = sizeof(sais);
  
  // =====[PREINIT]=====
  
  osSetSpeedupEnable(1);
  
  if((__excno = setjmp(__exc))) goto killswitch;
  
#ifdef _3DS
  std::set_unexpected(_ded);
  std::set_terminate(_ded);
#endif
  
  consoleInit(GFX_TOP, &console);
  consoleSelect(&console);
  
  fbTopLeft = gfxGetFramebuffer(GFX_TOP, GFX_LEFT, NULL, NULL);
  fbTopRight = gfxGetFramebuffer(GFX_TOP, GFX_RIGHT, NULL, NULL);
  fbBottom = gfxGetFramebuffer(GFX_BOTTOM, GFX_LEFT, NULL, NULL);
  
  ret = socInit((u32*)memalign(0x1000, 0x100000), 0x100000);
  if(ret < 0)
  {
      printf("socInit %08X\n", ret);
      hangmacro();
  }
  
  ogg_sync_init(&ogs);
  
  netreset:
  
  //consoleClear();
  
  puts("3DSControllerPlus v0.0_dev1\n");
  
  if(haznet && errno == EINVAL)
  {
      errno = 0;
      puts("Waiting for wifi to reset");
      while(wait4wifi()) gspWaitForVBlank();
  }
  
  if(wait4wifi())
  {
      puts("preparesock...");
      ret = preparesock(port);
      if(ret)
      {
          printf("preparesock: (%i) %s\n", ret, strerror(ret));
          hangmacro();
      }
      
      puts("socket...");
      cy = socket(AF_INET, SOCK_STREAM, IPPROTO_IP);
      if(cy <= 0)
      {
          printf("socket error: (%i) %s\n", errno, strerror(errno));
          hangmacro();
      }
      
      socks = cy;
      
      struct sockaddr_in saos;
      saos.sin_family = AF_INET;
      saos.sin_addr.s_addr = gethostid();
      saos.sin_port = htons(port + 1);
      
      if(bind(socks, (struct sockaddr*)&saos, sizeof(saos)) < 0)
      {
          printf("bind error: (%i) %s\n", errno, strerror(errno));
          hangmacro();
      }
      
      //fcntl(sock, F_SETFL, fcntl(sock, F_GETFL, 0) | O_NONBLOCK);
      
      if(listen(socks, 1) < 0)
      {
          printf("listen error: (%i) %s\n", errno, strerror(errno));
          hangmacro();
      }
  }
  
  
  ret = irrstInit();
  if(ret < 0)
  {
      printf("Failed to init irrst: %08X\n", ret);
  }
  
  //consoleClear();
  
  reloop:
  
  if(vidsetup) { th_setup_free(vidsetup); vidsetup = 0; }
  if(vctx) { th_decode_free(vctx); vctx = 0; }
  
  if(yrhand) { svcCloseHandle(yrhand); yrhand = 0; }
  
  if(!nohdr)
  {
      ogg_sync_clear(&ogs);
      ogg_stream_clear(&ogv);
      
      th_hdr = 0;
      nohdr = 1;
  }
  
  wait4wifi();
  
  if(haznet)
  do
  {
      char buf[256];
      gethostname(buf, sizeof(buf));
      printf("Listening on %s:%i (%i for video)\n", buf, port, port + 1);
  }
  while(0);
  else puts("\nWaiting for wifi...");
  
  // =====[RUN]=====
  
  while (aptMainLoop())
  {
    hidScanInput();
    kDown = hidKeysDown();
    kHeld = hidKeysHeld();
    kUp = hidKeysUp();
    
    touchPosition touch;
    circlePosition cpad;
    circlePosition cstick;
    
    recva:
    
    ret = recvbuf(sizeof(struct packet));
    if(ret <= 0)
    {
        if(!ret) puts("recvbuf == 0");
        if(errno == EAGAIN)
        {
            //no-op
        }
        else
        {
            timer = 0;
            screenon();
            printf("recvbuf: (%i) %s\n", errno, strerror(errno));
            hangmacro();
        }
    }
    else
    {
        switch(inbuf->hdr.cmd)
        {
            case CONNECT:
            {
                if(inbuf->conn.altkey) altkey = inbuf->conn.altkey;
                consoleClear();
                screenon();
                timer = 120;
                connectd = 1;
                handshake(CONNECT);
                break;
            }
            case DISCONNECT:
            {
                memset(&touch, 0, sizeof(touch));
                memset(&cpad, 0, sizeof(cpad));
                memset(&cstick, 0, sizeof(cstick));
                memset(&kHeld, 0, sizeof(kHeld));
                sendinput(0, kHeld, touch, cpad, cstick);
                
                timer = 0;
                screenon();
                consoleClear();
                puts("Disconnected");
                connectd = 0;
                goto reloop;
            }
            case SCREENSHOT:
            {
                if(!timer) screenon();
                timer = 120;
                memcpy(fbBottom + (inbuf->screen.offs * SCREENSHOT_CHUNK), inbuf->screen.data, SCREENSHOT_CHUNK);
                goto recva;
                //break;
            }
            default:
                timer = 0;
                screenon();
                printf("Unknown packet: %i\n", inbuf->hdr.cmd);
                hangmacro();
                break;
        }
    }
    
    hidCircleRead(&cpad);
    irrstCstickRead(&cstick);
    hidTouchRead(&touch);
    
    if(connectd)
    {
        if(timer && !--timer && !altmode && !soc) screenoff();
    
        if(altkey && (kHeld & altkey) == altkey)
        {
            if(!altmode)
            {
                screenon(); 
                altmode = 1;
            }
            ret = sendinput(altmode, kHeld & ~altkey, touch, cpad, cstick);
        }
        else
        {
            if(altmode)
            {
                if(!timer) timer = 30;
                altmode = 0;
            }
            ret = sendinput(0, kHeld, touch, cpad, cstick);
        }
        
        if(ret <= 0)
        {
            if(!ret) puts("sendinput == 0");
            if(errno == EAFNOSUPPORT)
            {
                
            }
            else
            {
                timer = 0;
                screenon();
                printf("sendinput: (%i) %s\n", errno, strerror(errno));
                hangmacro();
            }
        }
    }
    else if((kHeld & (KEY_START | KEY_SELECT)) == (KEY_START | KEY_SELECT)) break;
    
    if(ogg_stream_packetout(&ogv, &ogp) > 0)
    {
        ogg_int64_t dummy;
        if(!th_decode_packetin(vctx, &ogp, &dummy))
        {
            th_ycbcr_buffer ybr;
            
            //puts("decoding image data");
            
            th_decode_ycbcr_out(vctx, ybr);
            
            /*int i;
            for(i = 0; i != 3; i++)
            {
                printf("#%i: %ix%i (%i)\n", i, ybr[i].width, ybr[i].height, ybr[i].stride);
            }*/
            
            Y2RU_StopConversion();
            
            Y2RU_SetSendingY(ybr[0].data, ybr[0].stride * ybr[0].height, ybr[0].width, ybr[0].stride - ybr[0].width);
            Y2RU_SetSendingU(ybr[1].data, ybr[1].stride * ybr[1].height, ybr[1].width, ybr[1].stride - ybr[1].width);
            Y2RU_SetSendingV(ybr[2].data, ybr[2].stride * ybr[2].height, ybr[2].width, ybr[2].stride - ybr[2].width);
            
            Y2RU_SetReceiving\
            (\
                gfxGetFramebuffer(GFX_BOTTOM, GFX_LEFT, nullptr, nullptr),\
                240 * 320 * 3,
                240 * 3,\
                0
            );
            
            //puts("Y2R");
            
            Y2RU_StartConversion();
            
            //if(svcWaitSynchronization(yrhand, 6e7)) puts("Y2R timed out");
        }
    }
    
    if(!soc)
    {
        if(!haznet)
        {
            if(wait4wifi()) goto netreset;
        }
        else if(pollsock(socks, POLLIN) == POLLIN)
        {
            socklen_t sizeof_sai = sizeof(sais);
            int cli = accept(socks, (struct sockaddr*)&sais, &sizeof_sais);
            if(cli < 0)
            {
                printf("Failed to accept client: (%i) %s\n", errno, strerror(errno));
                if(errno == EINVAL) goto netreset;
            }
            else
            {
                th_info_init(&vidinfo);
                th_comment_init(&vidcomm);
                
                if(vidsetup) { th_setup_free(vidsetup); vidsetup = 0; }
                if(vctx) { th_decode_free(vctx); vctx = 0; }
                
                soc = new bufsoc(cli, 0x21000);
            }
        }
        else if(pollsock(socks, POLLERR) == POLLERR)
        {
            printf("POLLERR (%i) %s\n", errno, strerror(errno));
            goto netreset;
        }
    }
    
    if(ogv.body_storage > 0x180000)
    {
        starvecheck:
        if(ogg_stream_packetpeek(&ogv, nullptr) > 0)
        {
            goto nosoc;
        }
        else starving = 1;
    }
    
    if(soc)
    {
        if(soc->avail())
        while(1)
        {
            hidScanInput();
            if(hidKeysHeld() & KEY_SELECT)
            {
                delete soc;
                soc = nullptr;
                break;
            }
            
            //puts("reading");
            cy = soc->readbuf();
            if(cy <= 0)
            {
                printf("Failed to recvbuf: (%i) %s\n", errno, strerror(errno));
                delete soc;
                soc = nullptr;
                break;
            }
            else
            {
                bufsoc::packet* k = soc->pack();
                
                /*if(k->packetid != 4)*/ //printf("================================\n#%i 0x%X | %i\n", k->packetid, k->size, cy);
                
                char* ogbuf;
                
                reread:
                switch(k->packetid)
                {
                    case 0: //CONNECT
                    case 1: //ERROR
                        puts("forced dc");
                        delete soc;
                        soc = nullptr;
                        break;
                    
                    case 2: //DATA
                        ogbuf = ogg_sync_buffer(&ogs, k->size);
                        if(!ogbuf)
                        {
                            puts("No ogg_sync_buffer!");
                            break;
                        }
                        memcpy(ogbuf, k->data, k->size);
                        ret = ogg_sync_wrote(&ogs, k->size);
                        if(ret < 0) printf("ogg_sync_wrote %i\n", ret);
                        
                        if(nohdr || th_hdr <3)
                        {
                            if(nohdr) puts("No headers yet"); else puts("relooping init");
                            
                            if(!th_hdr)
                            {
                                puts("No Theora header yet");
                                while(1)
                                {
                                    ret = ogg_sync_pageout(&ogs, &ogb);
                                    if(ret <= 0)
                                    {
                                        printf("ogg_sync_pageout ded %i\n", ret);
                                        break;
                                    }
                                    
                                    puts("ogg_sync_pageout");
                                    ogg_stream_state ogst;
                                    
                                    if(!ogg_page_bos(&ogb))
                                    {
                                        puts(th_hdr ? "requeueing data" : "no-header data");
                                        if(th_hdr) ogg_stream_pagein(&ogv, &ogb);
                                        nohdr = 0;
                                        break;
                                    }
                                    
                                    ogg_stream_init(&ogst, ogg_page_serialno(&ogb));
                                    ogg_stream_pagein(&ogst, &ogb);
                                    ogg_stream_packetout(&ogst, &ogp);
                                    
                                    if(!th_hdr)
                                    {
                                        puts("testing Theora header");
                                        ret = th_decode_headerin(&vidinfo, &vidcomm, &vidsetup, &ogp);
                                        if(ret < 0)
                                        {
                                            printf("Non-Theora header got, skipping (%i)\n", ret);
                                            ogg_stream_clear(&ogst);
                                        }
                                        else
                                        {
                                            puts("got Theora header");
                                            memcpy(&ogv, &ogst, sizeof(ogv));
                                            th_hdr = 1;
                                        }
                                    }
                                    else
                                    {
                                        ogg_stream_clear(&ogst);
                                    }
                                }
                            }
                            
                            if(!nohdr && !th_hdr)
                            {
                                puts("End of headers without Theora header... wat");
                                delete soc;
                                soc = nullptr;
                                break;
                            }
                            
                            while(th_hdr <3)
                            {
                                puts("ogg_stream_packetout");
                                ret = ogg_stream_packetout(&ogv, &ogp);
                                if(ret < 0)
                                {
                                    printf("Invalid ogg packet! (line #%i): %i\n", __LINE__, ret);
                                    delete soc;
                                    soc = nullptr;
                                    break;
                                }
                                else if(!ret)
                                {
                                    puts("trying to fill pages");
                                    if(ogg_sync_pageout(&ogs, &ogb) > 0)
                                    {
                                        puts("filling page");
                                        ogg_stream_pagein(&ogv, &ogb);
                                    }
                                    else
                                    {
                                        puts("Out of buffer pages while parsing headery, waiting...");
                                        break;
                                    }
                                    
                                    puts("trying again with new pages");
                                    continue;
                                }
                                
                                ret = th_decode_headerin(&vidinfo, &vidcomm, &vidsetup, &ogp);
                                
                                if(ret)
                                {
                                    printf("Invalid Theora packet! (line #%i): %i\n", __LINE__, ret);
                                    //delete soc;
                                    //soc = nullptr;
                                    //break;
                                }
                                else th_hdr++;
                            }
                            
                            if(th_hdr >= 3)
                            {
                                puts("allocating decoder");
                                vctx = th_decode_alloc(&vidinfo, vidsetup);
                                if(!vctx)
                                {
                                    puts("Decoder: Out of Memory");
                                    hangmacro();
                                }
                                
                                puts("setting up Y2R");
                                
                                Y2RU_StopConversion();
                                
                                yparam.alpha = 0xFF;
                                yparam.unused = 0;
                                yparam.rotation = ROTATION_NONE;//CLOCKWISE_90;
                                yparam.block_alignment = BLOCK_LINE;
                                yparam.input_line_width = 240;
                                yparam.input_lines = 320;
                                yparam.standard_coefficient = COEFFICIENT_ITU_R_BT_601;
                                yparam.input_line_width = (yparam.input_line_width + 7) & ~7;
                                switch(vidinfo.pixel_fmt)
                                {
                                    case TH_PF_420:
                                        yparam.input_format = INPUT_YUV420_INDIV_8;
                                        y2y = yparam.input_line_width * yparam.input_lines * 1;
                                        y2u = yparam.input_line_width * yparam.input_lines / 4 * 1;
                                        break;
                                    case TH_PF_422:
                                        yparam.input_format = INPUT_YUV422_INDIV_8;
                                        y2y = yparam.input_line_width * yparam.input_lines * 1;
                                        y2u = yparam.input_line_width * yparam.input_lines / 2 * 1;
                                        break;
                                    case TH_PF_444:
                                        puts("YUV444 is not supported by Y2R");
                                        break;
                                }
                                yparam.output_format = (Y2RU_OutputFormat)OUTPUT_RGB_24;
                                
                                Y2RU_SetConversionParams(&yparam);
                                Y2RU_SetTransferEndInterrupt(1);
                                Y2RU_GetTransferEndEvent(&yrhand);
                            }
                        }
                        else
                        {
                            while(ogg_sync_pageout(&ogs, &ogb) > 0)
                                ogg_stream_pagein(&ogv, &ogb);
                        }
                        
                        if(starving)
                        {
                            starving = 0;
                            goto starvecheck;
                        }
                        
                        break;
                    
                    default:
                        printf("Invalid packet ID: %i\n", k->packetid);
                        delete soc;
                        soc = nullptr;
                        break;
                }
                
                break;
            }
        }
        
        if(!soc) goto reloop;
    }
    nosoc:
    
    gfxFlushBuffers();
    gfxSwapBuffers();
    gspWaitForVBlank();
  }

  // =====[END]=====
  
  killswitch:
  
  if(vidsetup) th_setup_free(vidsetup);
  if(vctx) th_decode_free(vctx);
  
  if(yrhand) svcCloseHandle(yrhand);
  
  irrstExit();
  
  handshake(DISCONNECT);
  
  screenon();
  
  close(sock);
  close(socks);
  SOCU_ShutdownSockets();
  
  socExit();
  y2rExit();
  acExit();
  gfxExit();

  return 0;
}
