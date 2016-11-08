using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarcusD._3DSCPlusDummy
{
    public partial class FormMain : Form
    {
        Dummy dmy = null;

        public FormMain()
        {
            InitializeComponent();

            dmy = new Dummy();

            int i = 0;
            dmy.SetKeybind(btnRebindA, lblKeyA, i++, null, null, null);
            dmy.SetKeybind(btnRebindB, lblKeyB, i++, null, null, null);
            dmy.SetKeybind(btnRebindSel, lblKeySel, i++, null, null, null);
            dmy.SetKeybind(btnRebindS, lblKeyS, i++, null, null, null);
            dmy.SetKeybind(btnRebindDR, lblKeyDR, i++, null, null, null);
            dmy.SetKeybind(btnRebindDL, lblKeyDL, i++, null, null, null);
            dmy.SetKeybind(btnRebindDU, lblKeyDU, i++, null, null, null);
            dmy.SetKeybind(btnRebindDD, lblKeyDD, i++, null, null, null);
            dmy.SetKeybind(btnRebindL, lblKeyL, i++, null, null, null);
            dmy.SetKeybind(btnRebindR, lblKeyR, i++, null, null, null);
            dmy.SetKeybind(btnRebindX, lblKeyX, i++, null, null, null);
            dmy.SetKeybind(btnRebindY, lblKeyY, i++, null, null, null);

            i += 2;
            dmy.SetKeybind(btnRebindZL, lblKeyZL, i++, null, null, null);
            dmy.SetKeybind(btnRebindZR, lblKeyZR, i++, null, null, null);

            i += 4;
            dmy.SetKeybind(btnRebindTouch, lblKeyTouch, i++, null, null, null);

            i += 3;
            dmy.SetKeybind(btnRebindSR, lblKeySR, i++, null, null, null);
            dmy.SetKeybind(btnRebindSL, lblKeySL, i++, null, null, null);
            dmy.SetKeybind(btnRebindSU, lblKeySU, i++, null, null, null);
            dmy.SetKeybind(btnRebindSD, lblKeySD, i++, null, null, null);
            dmy.SetKeybind(btnRebindCR, lblKeyCR, i++, null, null, null);
            dmy.SetKeybind(btnRebindCL, lblKeyCL, i++, null, null, null);
            dmy.SetKeybind(btnRebindCU, lblKeyCU, i++, null, null, null);
            dmy.SetKeybind(btnRebindCD, lblKeyCD, i++, null, null, null);

            if(i != 32) throw new Exception("invalid array size! got " + i);

            //TODO remove debug stuff
            // at least it works :P
            // wat

            dmy.bindings[9].edown.Add(new Dummy.Keybinding.Event() { evt = Dummy.Keybinding.Simutype.MEVT, mouseflags = NativeInput.MouseEventFlags.LDOWN });
            dmy.bindings[9].eup.Add(new Dummy.Keybinding.Event() { evt = Dummy.Keybinding.Simutype.MEVT, mouseflags = NativeInput.MouseEventFlags.LUP });
        }

        private void checkConnect_CheckedChanged(object sender, EventArgs e)
        {
            if(checkConnect.CheckState == CheckState.Checked)
            {
                checkConnect.CheckState = CheckState.Indeterminate;

                dmy.ipaddr = textIP.Text.Trim();
                dmy.port = (UInt16)numPort.Value;

                dmy.Start();
            }
            else if(checkConnect.CheckState == CheckState.Unchecked)
            {
                dmy.Stop();
            }
        }
    }
}
