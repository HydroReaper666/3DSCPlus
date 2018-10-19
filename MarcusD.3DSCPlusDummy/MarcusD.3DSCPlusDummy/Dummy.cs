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
    using System.Drawing;
    using System.IO;

    public class Dummy
    {
        public int kheld = 0;
        public int kdown = 0;
        public int kup = 0;

        public Thread t = null;
        public Boolean running = false;
        public Boolean debug = false;

        public String ipaddr = "10.0.0.103";
        public UInt16 port = 6956;

        public byte[] imgbuf = null;

        public int polltimeout = 3 * 1000 * 1000;
        public int altkey = 1 << 11;
        public Boolean dcexit = false;
        public int deadzone = 12;
        public int divx = 32;
        public int divy = 32;
        public int mmode = 1;

        int speed = 1;
        public int currspeed = 1;

        public Keybinding[] bindings = new Keybinding[32];
        public List<RektButton> rekts = new List<RektButton>();

        RektButton currekt = null;

        public Boolean abs = false;

        public IntPtr hwnd = IntPtr.Zero;

        //float spx = 65535 / 320.0F;
        //float spy = 65535 / 240.0F;

        //float spx = 1366 / 320.0F;
        //float spy = 768 / 240.0F;

        Boolean iscal = false;
        short[] cal = null;

        float expandlerp(float to_l, float to_h, float from_l, float from_h, float from_v)
        {
            return ((from_v - from_l) / (from_h - from_l)) * (to_h - to_l) + to_l;
        }

        public class RektButton
        {
            public Rectangle rekt;
            public Dummy.Keybinding kb;

            public void Export(FileStream fs)
            {
                byte[] b = NativeInput.struct2byte(rekt);
                fs.Write(b, 0, b.Length);
                kb.Export(fs);
            }

            public void Import(FileStream fs)
            {
                byte[] buf = new byte[System.Runtime.InteropServices.Marshal.SizeOf(typeof(Rectangle))];
                fs.Read(buf, 0, buf.Length);
                rekt = NativeInput.byte2struct<Rectangle>(buf);
                kb = new Keybinding();
                kb.Import(fs);
            }
        }

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
            public int nth;

            public void Export(FileStream fs)
            {
                fs.WriteByte((byte)edown.Count);
                foreach(Dummy.Keybinding.Event ev in edown)
                {
                    byte[] buf = NativeInput.struct2byte(ev);
                    fs.Write(buf, 0, buf.Length);
                }

                fs.WriteByte((byte)eup.Count);
                foreach(Dummy.Keybinding.Event ev in eup)
                {
                    byte[] buf = NativeInput.struct2byte(ev);
                    fs.Write(buf, 0, buf.Length);
                }

                fs.WriteByte((byte)eheld.Count);
                foreach(Dummy.Keybinding.Event ev in eheld)
                {
                    byte[] buf = NativeInput.struct2byte(ev);
                    fs.Write(buf, 0, buf.Length);
                }
            }

            public void Import(FileStream fs)
            {
                byte[] buf = new byte[System.Runtime.InteropServices.Marshal.SizeOf(typeof(Dummy.Keybinding.Event))];

                edown.Clear();
                eup.Clear();
                eheld.Clear();

                byte cnt = (byte)fs.ReadByte();
                for(int i = 0; i != cnt; i++)
                {
                    fs.Read(buf, 0, buf.Length);
                    edown.Add(NativeInput.byte2struct<Dummy.Keybinding.Event>(buf));
                }

                cnt = (byte)fs.ReadByte();
                for(int i = 0; i != cnt; i++)
                {
                    fs.Read(buf, 0, buf.Length);
                    eup.Add(NativeInput.byte2struct<Dummy.Keybinding.Event>(buf));
                }

                cnt = (byte)fs.ReadByte();
                for(int i = 0; i != cnt; i++)
                {
                    fs.Read(buf, 0, buf.Length);
                    eheld.Add(NativeInput.byte2struct<Dummy.Keybinding.Event>(buf));
                }
            }

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

            List<byte> obuf = new List<byte>();
            byte[] buf = new byte[0x1000];

            int timeout = 0;
            Boolean connected = false;

            int recvret = -1;

            Int16 px = 0, py = 0;

            short dacx = 0, dacy = 0;

            while(running)
            {
                if(imgbuf != null)
                {
                    int offs = 0;
                    int boffs = 0;
                    int mustread = imgbuf.Length;
                    int remain;

                    while(mustread > 0)
                    {
                        remain = Math.Min(mustread, 240 * 3 * 4);

                        obuf.Clear();
                        obuf.Add(3); //PacketID (SCREENSHOT)
                        obuf.Add(0); //altkey (dummy)
                        obuf.Add(0); //padding1
                        obuf.Add(0); //padding2
                        obuf.Add((byte)(offs & 0xFF)); //offs1
                        obuf.Add((byte)((offs >> 8) & 0xFF)); //offs2

                        //too inefficient, but works /shrug
                        int i = 0;
                        while(i != remain)
                        {
                            obuf.Add(imgbuf[boffs + i++]);
                        }

                        boffs += remain;
                        mustread -= remain;
                        offs++;

                        sock.SendTo(obuf.ToArray(), sockaddr_in);
                        if(mustread > 0) System.Threading.Thread.Sleep(20);
                    }

                    imgbuf = null;
                }

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
                    obuf.Add(1); //extdata (osu!C compatible flag)
                    obuf.Add(0); //padding
                    obuf.Add((byte)((altkey >>  0) & 0xFF)); //altkey1
                    obuf.Add((byte)((altkey >>  8) & 0xFF)); //altkey2
                    obuf.Add((byte)((altkey >> 16) & 0xFF)); //altkey3
                    obuf.Add((byte)((altkey >> 24) & 0xFF)); //altkey4
                    Console.WriteLine("Sending ping packet");
                    sock.SendTo(obuf.ToArray(), sockaddr_in);
                    continue;
                }

                if(sock.Poll(0, SelectMode.SelectError))
                {
                    Object obj = sock.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Error);
                    Console.WriteLine("Error with type " + obj.GetType().FullName + " received");
                    continue;
                }

                try
                {
                    recvret = sock.ReceiveFrom(buf, ref dummyaddr_in);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    continue;
                }

                if(recvret <= 0) continue;


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

                        if(cal == null)
                        {
                            obuf.Clear();
                            obuf.Add(0x7D); //PacketID TouchCalEx
                            obuf.Add(0); //altkey (dummy)
                            obuf.Add(1); //extdata (osu!C compatible flag)
                            obuf.Add(0); //padding
                            Console.WriteLine("Sending ping packet");
                            sock.SendTo(obuf.ToArray(), sockaddr_in);
                        }
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

                        if(debug) Console.WriteLine("[IN] K: " + currkey.ToString("X8") + " T: " + tx.ToString("+000;-000;0000") + "x" + ty.ToString("+000;-000;0000") + " C: " + cx.ToString("+000;-000;0000") + "x" + cy.ToString("+000;-000;0000") + " S: " + sx.ToString("+000;-000;0000") + "x" + sy.ToString("+000;-000;0000"));

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
                        if((kheld & (1 << 20)) != 0) //KEY_TOUCH
                        {
                            if((mmode & 4) == 0)
                            {
                                if(abs)
                                {
                                    NativeInput.POINT pt;
                                    pt.X = 0;
                                    pt.Y = 0;

                                    NativeInput.RECT rect;

                                    if(hwnd == IntPtr.Zero)
                                        rect = Screen.PrimaryScreen.Bounds;
                                    else
                                        NativeInput.GetClientRect(hwnd, out rect);

                                    pt.X = rect.Left;
                                    pt.Y = rect.Top;
                                    pt.X = +(int)((tx * rect.Width) / 320.0F);
                                    pt.Y = +(int)((ty * rect.Height) / 240.0F);


                                    NativeInput.ClientToScreen(hwnd, ref pt);

                                    //NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE | NativeInput.MouseEventFlags.MOVE_ABS), pt.X, pt.Y, 0, 0);
                                    Cursor.Position = pt;
                                }
                                else
                                    NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), (tx - px) * currspeed, (ty - py) * currspeed, 0, 0);
                            }

                            px = tx;
                            py = ty;

                            if((kdown & (1 << 20)) != 0)
                            {
                                if(altcmd != 0)
                                {
                                    Rectangle cur = new Rectangle(tx, ty, 1, 1);
                                    foreach(Dummy.RektButton rekt in rekts)
                                    {
                                        if(rekt.rekt.IntersectsWith(cur))
                                        {
                                            currekt = rekt;
                                            ProcessKDown(currekt.kb);
                                            break;
                                        }
                                    }
                                }
                            }
                            else if(currekt != null) ProcessKHeld(currekt.kb);
                        }
                        else if((kup & (1 << 20)) != 0) //KEY_TOUCH
                        {
                            px = 0;
                            py = 0;

                            if(currekt != null)
                            {
                                ProcessKUp(currekt.kb);
                                currekt = null;
                            }
                        }

                        //TODO config option

                        if((mmode & 1) == 1) NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), cx * currspeed / divx, -cy * currspeed / divy, 0, 0);
                        if((mmode & 2) == 2) NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), sx * currspeed / divx, -sy * currspeed / divy, 0, 0);

                        break;

                    case 3: //SCREENSHOT (unused)
                        break;

                    case 0x7D: //TouchCalEx (osu!C)
                        if(recvret == 8)
                        {
                            if(iscal)
                            {
                                iscal = false;
                                break;
                            }
                            MessageBox.Show("Failed to get CAL: " + (buf[4] | (buf[5] << 8) | (buf[6] << 16) | (buf[7] << 24)).ToString("X8"), "CAL error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if(cal == null && !iscal)
                            {
                                iscal = true;
                                //TODO: cal
                                //imgbuf = new byte[240 * 320 * 3];
                            }
                            break;
                        }
                        if(recvret != 0x14)
                        {
                            MessageBox.Show("Invalid CAL response size " + recvret.ToString("X8"), "CAL error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        if(cal == null) cal = new short[8];
                        cal[2] = (short)(buf[ 4] | (buf[ 5] << 8));
                        cal[3] = (short)(buf[ 6] | (buf[ 7] << 8));
                        cal[0] = (short)(buf[ 8] | (buf[ 9] << 8));
                        cal[1] = (short)(buf[10] | (buf[11] << 8));
                        cal[6] = (short)(buf[12] | (buf[13] << 8));
                        cal[7] = (short)(buf[14] | (buf[15] << 8));
                        cal[4] = (short)(buf[16] | (buf[17] << 8));
                        cal[5] = (short)(buf[18] | (buf[19] << 8));
                        iscal = false;

                        MessageBox.Show
                        (
                            "CAL:\r\n" +
                            cal[0].ToString() + ";" + cal[1].ToString() + " --> " + cal[2].ToString() + ";" + cal[3].ToString() + "\r\n" +
                            cal[4].ToString() + ";" + cal[5].ToString() + " --> " + cal[6].ToString() + ";" + cal[7].ToString()
                        );

                        break;

                    case 0x7E: //KeyDownEx (osu!C)
                        altcmd = buf[1];
                        currkey = buf[4] | (buf[5] << 8) | (buf[6] << 16) | (buf[7] << 24);

                        //if(debug) Console.WriteLine("[KX] K: " + currkey.ToString("X8"));

                        kdown = currkey & ~kheld;
                        kup = ~currkey & kheld;
                        kheld = currkey | (kheld & (1 << 20));

                        foreach(Keybinding k in bindings)
                        {
                            if(k == null) continue;
                            if(k.nth == 20) continue;

                            if((kdown & (1 << k.nth)) != 0) ProcessKDown(k);
                            else if((kheld & (1 << k.nth)) != 0) ProcessKHeld(k);
                            else if((kup & (1 << k.nth)) != 0) ProcessKUp(k);
                        }

                        break;

                    case 0x7F: //TouchEx (osu!C)
                        altcmd = buf[1];
                        bool istouch = ((buf[3] & 0x80) == 0) ? false : true;
                        short rtx = (short)(buf[4] | (buf[5] << 8));
                        short rty = (short)(buf[6] | (buf[7] << 8));

                        if(debug) Console.WriteLine("[TX] X: " + rtx.ToString("X4") + " Y: " + rty.ToString("X4"));

                        if(iscal)
                        {
                            if(!istouch) break;

                            if((kheld & 1) != 0)
                            {
                                cal[2] = rtx;
                                cal[3] = rty;
                            }
                            if((kheld & 2) != 0)
                            {
                                cal[6] = rtx;
                                cal[7] = rty;
                            }

                            break;
                        }

                        Boolean td =  istouch && ((kheld & (1 << 20)) == 0);
                        Boolean tu = !istouch && ((kheld & (1 << 20)) != 0);

                        if(istouch) //KEY_TOUCH
                        {
                            if(hwnd == IntPtr.Zero)
                            {
                                if(abs)
                                    NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE | NativeInput.MouseEventFlags.MOVE_ABS), (int)((rtx << 4) | (rtx >> 8)), ((rty << 4) | (rty >> 8)), 0, 0);
                                else
                                {
                                    short dx = (short)((rtx - dacx) / currspeed);
                                    short dy = (short)((rty - dacy) / currspeed);

                                    if(td)
                                    {
                                        dacx = rtx;
                                        dacy = rty;
                                    }
                                    else
                                    {
                                        NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE), (int)(dx), (int)(dy), 0, 0);

                                        if(dx != 0) dacx = rtx;
                                        if(dy != 0) dacy = rty;
                                    }
                                }
                            }
                            else
                            {
                                NativeInput.POINT pt;
                                pt.X = 0;
                                pt.Y = 0;

                                NativeInput.RECT rect;
                                NativeInput.GetClientRect(hwnd, out rect);

                                pt.X = rect.Left;
                                pt.Y = rect.Top;
                                pt.X += (int)((rtx * rect.Width) / 4096.0F);
                                pt.Y += (int)((rty * rect.Height) / 4096.0F);


                                NativeInput.ClientToScreen(hwnd, ref pt);
                                //NativeInput.mouse_event((int)(NativeInput.MouseEventFlags.MOVE | NativeInput.MouseEventFlags.MOVE_ABS), pt.X, pt.Y, 0, 0);
                                Cursor.Position = pt;
                            }

                            if(td)
                                ProcessKDown(bindings[20]);

                            ProcessKHeld(bindings[20]);
                        }
                        else if(tu) ProcessKUp(bindings[20]);

                        if(istouch)
                            kheld |=  (1 << 20);
                        else
                            kheld &= ~(1 << 20);

                        

                        break;

                    case 0x80: //JavaPing
                        sock.SendTo(new byte[] {0x80, 0, 1, 0}, sockaddr_in);
                        break;


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
            sock.Close();

            Console.WriteLine("Thread ended properly");
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
                    Console.WriteLine("speed set to " + currspeed);
                    break;

            }
        }

        public void SetKeybind(Button btn, int nth, IEnumerable<Event> edown, IEnumerable<Event> eup, IEnumerable<Event> eheld)
        {
            if(nth < 0 || nth > 31) return;

            bindings[nth] = new Keybinding()
            {
                btn = btn,
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
