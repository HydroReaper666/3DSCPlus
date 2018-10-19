namespace MarcusD._3DSCPlusDummy
{
    partial class FormMisc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkABS = new System.Windows.Forms.CheckBox();
            this.btnHwndProc = new System.Windows.Forms.Button();
            this.btnHwndNull = new System.Windows.Forms.Button();
            this.numProcOffs = new System.Windows.Forms.NumericUpDown();
            this.textProcess = new System.Windows.Forms.TextBox();
            this.numMovSpd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numProcOffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovSpd)).BeginInit();
            this.SuspendLayout();
            // 
            // checkABS
            // 
            this.checkABS.AutoSize = true;
            this.checkABS.Location = new System.Drawing.Point(12, 12);
            this.checkABS.Name = "checkABS";
            this.checkABS.Size = new System.Drawing.Size(93, 17);
            this.checkABS.TabIndex = 0;
            this.checkABS.Text = "Absolute input";
            this.checkABS.UseVisualStyleBackColor = true;
            this.checkABS.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnHwndProc
            // 
            this.btnHwndProc.Location = new System.Drawing.Point(179, 61);
            this.btnHwndProc.Name = "btnHwndProc";
            this.btnHwndProc.Size = new System.Drawing.Size(93, 20);
            this.btnHwndProc.TabIndex = 1;
            this.btnHwndProc.Text = "find process";
            this.btnHwndProc.UseVisualStyleBackColor = true;
            this.btnHwndProc.Click += new System.EventHandler(this.btnHwndProc_Click);
            // 
            // btnHwndNull
            // 
            this.btnHwndNull.Location = new System.Drawing.Point(179, 6);
            this.btnHwndNull.Name = "btnHwndNull";
            this.btnHwndNull.Size = new System.Drawing.Size(93, 23);
            this.btnHwndNull.TabIndex = 2;
            this.btnHwndNull.Text = "hwnd nullptr";
            this.btnHwndNull.UseVisualStyleBackColor = true;
            this.btnHwndNull.Click += new System.EventHandler(this.btnHwndNull_Click);
            // 
            // numProcOffs
            // 
            this.numProcOffs.Location = new System.Drawing.Point(12, 61);
            this.numProcOffs.Name = "numProcOffs";
            this.numProcOffs.Size = new System.Drawing.Size(161, 20);
            this.numProcOffs.TabIndex = 3;
            // 
            // textProcess
            // 
            this.textProcess.Location = new System.Drawing.Point(12, 35);
            this.textProcess.Name = "textProcess";
            this.textProcess.Size = new System.Drawing.Size(260, 20);
            this.textProcess.TabIndex = 4;
            this.textProcess.Text = "shacksu!";
            // 
            // numMovSpd
            // 
            this.numMovSpd.Location = new System.Drawing.Point(12, 87);
            this.numMovSpd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMovSpd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovSpd.Name = "numMovSpd";
            this.numMovSpd.Size = new System.Drawing.Size(260, 20);
            this.numMovSpd.TabIndex = 5;
            this.numMovSpd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovSpd.ValueChanged += new System.EventHandler(this.numMovSpd_ValueChanged);
            // 
            // FormMisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.numMovSpd);
            this.Controls.Add(this.textProcess);
            this.Controls.Add(this.numProcOffs);
            this.Controls.Add(this.btnHwndNull);
            this.Controls.Add(this.btnHwndProc);
            this.Controls.Add(this.checkABS);
            this.Name = "FormMisc";
            this.Text = "FormMisc";
            this.Load += new System.EventHandler(this.FormMisc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numProcOffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovSpd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkABS;
        private System.Windows.Forms.Button btnHwndProc;
        private System.Windows.Forms.Button btnHwndNull;
        private System.Windows.Forms.NumericUpDown numProcOffs;
        private System.Windows.Forms.TextBox textProcess;
        private System.Windows.Forms.NumericUpDown numMovSpd;
    }
}