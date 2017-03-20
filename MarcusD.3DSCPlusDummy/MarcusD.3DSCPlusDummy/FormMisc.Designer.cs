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
            // FormMisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkABS);
            this.Name = "FormMisc";
            this.Text = "FormMisc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkABS;
    }
}