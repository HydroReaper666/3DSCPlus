#include <stddef.h>
#include <errno.h>

#include "net.h"

int sock = 0;
struct sockaddr_in sai, sao;
struct packet *inbuf, *outbuf;

static socklen_t saddrsize = sizeof(struct sockaddr_in);

int preparesock(int port)
{
    if(sock) closesocket(sock);
    sock = socket(AF_INET, SOCK_DGRAM, 0);
    if(sock < 0)
    {
        puts("socket()");
        sock = 0;
        return errno;
    }
    
    //int opt = 1;
    //setsockopt(sock, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));
    
    sai.sin_addr.s_addr = INADDR_ANY;
    sai.sin_family = AF_INET;
    sai.sin_port = htons(port);
    
    int ret = bind(sock, &sai, sizeof(sai));
    if(ret < 0)
    {
        puts("bind()");
        closesocket(sock);
        sock = 0;
        return errno;
    }
    
    fcntl(sock, F_SETFL, O_NONBLOCK);
    
    return 0;
}

int sendbuf(int length)
{
    return sendto(sock, outbuf, length, 0, &sao, sizeof(sao));
}

int recvbuf(int length)
{
    return recvfrom(sock, inbuf, length, 0, &sao, &saddrsize);
}

int handshake(int cmd)
{
    outbuf->hdr.cmd = cmd;
    outbuf->hdr.altcmd = 0;
    return sendbuf(offsetof(struct packet, conn) + sizeof(outbuf->conn));
}

int sendinput(u8 altcmd, u32 key, touchPosition touch, circlePosition cpad, circlePosition cstick)
{
    outbuf->hdr.cmd = KEYS;
    outbuf->hdr.altcmd = altcmd;
    outbuf->input.key = key;
    outbuf->input.touch = touch;
    outbuf->input.cpad = cpad;
    outbuf->input.cstick = cstick;
    return sendbuf(offsetof(struct packet, input) + sizeof(outbuf->input));
}

int SendKeysEx(u8 seq, u32 keys)
{
    outbuf->hdr.cmd = 0x7E;
    outbuf->hdr.altcmd = 0;
    outbuf->hdr.seq = seq & 0x7F;
    *(u32*)(((u8*)outbuf) + 4) = keys;
    return sendbuf(8);
}

int SendTouchEx(u8 seq, s16 x, s16 y, u8 is)
{
    outbuf->hdr.cmd = 0x7F;
    outbuf->hdr.altcmd = 0;
    outbuf->hdr.seq = (seq & 0x7F) | (is ? 0x80 : 0);
    s16* stuff = (s16*)(((u8*)outbuf) + 4);
    *(stuff++) = x;
    *(stuff++) = y;
    return sendbuf(8);
}

int SendCalEx(s16* cal)
{
    outbuf->hdr.cmd = 0x7D;
    outbuf->hdr.altcmd = 0;
    outbuf->hdr.seq = 0;
    s16* stuff = (s16*)(((u8*)outbuf) + 4);
    *(stuff++) = cal[0];
    *(stuff++) = cal[1];
    *(stuff++) = cal[2];
    *(stuff++) = cal[3];
    *(stuff++) = cal[4];
    *(stuff++) = cal[5];
    *(stuff++) = cal[6];
    *(stuff++) = cal[7];
    return sendbuf(20);
}

int SendCalErr(Result res)
{
    outbuf->hdr.cmd = 0x7D;
    outbuf->hdr.altcmd = 0;
    outbuf->hdr.seq = 0;
    *(Result*)(((u8*)outbuf) + 4) = res;
    return sendbuf(8);
}
