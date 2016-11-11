using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MarcusD._3DSCPlusDummy
{
    public partial class FormAltedit : Form
    {
        enum Mode
        {
            SELECT,
            DEL,
            EDIT
        };

        Mode mode = Mode.SELECT;

        public byte[] imgbytes = null;

        List<Dummy.RektButton> rekts;

        Pen p = new Pen(Color.DarkCyan, 1.1F);
        Pen sp = new Pen(Color.DarkRed, 1.2F);

        int sx = -1, sy = -1, cx = 0, cy = 0;
        Boolean _seling = false;

        public FormAltedit(List<Dummy.RektButton> rekts)
        {
            InitializeComponent();

            this.rekts = rekts;

            imgAlt.Paint += imgAlt_Paint;
            imgAlt.MouseDown += imgAlt_MouseDown;
            imgAlt.MouseMove += imgAlt_MouseMove;
            imgAlt.MouseUp += imgAlt_MouseUp;
        }

        void imgAlt_MouseUp(object sender, MouseEventArgs e)
        {
            _seling = false;
            this.Invalidate(true);
        }

        void imgAlt_MouseMove(object sender, MouseEventArgs e)
        {
            if(!_seling) return;
            cx = e.X;
            cy = e.Y;
        }

        void imgAlt_MouseDown(object sender, MouseEventArgs e)
        {
            if(mode == Mode.SELECT)
            {
                _seling = true;
                sx = e.X;
                sy = e.Y;
                cx = sx;
                cy = sy;
            }
            else if(mode == Mode.DEL)
            {
                Dummy.RektButton sel = null;

                Rectangle cur = new Rectangle(e.X, e.Y, 1, 1);
                foreach(Dummy.RektButton rekt in rekts)
                {
                    if(rekt.rekt.IntersectsWith(cur))
                    {
                        sel = rekt;
                        break;
                    }
                }

                if(sel == null) return;

                if(MessageBox.Show("Are you sure you want to delet that?", "Confirmation", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) return;

                rekts.Remove(sel);
                this.Invalidate(true);
            }
            else if(mode == Mode.EDIT)
            {
                Dummy.RektButton sel = null;

                Rectangle cur = new Rectangle(e.X, e.Y, 1, 1);
                foreach(Dummy.RektButton rekt in rekts)
                {
                    if(rekt.rekt.IntersectsWith(cur))
                    {
                        sel = rekt;
                        break;
                    }
                }

                if(sel == null) return;

                using(FormBuilder fm = new FormBuilder("ALT", sel.kb.edown, sel.kb.eup, sel.kb.eheld))
                {
                    fm.ShowDialog();
                }
            }
        }

        void imgAlt_Paint(object sender, PaintEventArgs e)
        {
            foreach(Dummy.RektButton rekt in rekts)
            {
                e.Graphics.DrawRectangle(p, rekt.rekt);
            }

            int x, y, w, h;

            x = Math.Min(sx, cx);
            y = Math.Min(sy, cy);
            w = Math.Max(sx, cx) - x;
            h = Math.Max(sy, cy) - y;

            e.Graphics.DrawRectangle(sp, x, y, w, h);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            imgbytes = new byte[240 * 320 * 3];

            using(Bitmap bmp = new Bitmap(320, 240))
            {
                imgAlt.DrawToBitmap(bmp, new Rectangle(0, 0, 320, 240));
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                BitmapData bmpd = bmp.LockBits(new Rectangle(0, 0, 240, 320), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(bmpd.Scan0, imgbytes, 0, 240 * 320 * 3);
                bmp.UnlockBits(bmpd);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void radioToolSelect_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.SELECT;
        }

        private void radioToolDelet_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.DEL;
        }

        private void radioToolEdit_CheckedChanged(object sender, EventArgs e)
        {
            mode = Mode.EDIT;
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fd = new OpenFileDialog())
            {
                if(fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        Image img = Image.FromFile(fd.FileName);
                        imgAlt.BackgroundImage = img;
                    }
                    catch { }
                }
            }
        }

        private void btnBgsel_Click(object sender, EventArgs e)
        {
            using(ColorDialog cd = new ColorDialog())
            {
                if(cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imgAlt.BackColor = cd.Color;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(sx == -1) return;

            int x, y, w, h;

            x = Math.Min(sx, cx);
            y = Math.Min(sy, cy);
            w = Math.Max(sx, cx) - x;
            h = Math.Max(sy, cy) - y;

            rekts.Add(new Dummy.RektButton() { rekt = new Rectangle(x, y, w, h), kb = new Dummy.Keybinding() });

            sx = -1; sy = -1; cx = 0; cy = 0;
        }
    }
}
