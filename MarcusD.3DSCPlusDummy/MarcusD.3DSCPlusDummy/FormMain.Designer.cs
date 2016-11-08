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
            this.lblKeyA = new System.Windows.Forms.Label();
            this.btnRebindB = new System.Windows.Forms.Button();
            this.btnRebindS = new System.Windows.Forms.Button();
            this.btnRebindSel = new System.Windows.Forms.Button();
            this.btnRebindDR = new System.Windows.Forms.Button();
            this.btnRebindDL = new System.Windows.Forms.Button();
            this.btnRebindDU = new System.Windows.Forms.Button();
            this.btnRebindDD = new System.Windows.Forms.Button();
            this.lblKeyB = new System.Windows.Forms.Label();
            this.lblKeySel = new System.Windows.Forms.Label();
            this.lblKeyS = new System.Windows.Forms.Label();
            this.lblKeyDR = new System.Windows.Forms.Label();
            this.lblKeyDL = new System.Windows.Forms.Label();
            this.lblKeyDU = new System.Windows.Forms.Label();
            this.lblKeyDD = new System.Windows.Forms.Label();
            this.btnRebindL = new System.Windows.Forms.Button();
            this.btnRebindR = new System.Windows.Forms.Button();
            this.btnRebindX = new System.Windows.Forms.Button();
            this.btnRebindY = new System.Windows.Forms.Button();
            this.lblKeyL = new System.Windows.Forms.Label();
            this.lblKeyR = new System.Windows.Forms.Label();
            this.lblKeyX = new System.Windows.Forms.Label();
            this.lblKeyY = new System.Windows.Forms.Label();
            this.tabButtons = new System.Windows.Forms.TabControl();
            this.tabSpecial = new System.Windows.Forms.TabPage();
            this.btnRebindTouch = new System.Windows.Forms.Button();
            this.btnRebindZR = new System.Windows.Forms.Button();
            this.btnRebindZL = new System.Windows.Forms.Button();
            this.lblKeyTouch = new System.Windows.Forms.Label();
            this.lblKeyZR = new System.Windows.Forms.Label();
            this.lblKeyZL = new System.Windows.Forms.Label();
            this.tabCPad = new System.Windows.Forms.TabPage();
            this.btnRebindCD = new System.Windows.Forms.Button();
            this.btnRebindCU = new System.Windows.Forms.Button();
            this.btnRebindCL = new System.Windows.Forms.Button();
            this.btnRebindCR = new System.Windows.Forms.Button();
            this.lblKeyCD = new System.Windows.Forms.Label();
            this.lblKeyCU = new System.Windows.Forms.Label();
            this.lblKeyCL = new System.Windows.Forms.Label();
            this.lblKeyCR = new System.Windows.Forms.Label();
            this.tabCStick = new System.Windows.Forms.TabPage();
            this.btnRebindSD = new System.Windows.Forms.Button();
            this.btnRebindSU = new System.Windows.Forms.Button();
            this.btnRebindSL = new System.Windows.Forms.Button();
            this.btnRebindSR = new System.Windows.Forms.Button();
            this.lblKeySD = new System.Windows.Forms.Label();
            this.lblKeySU = new System.Windows.Forms.Label();
            this.lblKeySL = new System.Windows.Forms.Label();
            this.lblKeySR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabButtons.SuspendLayout();
            this.tabSpecial.SuspendLayout();
            this.tabCPad.SuspendLayout();
            this.tabCStick.SuspendLayout();
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
            this.textIP.Text = "10.0.0.101";
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
            this.btnRebindA.Location = new System.Drawing.Point(8, 42);
            this.btnRebindA.Name = "btnRebindA";
            this.btnRebindA.Size = new System.Drawing.Size(64, 24);
            this.btnRebindA.TabIndex = 4;
            this.btnRebindA.Text = "A";
            this.btnRebindA.UseMnemonic = false;
            this.btnRebindA.UseVisualStyleBackColor = false;
            // 
            // lblKeyA
            // 
            this.lblKeyA.AutoSize = true;
            this.lblKeyA.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyA.Location = new System.Drawing.Point(78, 46);
            this.lblKeyA.Name = "lblKeyA";
            this.lblKeyA.Size = new System.Drawing.Size(35, 15);
            this.lblKeyA.TabIndex = 5;
            this.lblKeyA.Text = "None";
            // 
            // btnRebindB
            // 
            this.btnRebindB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindB.Location = new System.Drawing.Point(8, 72);
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
            this.btnRebindS.Location = new System.Drawing.Point(8, 132);
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
            this.btnRebindSel.Location = new System.Drawing.Point(8, 102);
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
            this.btnRebindDR.Location = new System.Drawing.Point(8, 162);
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
            this.btnRebindDU.Location = new System.Drawing.Point(8, 222);
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
            this.btnRebindDD.Location = new System.Drawing.Point(8, 252);
            this.btnRebindDD.Name = "btnRebindDD";
            this.btnRebindDD.Size = new System.Drawing.Size(64, 24);
            this.btnRebindDD.TabIndex = 4;
            this.btnRebindDD.Text = "DDown";
            this.btnRebindDD.UseMnemonic = false;
            this.btnRebindDD.UseVisualStyleBackColor = false;
            // 
            // lblKeyB
            // 
            this.lblKeyB.AutoSize = true;
            this.lblKeyB.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyB.Location = new System.Drawing.Point(78, 76);
            this.lblKeyB.Name = "lblKeyB";
            this.lblKeyB.Size = new System.Drawing.Size(35, 15);
            this.lblKeyB.TabIndex = 5;
            this.lblKeyB.Text = "None";
            // 
            // lblKeySel
            // 
            this.lblKeySel.AutoSize = true;
            this.lblKeySel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeySel.Location = new System.Drawing.Point(78, 106);
            this.lblKeySel.Name = "lblKeySel";
            this.lblKeySel.Size = new System.Drawing.Size(35, 15);
            this.lblKeySel.TabIndex = 5;
            this.lblKeySel.Text = "None";
            // 
            // lblKeyS
            // 
            this.lblKeyS.AutoSize = true;
            this.lblKeyS.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyS.Location = new System.Drawing.Point(78, 136);
            this.lblKeyS.Name = "lblKeyS";
            this.lblKeyS.Size = new System.Drawing.Size(35, 15);
            this.lblKeyS.TabIndex = 5;
            this.lblKeyS.Text = "None";
            // 
            // lblKeyDR
            // 
            this.lblKeyDR.AutoSize = true;
            this.lblKeyDR.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyDR.Location = new System.Drawing.Point(78, 166);
            this.lblKeyDR.Name = "lblKeyDR";
            this.lblKeyDR.Size = new System.Drawing.Size(35, 15);
            this.lblKeyDR.TabIndex = 5;
            this.lblKeyDR.Text = "None";
            // 
            // lblKeyDL
            // 
            this.lblKeyDL.AutoSize = true;
            this.lblKeyDL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyDL.Location = new System.Drawing.Point(78, 196);
            this.lblKeyDL.Name = "lblKeyDL";
            this.lblKeyDL.Size = new System.Drawing.Size(35, 15);
            this.lblKeyDL.TabIndex = 5;
            this.lblKeyDL.Text = "None";
            // 
            // lblKeyDU
            // 
            this.lblKeyDU.AutoSize = true;
            this.lblKeyDU.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyDU.Location = new System.Drawing.Point(78, 226);
            this.lblKeyDU.Name = "lblKeyDU";
            this.lblKeyDU.Size = new System.Drawing.Size(35, 15);
            this.lblKeyDU.TabIndex = 5;
            this.lblKeyDU.Text = "None";
            // 
            // lblKeyDD
            // 
            this.lblKeyDD.AutoSize = true;
            this.lblKeyDD.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyDD.Location = new System.Drawing.Point(78, 256);
            this.lblKeyDD.Name = "lblKeyDD";
            this.lblKeyDD.Size = new System.Drawing.Size(35, 15);
            this.lblKeyDD.TabIndex = 5;
            this.lblKeyDD.Text = "None";
            // 
            // btnRebindL
            // 
            this.btnRebindL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindL.Location = new System.Drawing.Point(200, 42);
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
            this.btnRebindR.Location = new System.Drawing.Point(200, 72);
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
            this.btnRebindX.Location = new System.Drawing.Point(200, 102);
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
            this.btnRebindY.Location = new System.Drawing.Point(200, 132);
            this.btnRebindY.Name = "btnRebindY";
            this.btnRebindY.Size = new System.Drawing.Size(64, 24);
            this.btnRebindY.TabIndex = 4;
            this.btnRebindY.Text = "Y";
            this.btnRebindY.UseMnemonic = false;
            this.btnRebindY.UseVisualStyleBackColor = false;
            // 
            // lblKeyL
            // 
            this.lblKeyL.AutoSize = true;
            this.lblKeyL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyL.Location = new System.Drawing.Point(270, 46);
            this.lblKeyL.Name = "lblKeyL";
            this.lblKeyL.Size = new System.Drawing.Size(35, 15);
            this.lblKeyL.TabIndex = 5;
            this.lblKeyL.Text = "None";
            // 
            // lblKeyR
            // 
            this.lblKeyR.AutoSize = true;
            this.lblKeyR.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyR.Location = new System.Drawing.Point(270, 76);
            this.lblKeyR.Name = "lblKeyR";
            this.lblKeyR.Size = new System.Drawing.Size(35, 15);
            this.lblKeyR.TabIndex = 5;
            this.lblKeyR.Text = "None";
            // 
            // lblKeyX
            // 
            this.lblKeyX.AutoSize = true;
            this.lblKeyX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyX.Location = new System.Drawing.Point(270, 106);
            this.lblKeyX.Name = "lblKeyX";
            this.lblKeyX.Size = new System.Drawing.Size(35, 15);
            this.lblKeyX.TabIndex = 5;
            this.lblKeyX.Text = "None";
            // 
            // lblKeyY
            // 
            this.lblKeyY.AutoSize = true;
            this.lblKeyY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyY.Location = new System.Drawing.Point(270, 136);
            this.lblKeyY.Name = "lblKeyY";
            this.lblKeyY.Size = new System.Drawing.Size(35, 15);
            this.lblKeyY.TabIndex = 5;
            this.lblKeyY.Text = "None";
            // 
            // tabButtons
            // 
            this.tabButtons.Controls.Add(this.tabSpecial);
            this.tabButtons.Controls.Add(this.tabCPad);
            this.tabButtons.Controls.Add(this.tabCStick);
            this.tabButtons.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabButtons.Location = new System.Drawing.Point(200, 162);
            this.tabButtons.Name = "tabButtons";
            this.tabButtons.SelectedIndex = 0;
            this.tabButtons.Size = new System.Drawing.Size(182, 120);
            this.tabButtons.TabIndex = 6;
            // 
            // tabSpecial
            // 
            this.tabSpecial.Controls.Add(this.btnRebindTouch);
            this.tabSpecial.Controls.Add(this.btnRebindZR);
            this.tabSpecial.Controls.Add(this.btnRebindZL);
            this.tabSpecial.Controls.Add(this.lblKeyTouch);
            this.tabSpecial.Controls.Add(this.lblKeyZR);
            this.tabSpecial.Controls.Add(this.lblKeyZL);
            this.tabSpecial.Location = new System.Drawing.Point(4, 23);
            this.tabSpecial.Name = "tabSpecial";
            this.tabSpecial.Size = new System.Drawing.Size(174, 93);
            this.tabSpecial.TabIndex = 2;
            this.tabSpecial.Text = "Special";
            this.tabSpecial.UseVisualStyleBackColor = true;
            // 
            // btnRebindTouch
            // 
            this.btnRebindTouch.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindTouch.Location = new System.Drawing.Point(0, 45);
            this.btnRebindTouch.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindTouch.Name = "btnRebindTouch";
            this.btnRebindTouch.Size = new System.Drawing.Size(60, 24);
            this.btnRebindTouch.TabIndex = 4;
            this.btnRebindTouch.Text = "Touch";
            this.btnRebindTouch.UseMnemonic = false;
            this.btnRebindTouch.UseVisualStyleBackColor = false;
            // 
            // btnRebindZR
            // 
            this.btnRebindZR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindZR.Location = new System.Drawing.Point(0, 22);
            this.btnRebindZR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindZR.Name = "btnRebindZR";
            this.btnRebindZR.Size = new System.Drawing.Size(60, 24);
            this.btnRebindZR.TabIndex = 4;
            this.btnRebindZR.Text = "ZR";
            this.btnRebindZR.UseMnemonic = false;
            this.btnRebindZR.UseVisualStyleBackColor = false;
            // 
            // btnRebindZL
            // 
            this.btnRebindZL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindZL.Location = new System.Drawing.Point(0, 0);
            this.btnRebindZL.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindZL.Name = "btnRebindZL";
            this.btnRebindZL.Size = new System.Drawing.Size(60, 24);
            this.btnRebindZL.TabIndex = 4;
            this.btnRebindZL.Text = "ZL";
            this.btnRebindZL.UseMnemonic = false;
            this.btnRebindZL.UseVisualStyleBackColor = false;
            // 
            // lblKeyTouch
            // 
            this.lblKeyTouch.AutoSize = true;
            this.lblKeyTouch.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyTouch.Location = new System.Drawing.Point(63, 49);
            this.lblKeyTouch.Name = "lblKeyTouch";
            this.lblKeyTouch.Size = new System.Drawing.Size(35, 15);
            this.lblKeyTouch.TabIndex = 5;
            this.lblKeyTouch.Text = "None";
            // 
            // lblKeyZR
            // 
            this.lblKeyZR.AutoSize = true;
            this.lblKeyZR.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyZR.Location = new System.Drawing.Point(63, 26);
            this.lblKeyZR.Name = "lblKeyZR";
            this.lblKeyZR.Size = new System.Drawing.Size(35, 15);
            this.lblKeyZR.TabIndex = 5;
            this.lblKeyZR.Text = "None";
            // 
            // lblKeyZL
            // 
            this.lblKeyZL.AutoSize = true;
            this.lblKeyZL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyZL.Location = new System.Drawing.Point(63, 4);
            this.lblKeyZL.Name = "lblKeyZL";
            this.lblKeyZL.Size = new System.Drawing.Size(35, 15);
            this.lblKeyZL.TabIndex = 5;
            this.lblKeyZL.Text = "None";
            // 
            // tabCPad
            // 
            this.tabCPad.Controls.Add(this.btnRebindCD);
            this.tabCPad.Controls.Add(this.btnRebindCU);
            this.tabCPad.Controls.Add(this.btnRebindCL);
            this.tabCPad.Controls.Add(this.btnRebindCR);
            this.tabCPad.Controls.Add(this.lblKeyCD);
            this.tabCPad.Controls.Add(this.lblKeyCU);
            this.tabCPad.Controls.Add(this.lblKeyCL);
            this.tabCPad.Controls.Add(this.lblKeyCR);
            this.tabCPad.Location = new System.Drawing.Point(4, 23);
            this.tabCPad.Name = "tabCPad";
            this.tabCPad.Size = new System.Drawing.Size(174, 93);
            this.tabCPad.TabIndex = 0;
            this.tabCPad.Text = "CirclePad";
            this.tabCPad.UseVisualStyleBackColor = true;
            // 
            // btnRebindCD
            // 
            this.btnRebindCD.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCD.Location = new System.Drawing.Point(0, 69);
            this.btnRebindCD.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCD.Name = "btnRebindCD";
            this.btnRebindCD.Size = new System.Drawing.Size(60, 24);
            this.btnRebindCD.TabIndex = 6;
            this.btnRebindCD.Text = "CDown";
            this.btnRebindCD.UseMnemonic = false;
            this.btnRebindCD.UseVisualStyleBackColor = false;
            // 
            // btnRebindCU
            // 
            this.btnRebindCU.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCU.Location = new System.Drawing.Point(0, 45);
            this.btnRebindCU.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCU.Name = "btnRebindCU";
            this.btnRebindCU.Size = new System.Drawing.Size(60, 24);
            this.btnRebindCU.TabIndex = 6;
            this.btnRebindCU.Text = "CUp";
            this.btnRebindCU.UseMnemonic = false;
            this.btnRebindCU.UseVisualStyleBackColor = false;
            // 
            // btnRebindCL
            // 
            this.btnRebindCL.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCL.Location = new System.Drawing.Point(0, 22);
            this.btnRebindCL.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCL.Name = "btnRebindCL";
            this.btnRebindCL.Size = new System.Drawing.Size(60, 24);
            this.btnRebindCL.TabIndex = 7;
            this.btnRebindCL.Text = "CLeft";
            this.btnRebindCL.UseMnemonic = false;
            this.btnRebindCL.UseVisualStyleBackColor = false;
            // 
            // btnRebindCR
            // 
            this.btnRebindCR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindCR.Location = new System.Drawing.Point(0, 0);
            this.btnRebindCR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindCR.Name = "btnRebindCR";
            this.btnRebindCR.Size = new System.Drawing.Size(60, 24);
            this.btnRebindCR.TabIndex = 8;
            this.btnRebindCR.Text = "CRight";
            this.btnRebindCR.UseMnemonic = false;
            this.btnRebindCR.UseVisualStyleBackColor = false;
            // 
            // lblKeyCD
            // 
            this.lblKeyCD.AutoSize = true;
            this.lblKeyCD.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyCD.Location = new System.Drawing.Point(63, 73);
            this.lblKeyCD.Name = "lblKeyCD";
            this.lblKeyCD.Size = new System.Drawing.Size(35, 15);
            this.lblKeyCD.TabIndex = 9;
            this.lblKeyCD.Text = "None";
            // 
            // lblKeyCU
            // 
            this.lblKeyCU.AutoSize = true;
            this.lblKeyCU.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyCU.Location = new System.Drawing.Point(63, 49);
            this.lblKeyCU.Name = "lblKeyCU";
            this.lblKeyCU.Size = new System.Drawing.Size(35, 15);
            this.lblKeyCU.TabIndex = 9;
            this.lblKeyCU.Text = "None";
            // 
            // lblKeyCL
            // 
            this.lblKeyCL.AutoSize = true;
            this.lblKeyCL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyCL.Location = new System.Drawing.Point(63, 26);
            this.lblKeyCL.Name = "lblKeyCL";
            this.lblKeyCL.Size = new System.Drawing.Size(35, 15);
            this.lblKeyCL.TabIndex = 10;
            this.lblKeyCL.Text = "None";
            // 
            // lblKeyCR
            // 
            this.lblKeyCR.AutoSize = true;
            this.lblKeyCR.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeyCR.Location = new System.Drawing.Point(63, 4);
            this.lblKeyCR.Name = "lblKeyCR";
            this.lblKeyCR.Size = new System.Drawing.Size(35, 15);
            this.lblKeyCR.TabIndex = 11;
            this.lblKeyCR.Text = "None";
            // 
            // tabCStick
            // 
            this.tabCStick.Controls.Add(this.btnRebindSD);
            this.tabCStick.Controls.Add(this.btnRebindSU);
            this.tabCStick.Controls.Add(this.btnRebindSL);
            this.tabCStick.Controls.Add(this.btnRebindSR);
            this.tabCStick.Controls.Add(this.lblKeySD);
            this.tabCStick.Controls.Add(this.lblKeySU);
            this.tabCStick.Controls.Add(this.lblKeySL);
            this.tabCStick.Controls.Add(this.lblKeySR);
            this.tabCStick.Location = new System.Drawing.Point(4, 23);
            this.tabCStick.Name = "tabCStick";
            this.tabCStick.Size = new System.Drawing.Size(174, 93);
            this.tabCStick.TabIndex = 1;
            this.tabCStick.Text = "CircleStick";
            this.tabCStick.UseVisualStyleBackColor = true;
            // 
            // btnRebindSD
            // 
            this.btnRebindSD.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSD.Location = new System.Drawing.Point(0, 69);
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
            this.btnRebindSU.Location = new System.Drawing.Point(0, 45);
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
            this.btnRebindSL.Location = new System.Drawing.Point(0, 22);
            this.btnRebindSL.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindSL.Name = "btnRebindSL";
            this.btnRebindSL.Size = new System.Drawing.Size(60, 24);
            this.btnRebindSL.TabIndex = 14;
            this.btnRebindSL.Text = "SLeft";
            this.btnRebindSL.UseMnemonic = false;
            this.btnRebindSL.UseVisualStyleBackColor = false;
            // 
            // btnRebindSR
            // 
            this.btnRebindSR.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRebindSR.Location = new System.Drawing.Point(0, 0);
            this.btnRebindSR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRebindSR.Name = "btnRebindSR";
            this.btnRebindSR.Size = new System.Drawing.Size(60, 24);
            this.btnRebindSR.TabIndex = 15;
            this.btnRebindSR.Text = "SRight";
            this.btnRebindSR.UseMnemonic = false;
            this.btnRebindSR.UseVisualStyleBackColor = false;
            // 
            // lblKeySD
            // 
            this.lblKeySD.AutoSize = true;
            this.lblKeySD.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeySD.Location = new System.Drawing.Point(63, 73);
            this.lblKeySD.Name = "lblKeySD";
            this.lblKeySD.Size = new System.Drawing.Size(35, 15);
            this.lblKeySD.TabIndex = 16;
            this.lblKeySD.Text = "None";
            // 
            // lblKeySU
            // 
            this.lblKeySU.AutoSize = true;
            this.lblKeySU.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeySU.Location = new System.Drawing.Point(63, 49);
            this.lblKeySU.Name = "lblKeySU";
            this.lblKeySU.Size = new System.Drawing.Size(35, 15);
            this.lblKeySU.TabIndex = 17;
            this.lblKeySU.Text = "None";
            // 
            // lblKeySL
            // 
            this.lblKeySL.AutoSize = true;
            this.lblKeySL.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeySL.Location = new System.Drawing.Point(63, 26);
            this.lblKeySL.Name = "lblKeySL";
            this.lblKeySL.Size = new System.Drawing.Size(35, 15);
            this.lblKeySL.TabIndex = 18;
            this.lblKeySL.Text = "None";
            // 
            // lblKeySR
            // 
            this.lblKeySR.AutoSize = true;
            this.lblKeySR.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeySR.Location = new System.Drawing.Point(63, 4);
            this.lblKeySR.Name = "lblKeySR";
            this.lblKeySR.Size = new System.Drawing.Size(35, 15);
            this.lblKeySR.TabIndex = 19;
            this.lblKeySR.Text = "None";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 282);
            this.Controls.Add(this.tabButtons);
            this.Controls.Add(this.lblKeyDD);
            this.Controls.Add(this.lblKeyDU);
            this.Controls.Add(this.lblKeyDL);
            this.Controls.Add(this.lblKeyDR);
            this.Controls.Add(this.lblKeyS);
            this.Controls.Add(this.lblKeySel);
            this.Controls.Add(this.lblKeyB);
            this.Controls.Add(this.lblKeyY);
            this.Controls.Add(this.lblKeyX);
            this.Controls.Add(this.lblKeyR);
            this.Controls.Add(this.lblKeyL);
            this.Controls.Add(this.lblKeyA);
            this.Controls.Add(this.btnRebindDD);
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
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabButtons.ResumeLayout(false);
            this.tabSpecial.ResumeLayout(false);
            this.tabSpecial.PerformLayout();
            this.tabCPad.ResumeLayout(false);
            this.tabCPad.PerformLayout();
            this.tabCStick.ResumeLayout(false);
            this.tabCStick.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDummyIP;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.CheckBox checkConnect;
        private System.Windows.Forms.Button btnRebindA;
        private System.Windows.Forms.Label lblKeyA;
        private System.Windows.Forms.Button btnRebindB;
        private System.Windows.Forms.Button btnRebindS;
        private System.Windows.Forms.Button btnRebindSel;
        private System.Windows.Forms.Button btnRebindDR;
        private System.Windows.Forms.Button btnRebindDL;
        private System.Windows.Forms.Button btnRebindDU;
        private System.Windows.Forms.Button btnRebindDD;
        private System.Windows.Forms.Label lblKeyB;
        private System.Windows.Forms.Label lblKeySel;
        private System.Windows.Forms.Label lblKeyS;
        private System.Windows.Forms.Label lblKeyDR;
        private System.Windows.Forms.Label lblKeyDL;
        private System.Windows.Forms.Label lblKeyDU;
        private System.Windows.Forms.Label lblKeyDD;
        private System.Windows.Forms.Button btnRebindL;
        private System.Windows.Forms.Button btnRebindR;
        private System.Windows.Forms.Button btnRebindX;
        private System.Windows.Forms.Button btnRebindY;
        private System.Windows.Forms.Label lblKeyL;
        private System.Windows.Forms.Label lblKeyR;
        private System.Windows.Forms.Label lblKeyX;
        private System.Windows.Forms.Label lblKeyY;
        private System.Windows.Forms.TabControl tabButtons;
        private System.Windows.Forms.TabPage tabSpecial;
        private System.Windows.Forms.TabPage tabCPad;
        private System.Windows.Forms.TabPage tabCStick;
        private System.Windows.Forms.Button btnRebindTouch;
        private System.Windows.Forms.Button btnRebindZR;
        private System.Windows.Forms.Button btnRebindZL;
        private System.Windows.Forms.Label lblKeyTouch;
        private System.Windows.Forms.Label lblKeyZR;
        private System.Windows.Forms.Label lblKeyZL;
        private System.Windows.Forms.Button btnRebindCU;
        private System.Windows.Forms.Button btnRebindCL;
        private System.Windows.Forms.Button btnRebindCR;
        private System.Windows.Forms.Label lblKeyCU;
        private System.Windows.Forms.Label lblKeyCL;
        private System.Windows.Forms.Label lblKeyCR;
        private System.Windows.Forms.Button btnRebindCD;
        private System.Windows.Forms.Label lblKeyCD;
        private System.Windows.Forms.Button btnRebindSD;
        private System.Windows.Forms.Button btnRebindSU;
        private System.Windows.Forms.Button btnRebindSL;
        private System.Windows.Forms.Button btnRebindSR;
        private System.Windows.Forms.Label lblKeySD;
        private System.Windows.Forms.Label lblKeySU;
        private System.Windows.Forms.Label lblKeySL;
        private System.Windows.Forms.Label lblKeySR;
    }
}

