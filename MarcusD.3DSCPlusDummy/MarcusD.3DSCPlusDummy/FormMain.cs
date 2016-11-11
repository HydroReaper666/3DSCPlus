using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MarcusD._3DSCPlusDummy
{
    public partial class FormMain : Form
    {
        Dummy dmy = null;

        String path = "3dsp.bin";

        public FormMain()
        {
            InitializeComponent();

            dmy = new Dummy();

            int i = 0;
            dmy.SetKeybind(btnRebindA, i++, null, null, null);
            dmy.SetKeybind(btnRebindB, i++, null, null, null);
            dmy.SetKeybind(btnRebindSel, i++, null, null, null);
            dmy.SetKeybind(btnRebindS, i++, null, null, null);
            dmy.SetKeybind(btnRebindDR, i++, null, null, null);
            dmy.SetKeybind(btnRebindDL, i++, null, null, null);
            dmy.SetKeybind(btnRebindDU, i++, null, null, null);
            dmy.SetKeybind(btnRebindDD, i++, null, null, null);
            dmy.SetKeybind(btnRebindR, i++, null, null, null);
            dmy.SetKeybind(btnRebindL, i++, null, null, null);
            dmy.SetKeybind(btnRebindX, i++, null, null, null);
            dmy.SetKeybind(btnRebindY, i++, null, null, null);

            i += 2;
            dmy.SetKeybind(btnRebindZL, i++, null, null, null);
            dmy.SetKeybind(btnRebindZR, i++, null, null, null);

            i += 4;
            dmy.SetKeybind(btnRebindTouch, i++, null, null, null);

            i += 3;
            dmy.SetKeybind(btnRebindSR, i++, null, null, null);
            dmy.SetKeybind(btnRebindSL, i++, null, null, null);
            dmy.SetKeybind(btnRebindSU, i++, null, null, null);
            dmy.SetKeybind(btnRebindSD, i++, null, null, null);
            dmy.SetKeybind(btnRebindCR, i++, null, null, null);
            dmy.SetKeybind(btnRebindCL, i++, null, null, null);
            dmy.SetKeybind(btnRebindCU, i++, null, null, null);
            dmy.SetKeybind(btnRebindCD, i++, null, null, null);

            if(i != 32) throw new Exception("invalid array size! got " + i);
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

        private void btnCfgSave_Click(object sender, EventArgs e)
        {
            using(FileStream fs = File.OpenWrite(path))
            {
                foreach(Dummy.Keybinding kb in dmy.bindings)
                {
                    if(kb == null) continue;
                    fs.WriteByte((byte)kb.nth);
                    kb.Export(fs);
                }

                fs.WriteByte(0xFF);

                fs.WriteByte((byte)dmy.rekts.Count);
                foreach(Dummy.RektButton rb in dmy.rekts)
                {
                    if(rb == null) continue;
                    rb.Export(fs);
                }
            }
        }

        private void btnCfgLoad_Click(object sender, EventArgs e)
        {
            if(!File.Exists(path)) return;
            using(FileStream fs = File.OpenRead(path))
            {
                while(true)
                {
                    byte nth = (byte)fs.ReadByte();
                    if(nth == 0xFF) break;

                    Dummy.Keybinding kb = dmy.bindings[nth];
                    kb.Import(fs);
                }

                dmy.rekts.Clear();

                int i = fs.ReadByte();
                
                while(i > 0)
                {
                    Dummy.RektButton rb = new Dummy.RektButton();
                    rb.Import(fs);
                    dmy.rekts.Add(rb);
                    i--;
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnCfgLoad.PerformClick();
        }

        private void btnAltEditor_Click(object sender, EventArgs e)
        {
            using(FormAltedit frm = new FormAltedit(dmy.rekts))
            {
                if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dmy.imgbuf = frm.imgbytes;
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkConnect.Checked = false;
        }
    }
}
