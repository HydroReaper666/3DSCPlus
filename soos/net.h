#pragma once

#include <string.h>

#include <3ds.h>

#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include <arpa/inet.h>
#include <fcntl.h>

#define SCREENSHOT_CHUNK (240 * 3 * 4)

enum NET_COMMANDS
{
	CONNECT = 0,
	DISCONNECT,
	KEYS,
	SCREENSHOT,
	VID_START,
	VID_DATA,
	VID_END
};

struct packet
{
    struct packethdr
    {
        unsigned char cmd;
        unsigned char altcmd;
    } hdr;
	
	union
	{
		// CONNECT
        struct
        {
            u32 altkey;
        } conn;
		
		// KEYS
        struct
        {
            u32 key;
            touchPosition touch;
            circlePosition cpad;
            circlePosition cstick;
        } input;
		
		// SCREENSHOT
        struct
        {
            u16 offs;
            u8 data[SCREENSHOT_CHUNK];
        } screen;
	};
};

extern int sock;
extern struct sockaddr_in sai, sao;
extern struct packet *inbuf, *outbuf;

int preparesock(int port);
int sendbuf(int length);
int recvbuf(int length);
int handshake(int cmd);
int sendinput(u8 altcmd, u32 keys, touchPosition touch, circlePosition cpad, circlePosition cstick);
