#!/usr/bin/env python

import sys, socket, struct, time, operator
from PIL import Image
from io import BytesIO

img = Image.open(sys.argv[1])
img = img.transpose(Image.ROTATE_270)
img = img.convert('RGB')
r, g, b = img.split()
img = Image.merge('RGB', (b,g,r))

data = tuple(component for pixel in list(img.getdata()) for component in pixel)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

i = 80
while i > 0:
	i = i - 1
	senddata = struct.pack('<BBxxH2880B', 3, 0, i, *data[(i*240*3*4):(i+1)*(240*3*4)])
	sock.sendto(senddata, ('10.0.0.101',6956))
	time.sleep(0.02)

