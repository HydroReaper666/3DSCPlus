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
    }
}
