using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarcusD._3DSCPlusDummy
{
    public partial class FormMisc : Form
    {
        Dummy dmy;

        public FormMisc(Dummy dmy)
        {
            this.dmy = dmy;

            InitializeComponent();

            checkABS.Checked = dmy.abs;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dmy.abs = checkABS.Checked;
        }

        private void btnHwndProc_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName(textProcess.Text);

            int offs = (int)numProcOffs.Value;
            if(offs >= proc.Length) offs = proc.Length - 1;
            if(offs != -1) dmy.hwnd = proc[offs].MainWindowHandle;
        }

        private void btnHwndNull_Click(object sender, EventArgs e)
        {
            dmy.hwnd = IntPtr.Zero;
        }
    }
}
