#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <malloc.h>
#include <errno.h>
#include <stdarg.h>
#include <unistd.h>

#include <3ds.h>

#include "net.h"
#include "inet_pton.h"

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

#define wait4wifi()\
({\
    puts("Waiting for wifi...");\
    while(aptMainLoop())\
    {\
        u32 wifi = 0;\
        ACU_GetWifiStatus(&wifi);\
        if(wifi) break;\
        hidScanInput();\
        if((hidKeysHeld() & (KEY_SELECT | KEY_START)) == (KEY_SELECT | KEY_START)) goto killswitch;\
        gspWaitForVBlank();\
    }\
})

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

int main()
{
  // =====[PROGINIT]=====
  
  gfxInit(GSP_BGR8_OES, GSP_BGR8_OES, false);
  
  gfxSetDoubleBuffering(GFX_TOP, false);
  gfxSetDoubleBuffering(GFX_BOTTOM, false);
  
  acInit();
  
  inbuf = malloc(sizeof(struct packet));
  outbuf = malloc(sizeof(struct packet));
  
  // =====[VARS]=====
  
  int ret = 0;
  u32 kDown;
  u32 kHeld;
  u32 kUp;
  u8* fbTopLeft;
  u8* fbTopRight;
  u8* fbBottom;
  PrintConsole console;
  u32 timer = 0;
  u32 altkey = 0;
  
  int altmode = 0;
  
  // =====[PREINIT]=====
  
  consoleInit(GFX_TOP, &console);
  consoleSelect(&console);
  
  puts("Console attached");
  
  fbTopLeft = gfxGetFramebuffer(GFX_TOP, GFX_LEFT, NULL, NULL);
  fbTopRight = gfxGetFramebuffer(GFX_TOP, GFX_RIGHT, NULL, NULL);
  fbBottom = gfxGetFramebuffer(GFX_BOTTOM, 0, NULL, NULL);
  
  printf("socInit %08X\n", socInit(memalign(0x1000, 0x100000), 0x100000));
  
  wait4wifi();
  
  sai.sin_addr.s_addr = INADDR_ANY;//inet_pton4("10.0.0.103", &sao.sin_addr.s_addr);
  sao.sin_addr.s_addr = INADDR_ANY;
  ret = preparesock(6956);
  printf("preparesock %08X\n", ret);
  if(ret) hangmacro();
  
  puts("Waiting for initial connection...");
  
  // =====[RUN]=====
  reloop:
  while (aptMainLoop())
  {
    hidScanInput();
    kDown = hidKeysDown();
    kHeld = hidKeysHeld();
    kUp = hidKeysUp();
    
    touchPosition touch;
    circlePosition cpad;
    circlePosition cstick;
    
    int ret = recvbuf(sizeof(struct packet));
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
            printf("recvbuf: %i\n", errno);
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
                puts("dc'd");
                break;
            }
            case SCREENSHOT:
            {
                if(!timer) screenon();
                timer = 120;
                memcpy(fbBottom + (inbuf->screen.offs * SCREENSHOT_CHUNK), inbuf->screen.data, SCREENSHOT_CHUNK);
                break;
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
    
    if(timer && !--timer && !altmode) screenoff();
    
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
            //no-op, never connected
        }
        else
        {
            timer = 0;
            screenon();
            printf("sendinput: %i\n", errno);
            hangmacro();
        }
    }
    
    gfxFlushBuffers();
    gfxSwapBuffers();
    gspWaitForVBlank();
  }

  // =====[END]=====
  
  killswitch:
  
  screenon();
  
  close(sock);
  SOCU_ShutdownSockets();
  
  socExit();
  acExit();
  gfxExit();

  return 0;
}
