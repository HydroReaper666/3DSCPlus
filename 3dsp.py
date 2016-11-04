#!/usr/bin/env python

from __future__ import print_function
import socket, select, struct, time
import sys, signal
import Xlib, Xlib.display, Xlib.XK
LMouse = []; RMouse = []; MMouse = []; MouseSU = []; MouseSD = []; MouseSL = []; MouseSR = []; MouseF = [];
Button = []; MouseAbs = []; MouseRel = []; MouseAbsClick = []; MouseRelClick = []

##########################################################
# CONFIGURABLE REGION START - Don't touch anything above #
##########################################################

#3DS IP address and port (port is hardcoded in the 3DS client)
host = '10.0.0.101'
port = 6956

#interval to check if the 3DS has been disconnected
polltimeout = 3

#alternative mode activator keycombo
altkey = ["Y"]

#exit program if the 3DS disconnects
dcexit = False

#overlay image to send (None or (filename, timeout))
img = ('3dso.png', 0.02)

#This tells what the touch screen does if touched.
#Valid values: Button, MouseAbs, MouseRel, MouseRelClick, MouseRelClick
#Button sends the Tap button.
#MouseAbs moves your mouse to the same part of the screen as the touch screen was touched.
#MouseRel moves your mouse by the same distance as you drag across the touch screen.
#MouseAbsClick and MouseRelClick send the primary mouse button event if the screen is tapped, not held.
touch = MouseRel#Click

mouse_speed = 1
mouse_speedup = 3
# The number of pixels on each side of the 3DS screen which are ignored, since you can't reach the outermost corners.
abs_deadzone = 10

#Valid values can be found in any of these locations on your Linux system (some may not exist):
# /usr/include/X11/keysymdef.h

btn_map = \
{
    "A": ["P"],
    "B": ["E"],
    "Select": [" "],
    "Start": [Xlib.XK.XK_Control_L, "S"],
    "Right": [Xlib.XK.XK_Right],
    "Left": [Xlib.XK.XK_Left],
    "Up": [Xlib.XK.XK_Up],
    "Down": [Xlib.XK.XK_Down],
    "L": [Xlib.XK.XK_Control_L],
    "R": [LMouse],
    "X": ["X"],
    "Y": ["N"],
    "ZL": [RMouse],
    "ZR": [MouseF],
    "Tap": [],
    "CSRight": [MouseSR],
    "CSLeft": [MouseSL],
    "CSUp": [MouseSU],
    "CSDown": [MouseSD],
    "CRight": [],
    "CLeft": [],
    "CUp": [],
    "CDown": [],
}

alt_map = \
[
    (90, 90, 140, 60, [" "]),
    (0, 0, 16, 16, [Xlib.XK.XK_Control_L, "S"])
]
########################################################
# CONFIGURABLE REGION END - Don't touch anything below #
########################################################

def pprint(obj):
	import pprint
	pprint.PrettyPrinter().pprint(obj)

if img:
	try:
		import sockimg
	except:
		print("sockimg can't be found, image won't be sent!")
		img = None
		pass

class x: pass

command = x()
command.CONNECT = 0
command.DISCONNECT = 1
command.KEYS = 2
command.SCREENSHOT = 3

keynames = \
[
    "A",
    "B",
    "Select",
    "Start",
    "Right",
    "Left",
    "Up",
    "Down",
    "R",
    "L",
    "X",
    "Y",
    None,
    None,
    "ZL",
    "ZR",
    None,
    None,
    None,
    None,
    "Tap",
    None,
    None,
    None,
    "CSRight",
    "CSLeft",
    "CSUp",
    "CSDown",
    "CRight",
    "CLeft",
    "CUp",
    "CDown"
]

keys = x()
keys.A       = 1<<0
keys.B       = 1<<1
keys.Select  = 1<<2
keys.Start   = 1<<3
keys.Right   = 1<<4
keys.Left    = 1<<5
keys.Up      = 1<<6
keys.Down    = 1<<7
keys.R       = 1<<8
keys.L       = 1<<9
keys.X       = 1<<10
keys.Y       = 1<<11
keys.ZL      = 1<<14 # (new 3DS only)
keys.ZR      = 1<<15 # (new 3DS only)
keys.Tap     = 1<<20 # Not actually provided by HID
keys.CSRight = 1<<24 # c-stick (new 3DS only)
keys.CSLeft  = 1<<25 # c-stick (new 3DS only)
keys.CSUp    = 1<<26 # c-stick (new 3DS only)
keys.CSDown  = 1<<27 # c-stick (new 3DS only)
keys.CRight  = 1<<28 # circle pad
keys.CLeft   = 1<<29 # circle pad
keys.CUp     = 1<<30 # circle pad
keys.CDown   = 1<<31 # circle pad

def currentKeyboardKey(x, y):
	for i in alt_map:
		if i[0] <= x and (i[0] + i[2]) > x and i[1] <= y and (i[1] + i[3]) > y:
			return i[4]
	return None

def key_to_keysym(key):
	if not key: return 0
	
	if isinstance(key,str):
		if key=="\x08": return Xlib.XK.XK_BackSpace
		if key=="\13": return Xlib.XK.XK_Return
		if key==" ": return Xlib.XK.XK_space
		return Xlib.XK.string_to_keysym(key)
	
	return key

def action_key(key, action):
	x_action = Xlib.X.ButtonRelease
	x_action2 = Xlib.X.KeyRelease
	if action:
		x_action = Xlib.X.ButtonPress
		x_action2 = Xlib.X.KeyPress
	
	if key is LMouse or key is RMouse or key is MMouse or key is MouseSU or key is MouseSD or key is MouseSL or key is MouseSR:
		if key is LMouse: button = 1
		if key is MMouse: button = 2
		if key is RMouse: button = 3
		if key is MouseSU: button = 4
		if key is MouseSD: button = 5
		if key is MouseSL: button = 6
		if key is MouseSR: button = 7
		button = disp.get_pointer_mapping()[button-1] # account for left-handed mice
		disp.xtest_fake_input(x_action, button)
		disp.sync()
		return
	
	if key is MouseF:
		global mouse_speed
		if action: mouse_speed += mouse_speedup
		if not action: mouse_speed -= mouse_speedup
		return
	
	keysym = key_to_keysym(key)
	if not keysym: return
	
	keycode = disp.keysym_to_keycode(keysym)
	disp.xtest_fake_input(x_action2, keycode)
	disp.sync()
	
def press_key(key):
	action_key(key,True)

def release_key(key):
	action_key(key,False)

def move_mouse(x,y):
	x=int(x)
	y=int(y)
	if not x and not y: return
	
	disp.warp_pointer(x,y)
	disp.sync()

def move_mouse_abs_frac(x,y):
	root = disp.screen().root
	geom = root.get_geometry()
	
	root.warp_pointer(int(x*geom.width), int(y*geom.height))
	disp.sync()

disp = Xlib.display.Display()

touch_click = (touch is MouseAbsClick or touch is MouseRelClick)
if touch is MouseAbsClick: touch = MouseAbs
if touch is MouseRelClick: touch = MouseRel

if touch is MouseAbs and disp.screen_count()!=1:
	print("Sorry, but MouseAbs only supports a single monitor. I'll use MouseRel instead.")
	touch = MouseRel

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

prevkeys = 0

touch_start = 0
touch_last_x = 0
touch_last_y = 0

keyboard_prevkey = None

altkeyi = altkey
altkey = 0

for ke in altkeyi:
	for k,v in enumerate(keynames):
		if v == ke:
			altkey += 1 << k

def sigterm_handler(_signo, _stack_frame):
	rawdata = struct.pack('<BBxxI', 1, 0, 0)
	sock.sendto(rawdata,(host,port))
	sys.exit(0)

signal.signal(signal.SIGTERM, sigterm_handler)

def loopme():
	global rawdata
	global sock
	global addr
	global prevkeys
	global keyboard_prevkey
	global touch_start
	global touch_last_x
	global touch_last_y
	global connectd
	
	connectd = False
	_timeout = 0
	
	while True:
		sel = select.select([sock], [], [], _timeout)
		if not sel[0]:
			if connectd:
				#print("Socket timeout")
				connectd = False
			_timeout = polltimeout
			#print("Sending ping packet to",host)
			rawdata = struct.pack('<BBxxI', 0, 0, altkey)
			sock.sendto(rawdata,(host,port))
			continue
		
		rawdata, addr = sock.recvfrom(4096)
		if addr[0] != host:
			#print("ignoring message", rawdata, "from", addr[0])
			continue
		
		rawdata = bytearray(rawdata)
		#print("received message %i" % rawdata[0], "from", addr)
		
		if not connectd or rawdata[0]==command.CONNECT:
			connectd = True
			if img:
				try:
					sockimg.sockimg(sock, img[0], (host,port), img[1])
				except:
					print("Can't send image!")
					pass
		
		if not connectd: continue
		
		if rawdata[0]==command.DISCONNECT:
			if dcexit: raise KeyboardInterrupt
			else:
				connectd = False
				continue
		
		if rawdata[0]==command.KEYS:
			fields = struct.unpack("<BBxxIHHhhhh", rawdata)
			
			data = \
			{
				"command": fields[0],
				"altcmd": fields[1],
				"keys": fields[2],
				"touchX": fields[3],
				"touchY": fields[4],
				"circleX": fields[5],
				"circleY": fields[6],
				"cstickX": fields[7],
				"cstickY": fields[8],
			}
			#print(data)
			
			newkeys = data["keys"] & ~prevkeys
			oldkeys = ~data["keys"] & prevkeys
			prevkeys = data["keys"]
			
			for btnid in range(32):
				if newkeys & (1<<btnid):
					for ke in btn_map[keynames[btnid]]:
						press_key(ke)
				if oldkeys & (1<<btnid):
					for ke in reversed(btn_map[keynames[btnid]]):
						release_key(ke)
			if newkeys & keys.Tap:
				if data["altcmd"]:
					keyboard_prevkey = currentKeyboardKey(data["touchX"], data["touchY"])
					if keyboard_prevkey:
						for ke in keyboard_prevkey:
							press_key(ke)
				elif touch is Button:
					for ke in btn_map["Tap"]:
						press_key(ke)
				touch_start = time.time()
			if oldkeys & keys.Tap:
				if keyboard_prevkey:
					for ke in reversed(keyboard_prevkey):
						release_key(ke)
					keyboard_prevkey = None
				elif touch is Button:
					for ke in btn_map["Tap"]:
						release_key(ke)
			if data["keys"] & keys.Tap:
				if touch is MouseAbs:
					x = (data["touchX"]-abs_deadzone) / (320.0-abs_deadzone*2)
					y = (data["touchY"]-abs_deadzone) / (240.0-abs_deadzone*2)
					move_mouse_abs_frac(x, y)
				if touch is MouseRel and not newkeys & keys.Tap:
					x = (data["touchX"]-touch_last_x) * mouse_speed
					y = (data["touchY"]-touch_last_y) * mouse_speed
					move_mouse(x, y)
				touch_last_x = data["touchX"]
				touch_last_y = data["touchY"]
			
			if oldkeys & keys.Tap and touch_click and time.time()-touch_start < 0.1 and not keyboard_prevkey:
				press_key(LMouse)
				release_key(LMouse)
			
			if abs(data["circleX"])>=16 or abs(data["circleY"])>=16:
				move_mouse(data["circleX"]*mouse_speed/32.0, -data["circleY"]*mouse_speed/32.0)
		
		if rawdata[0]==command.SCREENSHOT:
			pass # unused by both 3DS and PC applications

try:
	loopme()
except KeyboardInterrupt:
	sigterm_handler(None, None)
	pass