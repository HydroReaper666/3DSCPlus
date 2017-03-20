namespace MarcusD._3DSCPlusDummy
{
    partial class FormMain
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
            this.labelDummyIP = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.checkConnect = new System.Windows.Forms.CheckBox();
            this.btnRebindA = new System.Windows.Forms.Button();
            this.btnRebindB = new System.Windows.Forms.Button();
            this.btnRebindS = new System.Windows.Forms.Button();
            this.btnRebindSel = new System.Windows.Forms.Button();
            this.btnRebindDR = new System.Windows.Forms.Button();
            this.btnRebindDL = new System.Windows.Forms.Button();
            this.btnRebindDU = new System.Windows.Forms.Button();
            this.btnRebindDD = new System.Windows.Forms.Button();
            this.btnRebindL = new System.Windows.Forms.Button();
            this.btnRebindR = new System.Windows.Forms.Button();
            this.btnRebindX = new System.Windows.Forms.Button();
            this.btnRebindY = new System.Windows.Forms.Button();
            this.btnRebindTouch = new System.Windows.Forms.Button();
            this.btnRebindZR = new System.Windows.Forms.Button();
            this.btnRebindZL = new System.Windows.Forms.Button();
            this.btnRebindCD = new System.Windows.Forms.Button();
            this.btnRebindCU = new System.Windows.Forms.Button();
            this.btnRebindCL = new System.Windows.Forms.Button();
            this.btnRebindCR = new System.Windows.Forms.Button();
            this.btnRebindSD = new System.Windows.Forms.Button();
            this.btnRebindSU = new System.Windows.Forms.Button();
            this.btnRebindSL = new System.Windows.Forms.Button();
            this.btnRebindSR = new System.Windows.Forms.Button();
            this.btnCfgSave = new System.Windows.Forms.Button();
            this.btnCfgLoad = new System.Windows.Forms.Button();
            this.btnAltEditor = new System.Windows.Forms.Button();
            this.btnMisc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDummyIP
            // 
            this.labelDummyIP.AutoSize = true;
            this.labelDummyIP.Location = new System.Drawing.Point(12, 9);
            this.labelDummyIP.Name = "labelDummyIP";
            this.labelDummyIP.Size = new System.Drawing.Size(20, 13);
            this.labelDummyIP.TabIndex = 0;
            this.labelDummyIP.Text = "IP:";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(38, 6);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(186, 20);
            this.textIP.TabIndex = 1;
            this.textIP.Text = "10.0.0.104";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(230, 6);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(67, 20);
            this.numPort.TabIndex = 2;
            this.numPort.Value = new decimal(new int[] {
            6956,
            0,
            0,
            0});
            // 
            // checkConnect
            // 
            this.checkConnect.AutoSize = true;
            this.checkConnect.Location = new System.Drawing.Point(303, 8);
            this.checkConnect.Name = "checkConnect";
            this.checkConnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkConnect.Size = new System.Drawing.Size(66, 17);
            this.checkConnect.TabIndex = 3;
            this.checkConnect.Text = "Connect";
            this.checkConnect.UseVisualStyleBackColor = true;
            this.checkConnect.CheckedChanged += new System.EventHandler(this.checkConnect_CheckedChanged);
            // 
            // btnRebindA
            // 
            this.btnRebindA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindA.Location = new System.Drawing.Point(307, 192);
            this.btnRebindA.Name = "btnRebindA";
            this.btnRebindA.Size = new System.Drawing.Size(64, 24);
            this.btnRebindA.TabIndex = 4;
            this.btnRebindA.Text = "A";
            this.btnRebindA.UseMnemonic = false;
            this.btnRebindA.UseVisualStyleBackColor = false;
            // 
            // btnRebindB
            // 
            this.btnRebindB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindB.Location = new System.Drawing.Point(274, 222);
            this.btnRebindB.Name = "btnRebindB";
            this.btnRebindB.Size = new System.Drawing.Size(64, 24);
            this.btnRebindB.TabIndex = 4;
            this.btnRebindB.Text = "B";
            this.btnRebindB.UseMnemonic = false;
            this.btnRebindB.UseVisualStyleBackColor = false;
            // 
            // btnRebindS
            // 
            this.btnRebindS.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindS.Location = new System.Drawing.Point(237, 252);
            this.btnRebindS.Name = "btnRebindS";
            this.btnRebindS.Size = new System.Drawing.Size(64, 24);
            this.btnRebindS.TabIndex = 4;
            this.btnRebindS.Text = "START";
            this.btnRebindS.UseMnemonic = false;
            this.btnRebindS.UseVisualStyleBackColor = false;
            // 
            // btnRebindSel
            // 
            this.btnRebindSel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSel.Location = new System.Drawing.Point(78, 252);
            this.btnRebindSel.Name = "btnRebindSel";
            this.btnRebindSel.Size = new System.Drawing.Size(64, 24);
            this.btnRebindSel.TabIndex = 4;
            this.btnRebindSel.Text = "SELECT";
            this.btnRebindSel.UseMnemonic = false;
            this.btnRebindSel.UseVisualStyleBackColor = false;
            // 
            // btnRebindDR
            // 
            this.btnRebindDR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindDR.Location = new System.Drawing.Point(78, 192);
            this.btnRebindDR.Name = "btnRebindDR";
            this.btnRebindDR.Size = new System.Drawing.Size(64, 24);
            this.btnRebindDR.TabIndex = 4;
            this.btnRebindDR.Text = "DRight";
            this.btnRebindDR.UseMnemonic = false;
            this.btnRebindDR.UseVisualStyleBackColor = false;
            // 
            // btnRebindDL
            // 
            this.btnRebindDL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindDL.Location = new System.Drawing.Point(8, 192);
            this.btnRebindDL.Name = "btnRebindDL";
            this.btnRebindDL.Size = new System.Drawing.Size(64, 24);
            this.btnRebindDL.TabIndex = 4;
            this.btnRebindDL.Text = "DLeft";
            this.btnRebindDL.UseMnemonic = false;
            this.btnRebindDL.UseVisualStyleBackColor = false;
            // 
            // btnRebindDU
            // 
            this.btnRebindDU.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindDU.Location = new System.Drawing.Point(41, 162);
            this.btnRebindDU.Name = "btnRebindDU";
            this.btnRebindDU.Size = new System.Drawing.Size(64, 24);
            this.btnRebindDU.TabIndex = 4;
            this.btnRebindDU.Text = "DUp";
            this.btnRebindDU.UseMnemonic = false;
            this.btnRebindDU.UseVisualStyleBackColor = false;
            // 
            // btnRebindDD
            // 
            this.btnRebindDD.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindDD.Location = new System.Drawing.Point(41, 222);
            this.btnRebindDD.Name = "btnRebindDD";
            this.btnRebindDD.Size = new System.Drawing.Size(64, 24);
            this.btnRebindDD.TabIndex = 4;
            this.btnRebindDD.Text = "DDown";
            this.btnRebindDD.UseMnemonic = false;
            this.btnRebindDD.UseVisualStyleBackColor = false;
            // 
            // btnRebindL
            // 
            this.btnRebindL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindL.Location = new System.Drawing.Point(8, 48);
            this.btnRebindL.Name = "btnRebindL";
            this.btnRebindL.Size = new System.Drawing.Size(64, 24);
            this.btnRebindL.TabIndex = 4;
            this.btnRebindL.Text = "L";
            this.btnRebindL.UseMnemonic = false;
            this.btnRebindL.UseVisualStyleBackColor = false;
            // 
            // btnRebindR
            // 
            this.btnRebindR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindR.Location = new System.Drawing.Point(307, 48);
            this.btnRebindR.Name = "btnRebindR";
            this.btnRebindR.Size = new System.Drawing.Size(64, 24);
            this.btnRebindR.TabIndex = 4;
            this.btnRebindR.Text = "R";
            this.btnRebindR.UseMnemonic = false;
            this.btnRebindR.UseVisualStyleBackColor = false;
            // 
            // btnRebindX
            // 
            this.btnRebindX.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindX.Location = new System.Drawing.Point(274, 162);
            this.btnRebindX.Name = "btnRebindX";
            this.btnRebindX.Size = new System.Drawing.Size(64, 24);
            this.btnRebindX.TabIndex = 4;
            this.btnRebindX.Text = "X";
            this.btnRebindX.UseMnemonic = false;
            this.btnRebindX.UseVisualStyleBackColor = false;
            // 
            // btnRebindY
            // 
            this.btnRebindY.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindY.Location = new System.Drawing.Point(237, 192);
            this.btnRebindY.Name = "btnRebindY";
            this.btnRebindY.Size = new System.Drawing.Size(64, 24);
            this.btnRebindY.TabIndex = 4;
            this.btnRebindY.Text = "Y";
            this.btnRebindY.UseMnemonic = false;
            this.btnRebindY.UseVisualStyleBackColor = false;
            // 
            // btnRebindTouch
            // 
            this.btnRebindTouch.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindTouch.Location = new System.Drawing.Point(157, 252);
            this.btnRebindTouch.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindTouch.Name = "btnRebindTouch";
            this.btnRebindTouch.Size = new System.Drawing.Size(64, 24);
            this.btnRebindTouch.TabIndex = 4;
            this.btnRebindTouch.Text = "Touch";
            this.btnRebindTouch.UseMnemonic = false;
            this.btnRebindTouch.UseVisualStyleBackColor = false;
            // 
            // btnRebindZR
            // 
            this.btnRebindZR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindZR.Location = new System.Drawing.Point(237, 48);
            this.btnRebindZR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindZR.Name = "btnRebindZR";
            this.btnRebindZR.Size = new System.Drawing.Size(64, 24);
            this.btnRebindZR.TabIndex = 4;
            this.btnRebindZR.Text = "ZR";
            this.btnRebindZR.UseMnemonic = false;
            this.btnRebindZR.UseVisualStyleBackColor = false;
            // 
            // btnRebindZL
            // 
            this.btnRebindZL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindZL.Location = new System.Drawing.Point(78, 48);
            this.btnRebindZL.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindZL.Name = "btnRebindZL";
            this.btnRebindZL.Size = new System.Drawing.Size(64, 24);
            this.btnRebindZL.TabIndex = 4;
            this.btnRebindZL.Text = "ZL";
            this.btnRebindZL.UseMnemonic = false;
            this.btnRebindZL.UseVisualStyleBackColor = false;
            // 
            // btnRebindCD
            // 
            this.btnRebindCD.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCD.Location = new System.Drawing.Point(41, 135);
            this.btnRebindCD.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCD.Name = "btnRebindCD";
            this.btnRebindCD.Size = new System.Drawing.Size(64, 24);
            this.btnRebindCD.TabIndex = 6;
            this.btnRebindCD.Text = "CDown";
            this.btnRebindCD.UseMnemonic = false;
            this.btnRebindCD.UseVisualStyleBackColor = false;
            // 
            // btnRebindCU
            // 
            this.btnRebindCU.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCU.Location = new System.Drawing.Point(41, 75);
            this.btnRebindCU.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCU.Name = "btnRebindCU";
            this.btnRebindCU.Size = new System.Drawing.Size(64, 24);
            this.btnRebindCU.TabIndex = 6;
            this.btnRebindCU.Text = "CUp";
            this.btnRebindCU.UseMnemonic = false;
            this.btnRebindCU.UseVisualStyleBackColor = false;
            // 
            // btnRebindCL
            // 
            this.btnRebindCL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCL.Location = new System.Drawing.Point(8, 105);
            this.btnRebindCL.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCL.Name = "btnRebindCL";
            this.btnRebindCL.Size = new System.Drawing.Size(64, 24);
            this.btnRebindCL.TabIndex = 7;
            this.btnRebindCL.Text = "CLeft";
            this.btnRebindCL.UseMnemonic = false;
            this.btnRebindCL.UseVisualStyleBackColor = false;
            // 
            // btnRebindCR
            // 
            this.btnRebindCR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCR.Location = new System.Drawing.Point(78, 105);
            this.btnRebindCR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCR.Name = "btnRebindCR";
            this.btnRebindCR.Size = new System.Drawing.Size(64, 24);
            this.btnRebindCR.TabIndex = 8;
            this.btnRebindCR.Text = "CRight";
            this.btnRebindCR.UseMnemonic = false;
            this.btnRebindCR.UseVisualStyleBackColor = false;
            // 
            // btnRebindSD
            // 
            this.btnRebindSD.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSD.Location = new System.Drawing.Point(274, 135);
            this.btnRebindSD.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindSD.Name = "btnRebindSD";
            this.btnRebindSD.Size = new System.Drawing.Size(60, 24);
            this.btnRebindSD.TabIndex = 12;
            this.btnRebindSD.Text = "SDown";
            this.btnRebindSD.UseMnemonic = false;
            this.btnRebindSD.UseVisualStyleBackColor = false;
            // 
            // btnRebindSU
            // 
            this.btnRebindSU.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSU.Location = new System.Drawing.Point(274, 75);
            this.btnRebindSU.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindSU.Name = "btnRebindSU";
            this.btnRebindSU.Size = new System.Drawing.Size(60, 24);
            this.btnRebindSU.TabIndex = 13;
            this.btnRebindSU.Text = "SUp";
            this.btnRebindSU.UseMnemonic = false;
            this.btnRebindSU.UseVisualStyleBackColor = false;
            // 
            // btnRebindSL
            // 
            this.btnRebindSL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSL.Location = new System.Drawing.Point(237, 105);
            this.btnRebindSL.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindSL.Name = "btnRebindSL";
            this.btnRebindSL.Size = new System.Drawing.Size(64, 24);
            this.btnRebindSL.TabIndex = 14;
            this.btnRebindSL.Text = "SLeft";
            this.btnRebindSL.UseMnemonic = false;
            this.btnRebindSL.UseVisualStyleBackColor = false;
            // 
            // btnRebindSR
            // 
            this.btnRebindSR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSR.Location = new System.Drawing.Point(307, 105);
            this.btnRebindSR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindSR.Name = "btnRebindSR";
            this.btnRebindSR.Size = new System.Drawing.Size(64, 24);
            this.btnRebindSR.TabIndex = 15;
            this.btnRebindSR.Text = "SRight";
            this.btnRebindSR.UseMnemonic = false;
            this.btnRebindSR.UseVisualStyleBackColor = false;
            // 
            // btnCfgSave
            // 
            this.btnCfgSave.Location = new System.Drawing.Point(145, 48);
            this.btnCfgSave.Name = "btnCfgSave";
            this.btnCfgSave.Size = new System.Drawing.Size(89, 51);
            this.btnCfgSave.TabIndex = 16;
            this.btnCfgSave.Text = "Save config";
            this.btnCfgSave.UseVisualStyleBackColor = true;
            this.btnCfgSave.Click += new System.EventHandler(this.btnCfgSave_Click);
            // 
            // btnCfgLoad
            // 
            this.btnCfgLoad.Location = new System.Drawing.Point(145, 105);
            this.btnCfgLoad.Name = "btnCfgLoad";
            this.btnCfgLoad.Size = new System.Drawing.Size(89, 54);
            this.btnCfgLoad.TabIndex = 16;
            this.btnCfgLoad.Text = "Load config";
            this.btnCfgLoad.UseVisualStyleBackColor = true;
            this.btnCfgLoad.Click += new System.EventHandler(this.btnCfgLoad_Click);
            // 
            // btnAltEditor
            // 
            this.btnAltEditor.Location = new System.Drawing.Point(145, 162);
            this.btnAltEditor.Name = "btnAltEditor";
            this.btnAltEditor.Size = new System.Drawing.Size(89, 54);
            this.btnAltEditor.TabIndex = 16;
            this.btnAltEditor.Text = "ALT editor";
            this.btnAltEditor.UseVisualStyleBackColor = true;
            this.btnAltEditor.Click += new System.EventHandler(this.btnAltEditor_Click);
            // 
            // btnMisc
            // 
            this.btnMisc.Location = new System.Drawing.Point(145, 222);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(89, 23);
            this.btnMisc.TabIndex = 17;
            this.btnMisc.Text = "Misc settings";
            this.btnMisc.UseVisualStyleBackColor = true;
            this.btnMisc.Click += new System.EventHandler(this.btnMisc_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 282);
            this.Controls.Add(this.btnMisc);
            this.Controls.Add(this.btnAltEditor);
            this.Controls.Add(this.btnCfgLoad);
            this.Controls.Add(this.btnCfgSave);
            this.Controls.Add(this.btnRebindSD);
            this.Controls.Add(this.btnRebindCD);
            this.Controls.Add(this.btnRebindSU);
            this.Controls.Add(this.btnRebindTouch);
            this.Controls.Add(this.btnRebindSL);
            this.Controls.Add(this.btnRebindCU);
            this.Controls.Add(this.btnRebindSR);
            this.Controls.Add(this.btnRebindCL);
            this.Controls.Add(this.btnRebindZR);
            this.Controls.Add(this.btnRebindCR);
            this.Controls.Add(this.btnRebindDD);
            this.Controls.Add(this.btnRebindZL);
            this.Controls.Add(this.btnRebindDU);
            this.Controls.Add(this.btnRebindDL);
            this.Controls.Add(this.btnRebindDR);
            this.Controls.Add(this.btnRebindSel);
            this.Controls.Add(this.btnRebindS);
            this.Controls.Add(this.btnRebindB);
            this.Controls.Add(this.btnRebindY);
            this.Controls.Add(this.btnRebindX);
            this.Controls.Add(this.btnRebindR);
            this.Controls.Add(this.btnRebindL);
            this.Controls.Add(this.btnRebindA);
            this.Controls.Add(this.checkConnect);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.labelDummyIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "3DSController Plus Dummy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDummyIP;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.CheckBox checkConnect;
        private System.Windows.Forms.Button btnRebindA;
        private System.Windows.Forms.Button btnRebindB;
        private System.Windows.Forms.Button btnRebindS;
        private System.Windows.Forms.Button btnRebindSel;
        private System.Windows.Forms.Button btnRebindDR;
        private System.Windows.Forms.Button btnRebindDL;
        private System.Windows.Forms.Button btnRebindDU;
        private System.Windows.Forms.Button btnRebindDD;
        private System.Windows.Forms.Button btnRebindL;
        private System.Windows.Forms.Button btnRebindR;
        private System.Windows.Forms.Button btnRebindX;
        private System.Windows.Forms.Button btnRebindY;
        private System.Windows.Forms.Button btnRebindTouch;
        private System.Windows.Forms.Button btnRebindZR;
        private System.Windows.Forms.Button btnRebindZL;
        private System.Windows.Forms.Button btnRebindCU;
        private System.Windows.Forms.Button btnRebindCL;
        private System.Windows.Forms.Button btnRebindCR;
        private System.Windows.Forms.Button btnRebindCD;
        private System.Windows.Forms.Button btnRebindSD;
        private System.Windows.Forms.Button btnRebindSU;
        private System.Windows.Forms.Button btnRebindSL;
        private System.Windows.Forms.Button btnRebindSR;
        private System.Windows.Forms.Button btnCfgSave;
        private System.Windows.Forms.Button btnCfgLoad;
        private System.Windows.Forms.Button btnAltEditor;
        private System.Windows.Forms.Button btnMisc;
    }
}

