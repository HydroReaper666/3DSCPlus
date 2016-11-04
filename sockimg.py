#!/usr/bin/env python

import sys, socket, struct, time, operator
from PIL import Image
from io import BytesIO

def sockimg(sock, fn, dest, timeout =  0.02):
	img = Image.open(fn)
	img = img.transpose(Image.ROTATE_270)
	img = img.convert('RGB')
	r, g, b = img.split()
	img = Image.merge('RGB', (b,g,r))
	
	data = tuple(component for pixel in list(img.getdata()) for component in pixel)
	
	if not sock: sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
	
	i = 80
	while i > 0:
		i -= 1
		senddata = struct.pack('<BBxxH2880B', 3, 0, i, *data[(i*240*3*4):(i+1)*(240*3*4)])
		sock.sendto(senddata, dest)
		time.sleep(timeout)

if __name__ == '__main__':
	argc = len(sys.argv)
	print('argc: %i' % argc)
	if argc < 3 or argc > 4:
		print('Usage: %s <file> <IP> [port]' % sys.argv[0])
		sys.exit(1)
	sockimg(None, sys.argv[1], (sys.argv[2],int(sys.argv[3]) if argc > 3 else 6956))
