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
    public partial class FormBuilder : Form
    {
        List<Dummy.Keybinding.Event> kdown;
        List<Dummy.Keybinding.Event> kup;
        List<Dummy.Keybinding.Event> kheld;

        List<Dummy.Keybinding.Event> curr;

        public FormBuilder(String title, List<Dummy.Keybinding.Event> kdown, List<Dummy.Keybinding.Event> kup, List<Dummy.Keybinding.Event> kheld)
        {
            InitializeComponent();

            this.Text = title + " - " + this.Text;

            this.kdown = kdown;
            this.kup = kup;
            this.kheld = kheld;

            this.curr = kdown;

            foreach(NativeInput.KeyScan k in Enum.GetValues(typeof(NativeInput.KeyScan)))
            {
                listKeys.Items.Add(k);
            }

            selType.SelectedIndex = 0;
        }

        void ItemRefresh()
        {
            listEvents.Items.Clear();

            foreach(Dummy.Keybinding.Event evt in curr)
            {
                listEvents.Items.Add(evt);
            }
        }

        private void selType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(selType.SelectedIndex)
            {
                case 1:
                    curr = kup;
                    break;
                case 2:
                    curr = kheld;
                    break;
                default:
                    curr = kdown;
                    break;
            }

            ItemRefresh(); //too lazy
        }

        private void listEvents_DoubleClick(object sender, EventArgs e)
        {
            if(listEvents.SelectedIndex == -1) return;
            curr.RemoveAt(listEvents.SelectedIndex);
            ItemRefresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            curr.Clear();
            ItemRefresh();
        }

        private void tabEvtsel_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnQueue.Enabled = tabEvtsel.SelectedIndex > 0;
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            switch(tabEvtsel.SelectedIndex)
            {
                case 1: //mouse
                    //TODO mouse buttons
                    curr.Add(new Dummy.Keybinding.Event() { evt = (checkAbsmov.Checked ? Dummy.Keybinding.Simutype.MABS : Dummy.Keybinding.Simutype.MREL), mousex = (short)numMouseX.Value, mousey = (short)numMouseY.Value });
                    break;

                case 2: //mouse speed
                    curr.Add(new Dummy.Keybinding.Event() { evt = Dummy.Keybinding.Simutype.M_MSPEED, mousepos = (int)numMspeed.Value });
                    break;

                default: break; //nope
            }
        }
    }
}
