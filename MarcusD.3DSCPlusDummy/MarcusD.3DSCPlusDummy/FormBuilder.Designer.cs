namespace MarcusD._3DSCPlusDummy
{
    partial class FormBuilder
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
            this.tabEvtevt = new System.Windows.Forms.TabControl();
            this.tabCurrevents = new System.Windows.Forms.TabPage();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.tabBuilder = new System.Windows.Forms.TabPage();
            this.tabEvtsel = new System.Windows.Forms.TabControl();
            this.tabKey = new System.Windows.Forms.TabPage();
            this.listKeys = new System.Windows.Forms.ListBox();
            this.panelLayoutDummy2 = new System.Windows.Forms.Panel();
            this.btnKeyPress = new System.Windows.Forms.Button();
            this.btnKeyAuto = new System.Windows.Forms.Button();
            this.btnKeyRel = new System.Windows.Forms.Button();
            this.tabMouse = new System.Windows.Forms.TabPage();
            this.numMouseY = new System.Windows.Forms.NumericUpDown();
            this.numMouseX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkAbsmov = new System.Windows.Forms.CheckBox();
            this.tabMspeed = new System.Windows.Forms.TabPage();
            this.numMspeed = new System.Windows.Forms.NumericUpDown();
            this.btnQueue = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelLayoutDummy1 = new System.Windows.Forms.Panel();
            this.selType = new System.Windows.Forms.ComboBox();
            this.tabEvtevt.SuspendLayout();
            this.tabCurrevents.SuspendLayout();
            this.tabBuilder.SuspendLayout();
            this.tabEvtsel.SuspendLayout();
            this.tabKey.SuspendLayout();
            this.panelLayoutDummy2.SuspendLayout();
            this.tabMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseX)).BeginInit();
            this.tabMspeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMspeed)).BeginInit();
            this.panelLayoutDummy1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEvtevt
            // 
            this.tabEvtevt.Controls.Add(this.tabCurrevents);
            this.tabEvtevt.Controls.Add(this.tabBuilder);
            this.tabEvtevt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEvtevt.Location = new System.Drawing.Point(0, 21);
            this.tabEvtevt.Name = "tabEvtevt";
            this.tabEvtevt.SelectedIndex = 0;
            this.tabEvtevt.Size = new System.Drawing.Size(284, 218);
            this.tabEvtevt.TabIndex = 0;
            // 
            // tabCurrevents
            // 
            this.tabCurrevents.Controls.Add(this.listEvents);
            this.tabCurrevents.Location = new System.Drawing.Point(4, 22);
            this.tabCurrevents.Name = "tabCurrevents";
            this.tabCurrevents.Size = new System.Drawing.Size(276, 192);
            this.tabCurrevents.TabIndex = 0;
            this.tabCurrevents.Text = "Current Events";
            this.tabCurrevents.UseVisualStyleBackColor = true;
            // 
            // listEvents
            // 
            this.listEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEvents.FormattingEnabled = true;
            this.listEvents.Location = new System.Drawing.Point(0, 0);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(276, 192);
            this.listEvents.TabIndex = 0;
            this.listEvents.DoubleClick += new System.EventHandler(this.listEvents_DoubleClick);
            // 
            // tabBuilder
            // 
            this.tabBuilder.Controls.Add(this.tabEvtsel);
            this.tabBuilder.Controls.Add(this.btnQueue);
            this.tabBuilder.Location = new System.Drawing.Point(4, 22);
            this.tabBuilder.Name = "tabBuilder";
            this.tabBuilder.Size = new System.Drawing.Size(276, 192);
            this.tabBuilder.TabIndex = 1;
            this.tabBuilder.Text = "Add Events";
            this.tabBuilder.UseVisualStyleBackColor = true;
            // 
            // tabEvtsel
            // 
            this.tabEvtsel.Controls.Add(this.tabKey);
            this.tabEvtsel.Controls.Add(this.tabMouse);
            this.tabEvtsel.Controls.Add(this.tabMspeed);
            this.tabEvtsel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEvtsel.Location = new System.Drawing.Point(0, 0);
            this.tabEvtsel.Name = "tabEvtsel";
            this.tabEvtsel.SelectedIndex = 0;
            this.tabEvtsel.Size = new System.Drawing.Size(276, 166);
            this.tabEvtsel.TabIndex = 0;
            this.tabEvtsel.SelectedIndexChanged += new System.EventHandler(this.tabEvtsel_SelectedIndexChanged);
            // 
            // tabKey
            // 
            this.tabKey.Controls.Add(this.listKeys);
            this.tabKey.Controls.Add(this.panelLayoutDummy2);
            this.tabKey.Location = new System.Drawing.Point(4, 22);
            this.tabKey.Name = "tabKey";
            this.tabKey.Size = new System.Drawing.Size(268, 140);
            this.tabKey.TabIndex = 0;
            this.tabKey.Text = "Key";
            this.tabKey.UseVisualStyleBackColor = true;
            // 
            // listKeys
            // 
            this.listKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKeys.FormattingEnabled = true;
            this.listKeys.Location = new System.Drawing.Point(0, 0);
            this.listKeys.Name = "listKeys";
            this.listKeys.Size = new System.Drawing.Size(268, 113);
            this.listKeys.TabIndex = 2;
            // 
            // panelLayoutDummy2
            // 
            this.panelLayoutDummy2.Controls.Add(this.btnKeyPress);
            this.panelLayoutDummy2.Controls.Add(this.btnKeyAuto);
            this.panelLayoutDummy2.Controls.Add(this.btnKeyRel);
            this.panelLayoutDummy2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLayoutDummy2.Location = new System.Drawing.Point(0, 113);
            this.panelLayoutDummy2.Name = "panelLayoutDummy2";
            this.panelLayoutDummy2.Size = new System.Drawing.Size(268, 27);
            this.panelLayoutDummy2.TabIndex = 1;
            // 
            // btnKeyPress
            // 
            this.btnKeyPress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKeyPress.Location = new System.Drawing.Point(68, 0);
            this.btnKeyPress.Name = "btnKeyPress";
            this.btnKeyPress.Size = new System.Drawing.Size(130, 27);
            this.btnKeyPress.TabIndex = 0;
            this.btnKeyPress.Text = "Press";
            this.btnKeyPress.UseVisualStyleBackColor = true;
            // 
            // btnKeyAuto
            // 
            this.btnKeyAuto.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKeyAuto.Location = new System.Drawing.Point(198, 0);
            this.btnKeyAuto.Name = "btnKeyAuto";
            this.btnKeyAuto.Size = new System.Drawing.Size(70, 27);
            this.btnKeyAuto.TabIndex = 3;
            this.btnKeyAuto.Text = "Autopress";
            this.btnKeyAuto.UseVisualStyleBackColor = true;
            // 
            // btnKeyRel
            // 
            this.btnKeyRel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnKeyRel.Location = new System.Drawing.Point(0, 0);
            this.btnKeyRel.Name = "btnKeyRel";
            this.btnKeyRel.Size = new System.Drawing.Size(68, 27);
            this.btnKeyRel.TabIndex = 2;
            this.btnKeyRel.Text = "Release";
            this.btnKeyRel.UseVisualStyleBackColor = true;
            // 
            // tabMouse
            // 
            this.tabMouse.Controls.Add(this.numMouseY);
            this.tabMouse.Controls.Add(this.numMouseX);
            this.tabMouse.Controls.Add(this.label2);
            this.tabMouse.Controls.Add(this.label1);
            this.tabMouse.Controls.Add(this.checkAbsmov);
            this.tabMouse.Location = new System.Drawing.Point(4, 22);
            this.tabMouse.Name = "tabMouse";
            this.tabMouse.Size = new System.Drawing.Size(268, 140);
            this.tabMouse.TabIndex = 1;
            this.tabMouse.Text = "Mouse";
            this.tabMouse.UseVisualStyleBackColor = true;
            // 
            // numMouseY
            // 
            this.numMouseY.Location = new System.Drawing.Point(27, 25);
            this.numMouseY.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numMouseY.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.numMouseY.Name = "numMouseY";
            this.numMouseY.Size = new System.Drawing.Size(56, 20);
            this.numMouseY.TabIndex = 2;
            // 
            // numMouseX
            // 
            this.numMouseX.Location = new System.Drawing.Point(27, 3);
            this.numMouseX.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numMouseX.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.numMouseX.Name = "numMouseX";
            this.numMouseX.Size = new System.Drawing.Size(56, 20);
            this.numMouseX.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // checkAbsmov
            // 
            this.checkAbsmov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAbsmov.AutoSize = true;
            this.checkAbsmov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAbsmov.Location = new System.Drawing.Point(197, 3);
            this.checkAbsmov.Name = "checkAbsmov";
            this.checkAbsmov.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkAbsmov.Size = new System.Drawing.Size(64, 17);
            this.checkAbsmov.TabIndex = 0;
            this.checkAbsmov.Text = "Absolute";
            this.checkAbsmov.UseVisualStyleBackColor = true;
            // 
            // tabMspeed
            // 
            this.tabMspeed.Controls.Add(this.numMspeed);
            this.tabMspeed.Location = new System.Drawing.Point(4, 22);
            this.tabMspeed.Name = "tabMspeed";
            this.tabMspeed.Size = new System.Drawing.Size(268, 140);
            this.tabMspeed.TabIndex = 2;
            this.tabMspeed.Text = "Mouse speed";
            this.tabMspeed.UseVisualStyleBackColor = true;
            // 
            // numMspeed
            // 
            this.numMspeed.Dock = System.Windows.Forms.DockStyle.Top;
            this.numMspeed.Location = new System.Drawing.Point(0, 0);
            this.numMspeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMspeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numMspeed.Name = "numMspeed";
            this.numMspeed.Size = new System.Drawing.Size(268, 20);
            this.numMspeed.TabIndex = 0;
            // 
            // btnQueue
            // 
            this.btnQueue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQueue.Enabled = false;
            this.btnQueue.Location = new System.Drawing.Point(0, 166);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(276, 26);
            this.btnQueue.TabIndex = 1;
            this.btnQueue.Text = "Queue";
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnQueue.Click += new System.EventHandler(this.btnQueue_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(48, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 22);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 22);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelLayoutDummy1
            // 
            this.panelLayoutDummy1.Controls.Add(this.btnSave);
            this.panelLayoutDummy1.Controls.Add(this.btnClear);
            this.panelLayoutDummy1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLayoutDummy1.Location = new System.Drawing.Point(0, 239);
            this.panelLayoutDummy1.Name = "panelLayoutDummy1";
            this.panelLayoutDummy1.Size = new System.Drawing.Size(284, 22);
            this.panelLayoutDummy1.TabIndex = 3;
            // 
            // selType
            // 
            this.selType.Dock = System.Windows.Forms.DockStyle.Top;
            this.selType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selType.Items.AddRange(new object[] {
            "Key pressed",
            "Key released",
            "Key held"});
            this.selType.Location = new System.Drawing.Point(0, 0);
            this.selType.Name = "selType";
            this.selType.Size = new System.Drawing.Size(284, 21);
            this.selType.TabIndex = 4;
            this.selType.SelectedIndexChanged += new System.EventHandler(this.selType_SelectedIndexChanged);
            // 
            // FormBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabEvtevt);
            this.Controls.Add(this.selType);
            this.Controls.Add(this.panelLayoutDummy1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormBuilder";
            this.Text = "FormBuilder";
            this.tabEvtevt.ResumeLayout(false);
            this.tabCurrevents.ResumeLayout(false);
            this.tabBuilder.ResumeLayout(false);
            this.tabEvtsel.ResumeLayout(false);
            this.tabKey.ResumeLayout(false);
            this.panelLayoutDummy2.ResumeLayout(false);
            this.tabMouse.ResumeLayout(false);
            this.tabMouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseX)).EndInit();
            this.tabMspeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMspeed)).EndInit();
            this.panelLayoutDummy1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEvtevt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabCurrevents;
        private System.Windows.Forms.TabPage tabBuilder;
        private System.Windows.Forms.TabControl tabEvtsel;
        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelLayoutDummy1;
        private System.Windows.Forms.TabPage tabKey;
        private System.Windows.Forms.TabPage tabMouse;
        private System.Windows.Forms.ComboBox selType;
        private System.Windows.Forms.TabPage tabMspeed;
        private System.Windows.Forms.NumericUpDown numMspeed;
        private System.Windows.Forms.CheckBox checkAbsmov;
        private System.Windows.Forms.NumericUpDown numMouseX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMouseY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelLayoutDummy2;
        private System.Windows.Forms.Button btnKeyPress;
        private System.Windows.Forms.Button btnKeyAuto;
        private System.Windows.Forms.Button btnKeyRel;
        private System.Windows.Forms.ListBox listKeys;
        private System.Windows.Forms.ListBox listEvents;
    }
}