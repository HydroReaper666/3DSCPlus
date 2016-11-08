using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MarcusD._3DSCPlusDummy
{
    using Keybinding = Dummy.Keybinding;
    using Simutype = Dummy.Keybinding.Simutype;
    using Event = Dummy.Keybinding.Event;
    using System.Net;
    using System.Net.Sockets;
using System.Runtime.InteropServices;

    public class Dummy
    {
        public int kheld = 0;
        public int kdown = 0;
        public int kup = 0;

        public Thread t = null;
        public Boolean running = false;

        public String ipaddr = "10.0.0.101";
        public UInt16 port = 6956;

        int polltimeout = 3 * 1000 * 1000;
        int altkey = 1 << 11;
        Boolean dcexit = false;
        int deadzone = 12;
        int speed = 1;

        int currspeed = 1;

        public Keybinding[] bindings = new Keybinding[32 * 2];

        public class Keybinding
        {
            public enum Simutype
            {
                NONE = 0,
                KDOWN,
                KUP,
                MABS,
                MREL,
                MEVT,
                M_MSPEED,
            };

            [StructLayout(LayoutKind.Explicit)]
            public struct Event
            {
                [FieldOffset(0)]
                public Simutype evt;
                //public union
                //{
                    [FieldOffset(4)]
                    public NativeInput.KeyScan k;
                    [FieldOffset(4)]
                    public NativeInput.MouseEventFlags mouseflags;
                    [FieldOffset(8)]
                    public int mousepos;
                    [FieldOffset(8)]
                    public short mousex;
                    [FieldOffset(10)]
                    public short mousey;
                //};

                public override string ToString()
                {
                    switch(evt)
                    {
                        case Simutype.KUP:      return "[KeyUp] " + k;
                        case Simutype.KDOWN:    return "[KeyDown] " + k;
                        case Simutype.MABS:     return "[MouseAbsolute] X=" + mousex + " Y=" + mousey;
                        case Simutype.MREL:     return "[MouseRelative] X=" + mousex + " Y=" + mousey;
                        case Simutype.MEVT:     return "[MouseEvent] " + mouseflags + " (" + mousepos + ")";
                        case Simutype.M_MSPEED: return "[MouseSpeed] " + mousepos;

                        default: return "[" + evt + "]";
                    }
                }
            };

            public List<Event> edown;
            public List<Event> eup;
            public List<Event> eheld;

            public Button btn;
            public Label lbl;
            public int nth;

            public Keybinding()
            {
                edown = new List<Event>();
                eup = new List<Event>();
                eheld = new List<Event>();
            }
        }

        public Dummy()
        {
            
        }
        
        void HandleLoop()
        {
            IPEndPoint sockaddr_in = new IPEndPoint(IPAddress.Parse(ipaddr), port);
            EndPoint dummyaddr_in = new IPEndPoint(IPAddress.Any, port);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(dummyaddr_in);

            List<byte> obuf = new List<byte>();
            byte[] buf = new byte[0x1000];

            int timeout = 0;
            Boolean connected = false;

            Int16 px = 0, py = 0;

            while(running)
            {
                if(!sock.Poll(timeout, SelectMode.SelectRead))
                {
                    if(connected)
                    {
                        Console.WriteLine("Socket timeout");
                        connected = false;
                    }
                    timeout = polltimeout;
                    obuf.Clear();
                    obuf.Add(0); //PacketID
                    obuf.Add(0); //altkey (dummy)
                    obuf.Add(0); //padding1
                    obuf.Add(0); //padding2
                    obuf.Add((byte)((altkey >>  0) & 0xFF)); //altkey1
                    obuf.Add((byte)((altkey >>  8) & 0xFF)); //altkey2
                    obuf.Add((byte)((altkey >> 16) & 0xFF)); //altkey3
                    obuf.Add((byte)((altkey >> 24) & 0xFF)); //altkey4
                    Console.WriteLine("Sending ping packet");
                    sock.SendTo(obuf.ToArray(), sockaddr_in);
                    continue;
                }

                if(sock.Poll(0, SelectMode.SelectError)) continue;

                try
                {
                    sock.ReceiveFrom(buf, ref dummyaddr_in);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    continue;
                }

                if(!(dummyaddr_in is IPEndPoint))
                {
                    Console.WriteLine("Unsupported EndPoint type");
                    continue;
                }
                else
                {
                    IPEndPoint recv = (IPEndPoint)dummyaddr_in;
                    if(!sockaddr_in.Address.Equals(recv.Address))
                    {
                        Console.WriteLine("Ignoring message from invalid address " + recv.Address + ":" + sockaddr_in.Address);
                        continue;
                    }
                }

                switch(buf[0])
                {
                    case 0: //CONNECT
                        Console.WriteLine("Pong received");
                        connected = true;
                        //TODO implement sockimg
                        continue;
                    case 1: //DISCONNECT
                        Console.WriteLine("Disconnected");
                        connected = false;
                        if(dcexit) running = false;
                        continue;
                    case 2: //KEYS
                        byte altcmd = buf[1];
                        int currkey = buf[4] | (buf[5] << 8) | (buf[6] << 16) | (buf[7] << 24);
                        Int16 tx = (Int16)(buf[8]  | (buf[9]  << 8));
                        Int16 ty = (Int16)(buf[10] | (buf[11] << 8));
                        Int16 cx = (Int16)(buf[12] | (buf[13] << 8));
                        Int16 cy = (Int16)(buf[14] | (buf[15] << 8));
                        Int16 sx = (Int16)(buf[16] | (buf[17] << 8));
                        Int16 sy = (Int16)(buf[18] | (buf[19] << 8));

                        if(Math.Abs(cx) < deadzone) cx = 0;
                        if(Math.Abs(cy) < deadzone) cy = 0;
                        if(Math.Abs(sx) < deadzone) sx = 0;
                        if(Math.Abs(sy) < deadzone) sy = 0;

                        Console.WriteLine("K: " + currkey + " T: " + tx + "x" + ty + " C: " + cx + "x" + cy + " S: " + sx + "x" + sy);

                        kdown = currkey & ~kheld;
                        kup = ~currkey & kheld;
                        kheld = currkey;


                        foreach(Keybinding k in bindings)
                        {
                            if(k == null) continue;

                            if((kdown & (1 << k.nth)) != 0) ProcessKDown(k);
                            else if((kheld & (1 << k.nth)) != 0) ProcessKHeld(k);
                            else if((kup & (1 << k.nth)) != 0) ProcessKUp(k);
                        }

                        //special case
                        if((kdown & (1 << 20)) != 0) //KEY_TOUCH
                        {
                            px = tx;
                            py = ty;
                        }
                        else if((kheld & (1 << 20)) != 0) //KEY_TOUCH
                        {
                            NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), (tx - px) * currspeed, (ty - py) * currspeed, 0, 0);

                            px = tx;
                            py = ty;
                        }
                        else if((kdown & (1 << 20)) != 0) //KEY_TOUCH
                        {
                            px = 0;
                            py = 0;
                        }

                        //TODO config option

                        NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), cx * currspeed / 32, -cy * currspeed / 32, 0, 0);

                        break;

                    case 3: //SCREENSHOT (unused)
                    default:
                        break;
                }
                
            }

            //keep the 3DS happy
            obuf.Clear();
            obuf.Add(1); //PacketID (DISCONNECT)
            obuf.Add(0); //altkey (dummy)
            obuf.Add(0); //padding1
            obuf.Add(0); //padding2
            obuf.Add(0); //altkey1
            obuf.Add(0); //altkey2
            obuf.Add(0); //altkey3
            obuf.Add(0); //altkey4
            Console.WriteLine("Sending disconnect packet");
            sock.SendTo(obuf.ToArray(), sockaddr_in);


            sock.Shutdown(SocketShutdown.Both);
        }

        void ProcessKDown(Dummy.Keybinding key)
        {
            if(key == null) return;

            foreach(Dummy.Keybinding.Event evt in key.edown) ProcessEvent(evt);
        }

        void ProcessKUp(Dummy.Keybinding key)
        {
            if(key == null) return;

            foreach(Dummy.Keybinding.Event evt in key.eup) ProcessEvent(evt);
        }

        void ProcessKHeld(Dummy.Keybinding key)
        {
            if(key == null) return;

            foreach(Dummy.Keybinding.Event evt in key.eheld) ProcessEvent(evt);
        }

        void ProcessEvent(Dummy.Keybinding.Event evt)
        {
            switch(evt.evt)
            {
                case Simutype.KDOWN:
                    NativeInput.keybd_event((byte)evt.k, 0, 0, 0);
                    break;

                case Simutype.KUP:
                    NativeInput.keybd_event((byte)evt.k, 0, (uint)NativeInput.KeyEventFlags.KEYUP, 0);
                    break;

                case Simutype.MREL:
                    NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), evt.mousex * currspeed, evt.mousey * currspeed, 0, 0);
                    break;

                case Simutype.MABS:
                    NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE | NativeInput.MouseEventFlags.MOVE_ABS), evt.mousex, evt.mousey, 0, 0);
                    break;

                case Simutype.MEVT:
                    NativeInput.mouse_event((int)evt.mouseflags, 0, 0, evt.mousepos, 0);
                    break;

                case Simutype.M_MSPEED:
                    currspeed += evt.mousepos;
                    if(currspeed < speed) currspeed = speed; //no upper bound, lol
                    break;

            }
        }

        public void SetKeybind(Button btn, Label lbl, int nth, IEnumerable<Event> edown, IEnumerable<Event> eup, IEnumerable<Event> eheld)
        {
            if(nth < 0 || nth > 31) return;

            bindings[nth] = new Keybinding()
            {
                btn = btn,
                lbl = lbl,
                nth = nth
            };

            btn.Click += btn_Click;

            if(edown != null)
            {
                foreach(Event e in edown)
                {
                    bindings[nth].edown.Add(e);
                }
            }

            if(eup != null)
            {
                foreach(Event e in eup)
                {
                    bindings[nth].eup.Add(e);
                }
            }

            if(eheld != null)
            {
                foreach(Event e in eheld)
                {
                    bindings[nth].eheld.Add(e);
                }
            }
        }

        public void DelKeybind(int nth)
        {
            if(nth < 0 || nth > 31) return;

            bindings[nth] = null;
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button dis = (Button)sender;

            Keybinding kb = null;

            foreach(Keybinding k in bindings)
            {
                if(k == null) continue;
                if(k.btn != dis) continue;

                kb = k;
                break;
            }

            if(kb == null) throw new Exception("umm... wat? this button isn't bound to anything!");

            using(FormBuilder frmb = new FormBuilder(kb.btn.Text, kb.edown, kb.eup, kb.eheld))
            {
                frmb.StartPosition = FormStartPosition.CenterParent;
                frmb.ShowDialog();
            }
        }

        public void Start()
        {
            if(t != null) return;
            if(running) return;

            t = new Thread(HandleLoop);
            running = true;
            t.Start();
        }

        public void Stop()
        {
            if(t == null) return;
            if(!running) return;

            running = false;
            t.Join(2500);
            if(t.IsAlive) t.Interrupt();
            t = null;
        }
    }
}
