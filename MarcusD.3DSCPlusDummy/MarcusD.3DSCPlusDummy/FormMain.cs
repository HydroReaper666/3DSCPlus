using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MarcusD.Util;

namespace MarcusD._3DSCPlusDummy
{
    public partial class FormMain : Form
    {
        Dummy dmy = null;

        String path = "3dsp.ini";

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
            Ini ini = new Ini("3dsp.ini");
            Ini.IniSection sect = null;

            sect = ini.GetSection("general");
            sect["IP"] = textIP.Text.Trim();
            sect["port"] = numPort.Value.ToString();

            KeyconfigExport(ini);
        }

        private void btnCfgLoad_Click(object sender, EventArgs e)
        {
            dmy.rekts.Clear();

            if (File.Exists("3dsp.bin"))
            {
                using (FileStream fs = File.OpenRead("3dsp.bin"))
                {
                    while (true)
                    {
                        byte nth = (byte)fs.ReadByte();
                        if (nth == 0xFF) break;

                        Dummy.Keybinding kb = dmy.bindings[nth];
                        kb.Import(fs);
                    }

                    int i = fs.ReadByte();

                    while (i > 0)
                    {
                        Dummy.RektButton rb = new Dummy.RektButton();
                        rb.Import(fs);
                        dmy.rekts.Add(rb);
                        i--;
                    }
                }

                File.Delete("3dsp.bin");

                btnCfgSave.PerformClick();
                btnCfgLoad.PerformClick();

                return;
            }

            Ini ini = new Ini("3dsp.ini");
            Ini.IniSection sect = null;

            sect = ini.GetSection("general");
            textIP.Text = sect.Read("IP", dmy.ipaddr);
            numPort.Value = (UInt16)sect.ReadInt("port", dmy.port);

            KeyconfigImport(ini);
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

        private void btnMisc_Click(object sender, EventArgs e)
        {
            using(FormMisc frm = new FormMisc(dmy))
            {
                frm.ShowDialog();
            }
        }

        void KeybindToIni(Ini.IniSection sect, Dummy.Keybinding kb)
        {
            if (kb == null) return;

            sect["edc"] = kb.edown.Count.ToString();
            for (int i = 0; i != kb.edown.Count; i++)
            {
                sect.WriteStruct<Dummy.Keybinding.Event>("edc" + i, kb.edown[i]);
            }

            sect["ehc"] = kb.eheld.Count.ToString();
            for (int i = 0; i != kb.eheld.Count; i++)
            {
                sect.WriteStruct<Dummy.Keybinding.Event>("ehc" + i, kb.eheld[i]);
            }

            sect["euc"] = kb.eup.Count.ToString();
            for (int i = 0; i != kb.eup.Count; i++)
            {
                sect.WriteStruct<Dummy.Keybinding.Event>("euc" + i, kb.eup[i]);
            }
        }

        void IniToKeybind(Ini.IniSection sect, Dummy.Keybinding kb)
        {
            if (kb == null) return;

            kb.edown.Clear();
            kb.eheld.Clear();
            kb.eup.Clear();

            int cnt = 0;

            cnt = sect.ReadInt("edc");
            for (int i = 0; i != cnt; i++)
            {
                kb.edown.Add(sect.ReadStruct<Dummy.Keybinding.Event>("edc" + i).Value);
            }

            cnt = sect.ReadInt("ehc");
            for (int i = 0; i != cnt; i++)
            {
                kb.eheld.Add(sect.ReadStruct<Dummy.Keybinding.Event>("ehc" + i).Value);
            }

            cnt = sect.ReadInt("euc");
            for (int i = 0; i != cnt; i++)
            {
                kb.eup.Add(sect.ReadStruct<Dummy.Keybinding.Event>("euc" + i).Value);
            }
        }

        private void KeyconfigImport(Ini ini)
        {
            Ini.IniSection sect = ini.GetSection("general");

            dmy.abs = sect.ReadInt("abs", dmy.abs ? 1 : 0) == 0 ? false : true;
            dmy.divx = sect.ReadInt("divx", dmy.divx);
            dmy.divy = sect.ReadInt("divy", dmy.divy);

            try
            {
                int wat = Convert.ToInt32(sect.Read("altk", ""), 16);
                dmy.altkey = wat;
            }
            catch { }

            dmy.mmode = sect.ReadInt("mmode", dmy.mmode);


            foreach(Dummy.Keybinding kb in dmy.bindings)
            {
                if(kb == null) continue;
                kb.edown.Clear();
                kb.eheld.Clear();
                kb.eup.Clear();
            }
            dmy.rekts.Clear();

            int cnt = sect.ReadInt("rekts");

            for(int i = 0; i != 32; i++)
            {
                sect = ini.GetSection("Keys/" + i);

                IniToKeybind(sect, dmy.bindings[i]);
            }

            for(int i = 0; i != cnt; i++)
            {
                sect = ini.GetSection("Rekt/" + i);

                Rectangle? rect = sect.ReadStruct<Rectangle>("bnd");
                if(!rect.HasValue) continue;

                Dummy.RektButton rekt = new Dummy.RektButton();
                rekt.kb = new Dummy.Keybinding();
                rekt.rekt = rect.Value;
                IniToKeybind(sect, rekt.kb);

                dmy.rekts.Add(rekt);
            }
        }

        private void KeyconfigExport(Ini ini)
        {
            Ini.IniSection sect = ini.GetSection("general");

            sect["abs"] = dmy.abs ? "1" : "0";
            sect["altkey"] = dmy.altkey.ToString("X8");
            sect["mmode"] = dmy.mmode.ToString();

            sect["rekts"] = dmy.rekts.Count.ToString();

            foreach(Dummy.Keybinding kb in dmy.bindings)
            {
                if(kb == null) continue;
                sect = ini.GetSection("Keys/" + kb.nth);

                KeybindToIni(sect, kb);
            }

            for(int i = 0; i != dmy.rekts.Count; i++)
            {
                sect = ini.GetSection("Rekt/" + i);

                sect.WriteStruct<Rectangle>("bnd", dmy.rekts[i].rekt);
                KeybindToIni(sect, dmy.rekts[i].kb);
            }
        }

        private void btnSubcfgSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.AutoUpgradeEnabled = true;
            sfd.CheckPathExists = true;
            sfd.DefaultExt = ".ini";
            sfd.DereferenceLinks = true;
            sfd.OverwritePrompt = true;
            sfd.ValidateNames = true;

            if(sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            Ini ini = new Ini(sfd.FileName);

            KeyconfigExport(ini);
        }

        private void btnSubcfgLoad_Click(object sender, EventArgs e)
        {
            if(dmy.running) return;

            OpenFileDialog sfd = new OpenFileDialog();
            sfd.AddExtension = true;
            sfd.AutoUpgradeEnabled = true;
            sfd.CheckFileExists = true;
            sfd.DefaultExt = ".ini";
            sfd.DereferenceLinks = true;
            sfd.ReadOnlyChecked = true;
            sfd.ValidateNames = true;

            if(sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            Ini ini = new Ini(sfd.FileName);

            KeyconfigImport(ini);
        }
    }
}
