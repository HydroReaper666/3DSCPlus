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
            this.btnHwndOsu = new System.Windows.Forms.Button();
            this.btnHwndNull = new System.Windows.Forms.Button();
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
            // btnHwndOsu
            // 
            this.btnHwndOsu.Location = new System.Drawing.Point(12, 35);
            this.btnHwndOsu.Name = "btnHwndOsu";
            this.btnHwndOsu.Size = new System.Drawing.Size(93, 23);
            this.btnHwndOsu.TabIndex = 1;
            this.btnHwndOsu.Text = "find osu";
            this.btnHwndOsu.UseVisualStyleBackColor = true;
            this.btnHwndOsu.Click += new System.EventHandler(this.btnHwndOsu_Click);
            // 
            // btnHwndNull
            // 
            this.btnHwndNull.Location = new System.Drawing.Point(12, 64);
            this.btnHwndNull.Name = "btnHwndNull";
            this.btnHwndNull.Size = new System.Drawing.Size(93, 23);
            this.btnHwndNull.TabIndex = 2;
            this.btnHwndNull.Text = "hwnd nullptr";
            this.btnHwndNull.UseVisualStyleBackColor = true;
            this.btnHwndNull.Click += new System.EventHandler(this.btnHwndNull_Click);
            // 
            // FormMisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnHwndNull);
            this.Controls.Add(this.btnHwndOsu);
            this.Controls.Add(this.checkABS);
            this.Name = "FormMisc";
            this.Text = "FormMisc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkABS;
        private System.Windows.Forms.Button btnHwndOsu;
        private System.Windows.Forms.Button btnHwndNull;
    }
}