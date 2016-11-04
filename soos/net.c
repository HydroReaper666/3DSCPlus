#include <stddef.h>
#include <errno.h>

#include "net.h"

int sock = 0;
struct sockaddr_in sai, sao;
struct packet *inbuf, *outbuf;

static saddrsize = sizeof(struct sockaddr_in);

int preparesock(int port)
{
    puts("socket()");
    sock = socket(AF_INET, SOCK_DGRAM, 0);
    if(sock < 0)
    {
        sock = 0;
        return errno;
    }
    
    int opt = 1;
    setsockopt(sock, SOL_SOCKET, SO_REUSEADDR, &opt, sizeof(opt));
    
    sai.sin_family = sao.sin_family = AF_INET;
    sai.sin_port = sao.sin_port = htons(port);
    
    puts("bind()");
    int ret = bind(sock, &sai, sizeof(sai));
    if(ret < 0)
    {
        close(sock);
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

int handshake()
{
    outbuf->hdr.cmd = CONNECT;
    outbuf->hdr.altcmd = 0;
    return sendbuf(offsetof(struct packet, conn) + sizeof(struct packet_conn));
}

int sendinput(u8 altcmd, u32 key, touchPosition touch, circlePosition cpad, circlePosition cstick)
{
    outbuf->hdr.cmd = KEYS;
    outbuf->hdr.altcmd = altcmd;
    outbuf->input.key = key;
    outbuf->input.touch = touch;
    outbuf->input.cpad = cpad;
    outbuf->input.cstick = cstick;
    return sendbuf(offsetof(struct packet, input) + sizeof(struct packet_input));
}
