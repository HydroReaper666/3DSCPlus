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
            this.tabMouseEvent = new System.Windows.Forms.TabControl();
            this.tabMMove = new System.Windows.Forms.TabPage();
            this.tabMButton = new System.Windows.Forms.TabPage();
            this.tabMXbutton = new System.Windows.Forms.TabPage();
            this.tabMScroll = new System.Windows.Forms.TabPage();
            this.numScrollN = new System.Windows.Forms.NumericUpDown();
            this.checkScrollH = new System.Windows.Forms.CheckBox();
            this.checkXButtonDown = new System.Windows.Forms.CheckBox();
            this.checkXButtonUp = new System.Windows.Forms.CheckBox();
            this.numXButtonN = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkMBLD = new System.Windows.Forms.CheckBox();
            this.checkMBLU = new System.Windows.Forms.CheckBox();
            this.checkMBRD = new System.Windows.Forms.CheckBox();
            this.checkMBRU = new System.Windows.Forms.CheckBox();
            this.checkMBMD = new System.Windows.Forms.CheckBox();
            this.checkMBMU = new System.Windows.Forms.CheckBox();
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
            this.tabMouseEvent.SuspendLayout();
            this.tabMMove.SuspendLayout();
            this.tabMButton.SuspendLayout();
            this.tabMXbutton.SuspendLayout();
            this.tabMScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScrollN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXButtonN)).BeginInit();
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
            this.tabEvtevt.SelectedIndexChanged += new System.EventHandler(this.tabEvtevt_SelectedIndexChanged);
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
            this.tabMouse.Controls.Add(this.tabMouseEvent);
            this.tabMouse.Location = new System.Drawing.Point(4, 22);
            this.tabMouse.Name = "tabMouse";
            this.tabMouse.Size = new System.Drawing.Size(268, 140);
            this.tabMouse.TabIndex = 1;
            this.tabMouse.Text = "Mouse";
            this.tabMouse.UseVisualStyleBackColor = true;
            // 
            // numMouseY
            // 
            this.numMouseY.Location = new System.Drawing.Point(29, 24);
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
            this.numMouseX.Location = new System.Drawing.Point(29, 2);
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
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
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
            this.checkAbsmov.Location = new System.Drawing.Point(193, 5);
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
            // tabMouseEvent
            // 
            this.tabMouseEvent.Controls.Add(this.tabMMove);
            this.tabMouseEvent.Controls.Add(this.tabMButton);
            this.tabMouseEvent.Controls.Add(this.tabMXbutton);
            this.tabMouseEvent.Controls.Add(this.tabMScroll);
            this.tabMouseEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMouseEvent.Location = new System.Drawing.Point(0, 0);
            this.tabMouseEvent.Name = "tabMouseEvent";
            this.tabMouseEvent.SelectedIndex = 0;
            this.tabMouseEvent.Size = new System.Drawing.Size(268, 140);
            this.tabMouseEvent.TabIndex = 3;
            // 
            // tabMMove
            // 
            this.tabMMove.Controls.Add(this.numMouseY);
            this.tabMMove.Controls.Add(this.checkAbsmov);
            this.tabMMove.Controls.Add(this.label1);
            this.tabMMove.Controls.Add(this.numMouseX);
            this.tabMMove.Controls.Add(this.label2);
            this.tabMMove.Location = new System.Drawing.Point(4, 22);
            this.tabMMove.Name = "tabMMove";
            this.tabMMove.Size = new System.Drawing.Size(260, 114);
            this.tabMMove.TabIndex = 0;
            this.tabMMove.Text = "Move";
            this.tabMMove.UseVisualStyleBackColor = true;
            // 
            // tabMButton
            // 
            this.tabMButton.Controls.Add(this.checkMBMU);
            this.tabMButton.Controls.Add(this.checkMBRU);
            this.tabMButton.Controls.Add(this.checkMBLU);
            this.tabMButton.Controls.Add(this.checkMBMD);
            this.tabMButton.Controls.Add(this.checkMBRD);
            this.tabMButton.Controls.Add(this.checkMBLD);
            this.tabMButton.Controls.Add(this.label5);
            this.tabMButton.Controls.Add(this.label4);
            this.tabMButton.Controls.Add(this.label3);
            this.tabMButton.Location = new System.Drawing.Point(4, 22);
            this.tabMButton.Name = "tabMButton";
            this.tabMButton.Size = new System.Drawing.Size(260, 114);
            this.tabMButton.TabIndex = 1;
            this.tabMButton.Text = "Button";
            this.tabMButton.UseVisualStyleBackColor = true;
            // 
            // tabMXbutton
            // 
            this.tabMXbutton.Controls.Add(this.numXButtonN);
            this.tabMXbutton.Controls.Add(this.checkXButtonUp);
            this.tabMXbutton.Controls.Add(this.checkXButtonDown);
            this.tabMXbutton.Location = new System.Drawing.Point(4, 22);
            this.tabMXbutton.Name = "tabMXbutton";
            this.tabMXbutton.Size = new System.Drawing.Size(260, 114);
            this.tabMXbutton.TabIndex = 2;
            this.tabMXbutton.Text = "X button";
            this.tabMXbutton.UseVisualStyleBackColor = true;
            // 
            // tabMScroll
            // 
            this.tabMScroll.Controls.Add(this.checkScrollH);
            this.tabMScroll.Controls.Add(this.numScrollN);
            this.tabMScroll.Location = new System.Drawing.Point(4, 22);
            this.tabMScroll.Name = "tabMScroll";
            this.tabMScroll.Size = new System.Drawing.Size(260, 114);
            this.tabMScroll.TabIndex = 3;
            this.tabMScroll.Text = "Scroll";
            this.tabMScroll.UseVisualStyleBackColor = true;
            // 
            // numScrollN
            // 
            this.numScrollN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numScrollN.Increment = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numScrollN.Location = new System.Drawing.Point(3, 3);
            this.numScrollN.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numScrollN.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            -2147483648});
            this.numScrollN.Name = "numScrollN";
            this.numScrollN.Size = new System.Drawing.Size(178, 20);
            this.numScrollN.TabIndex = 0;
            // 
            // checkScrollH
            // 
            this.checkScrollH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkScrollH.AutoSize = true;
            this.checkScrollH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkScrollH.Location = new System.Drawing.Point(187, 3);
            this.checkScrollH.Name = "checkScrollH";
            this.checkScrollH.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkScrollH.Size = new System.Drawing.Size(70, 17);
            this.checkScrollH.TabIndex = 1;
            this.checkScrollH.Text = "Horizontal";
            this.checkScrollH.UseVisualStyleBackColor = true;
            // 
            // checkXButtonDown
            // 
            this.checkXButtonDown.AutoSize = true;
            this.checkXButtonDown.Location = new System.Drawing.Point(3, 3);
            this.checkXButtonDown.Name = "checkXButtonDown";
            this.checkXButtonDown.Size = new System.Drawing.Size(105, 17);
            this.checkXButtonDown.TabIndex = 0;
            this.checkXButtonDown.Text = "XButton_DOWN";
            this.checkXButtonDown.UseVisualStyleBackColor = true;
            // 
            // checkXButtonUp
            // 
            this.checkXButtonUp.AutoSize = true;
            this.checkXButtonUp.Location = new System.Drawing.Point(3, 26);
            this.checkXButtonUp.Name = "checkXButtonUp";
            this.checkXButtonUp.Size = new System.Drawing.Size(85, 17);
            this.checkXButtonUp.TabIndex = 0;
            this.checkXButtonUp.Text = "XButton_UP";
            this.checkXButtonUp.UseVisualStyleBackColor = true;
            // 
            // numXButtonN
            // 
            this.numXButtonN.Location = new System.Drawing.Point(3, 49);
            this.numXButtonN.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numXButtonN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numXButtonN.Name = "numXButtonN";
            this.numXButtonN.Size = new System.Drawing.Size(254, 20);
            this.numXButtonN.TabIndex = 1;
            this.numXButtonN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Left:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Right:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Middle:";
            // 
            // checkMBLD
            // 
            this.checkMBLD.AutoSize = true;
            this.checkMBLD.Location = new System.Drawing.Point(50, 3);
            this.checkMBLD.Name = "checkMBLD";
            this.checkMBLD.Size = new System.Drawing.Size(61, 17);
            this.checkMBLD.TabIndex = 1;
            this.checkMBLD.Text = "DOWN";
            this.checkMBLD.UseVisualStyleBackColor = true;
            // 
            // checkMBLU
            // 
            this.checkMBLU.AutoSize = true;
            this.checkMBLU.Location = new System.Drawing.Point(117, 3);
            this.checkMBLU.Name = "checkMBLU";
            this.checkMBLU.Size = new System.Drawing.Size(41, 17);
            this.checkMBLU.TabIndex = 1;
            this.checkMBLU.Text = "UP";
            this.checkMBLU.UseVisualStyleBackColor = true;
            // 
            // checkMBRD
            // 
            this.checkMBRD.AutoSize = true;
            this.checkMBRD.Location = new System.Drawing.Point(50, 26);
            this.checkMBRD.Name = "checkMBRD";
            this.checkMBRD.Size = new System.Drawing.Size(61, 17);
            this.checkMBRD.TabIndex = 1;
            this.checkMBRD.Text = "DOWN";
            this.checkMBRD.UseVisualStyleBackColor = true;
            // 
            // checkMBRU
            // 
            this.checkMBRU.AutoSize = true;
            this.checkMBRU.Location = new System.Drawing.Point(117, 26);
            this.checkMBRU.Name = "checkMBRU";
            this.checkMBRU.Size = new System.Drawing.Size(41, 17);
            this.checkMBRU.TabIndex = 1;
            this.checkMBRU.Text = "UP";
            this.checkMBRU.UseVisualStyleBackColor = true;
            // 
            // checkMBMD
            // 
            this.checkMBMD.AutoSize = true;
            this.checkMBMD.Location = new System.Drawing.Point(50, 48);
            this.checkMBMD.Name = "checkMBMD";
            this.checkMBMD.Size = new System.Drawing.Size(61, 17);
            this.checkMBMD.TabIndex = 1;
            this.checkMBMD.Text = "DOWN";
            this.checkMBMD.UseVisualStyleBackColor = true;
            // 
            // checkMBMU
            // 
            this.checkMBMU.AutoSize = true;
            this.checkMBMU.Location = new System.Drawing.Point(117, 48);
            this.checkMBMU.Name = "checkMBMU";
            this.checkMBMU.Size = new System.Drawing.Size(41, 17);
            this.checkMBMU.TabIndex = 1;
            this.checkMBMU.Text = "UP";
            this.checkMBMU.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.numMouseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouseX)).EndInit();
            this.tabMspeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMspeed)).EndInit();
            this.panelLayoutDummy1.ResumeLayout(false);
            this.tabMouseEvent.ResumeLayout(false);
            this.tabMMove.ResumeLayout(false);
            this.tabMMove.PerformLayout();
            this.tabMButton.ResumeLayout(false);
            this.tabMButton.PerformLayout();
            this.tabMXbutton.ResumeLayout(false);
            this.tabMXbutton.PerformLayout();
            this.tabMScroll.ResumeLayout(false);
            this.tabMScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScrollN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXButtonN)).EndInit();
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
        private System.Windows.Forms.TabControl tabMouseEvent;
        private System.Windows.Forms.TabPage tabMMove;
        private System.Windows.Forms.TabPage tabMButton;
        private System.Windows.Forms.TabPage tabMXbutton;
        private System.Windows.Forms.TabPage tabMScroll;
        private System.Windows.Forms.NumericUpDown numScrollN;
        private System.Windows.Forms.CheckBox checkScrollH;
        private System.Windows.Forms.CheckBox checkXButtonUp;
        private System.Windows.Forms.CheckBox checkXButtonDown;
        private System.Windows.Forms.NumericUpDown numXButtonN;
        private System.Windows.Forms.CheckBox checkMBLU;
        private System.Windows.Forms.CheckBox checkMBLD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkMBMU;
        private System.Windows.Forms.CheckBox checkMBRU;
        private System.Windows.Forms.CheckBox checkMBMD;
        private System.Windows.Forms.CheckBox checkMBRD;
    }
}