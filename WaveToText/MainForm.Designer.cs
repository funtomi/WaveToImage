namespace WaveToText {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabCtrl = new MetroFramework.Controls.MetroTabControl();
            this.tbPgView = new MetroFramework.Controls.MetroTabPage();
            this.lblAttractionName = new MetroFramework.Controls.MetroLabel();
            this.txtboxAttractionInfo = new MetroFramework.Controls.MetroTextBox();
            this.listView1 = new MetroFramework.Controls.MetroListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblMsg = new MetroFramework.Controls.MetroLabel();
            this.lblTip2 = new MetroFramework.Controls.MetroLabel();
            this.btnWav = new MetroFramework.Controls.MetroButton();
            this.lblTip = new MetroFramework.Controls.MetroLabel();
            this.tbPgPosition = new MetroFramework.Controls.MetroTabPage();
            this.tbPgAddAttr = new MetroFramework.Controls.MetroTabPage();
            this.lblCity = new MetroFramework.Controls.MetroLabel();
            this.lblProvince = new MetroFramework.Controls.MetroLabel();
            this.lblY = new MetroFramework.Controls.MetroLabel();
            this.lblX = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtBoxAttractionDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtBoxAttractionName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblText1 = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.lblTip3 = new MetroFramework.Controls.MetroLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.bMap1 = new BMapControl.BMap();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tbPgView.SuspendLayout();
            this.tbPgPosition.SuspendLayout();
            this.tbPgAddAttr.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tbPgView);
            this.tabCtrl.Controls.Add(this.tbPgPosition);
            this.tabCtrl.Controls.Add(this.tbPgAddAttr);
            this.tabCtrl.HotTrack = true;
            this.tabCtrl.ItemSize = new System.Drawing.Size(90, 35);
            this.tabCtrl.Location = new System.Drawing.Point(217, 84);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 1;
            this.tabCtrl.ShowToolTips = true;
            this.tabCtrl.Size = new System.Drawing.Size(788, 573);
            this.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrl.TabIndex = 0;
            this.tabCtrl.UseSelectable = true;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            // 
            // tbPgView
            // 
            this.tbPgView.AutoScroll = true;
            this.tbPgView.Controls.Add(this.lblAttractionName);
            this.tbPgView.Controls.Add(this.txtboxAttractionInfo);
            this.tbPgView.Controls.Add(this.listView1);
            this.tbPgView.Controls.Add(this.lblMsg);
            this.tbPgView.Controls.Add(this.lblTip2);
            this.tbPgView.Controls.Add(this.btnWav);
            this.tbPgView.Controls.Add(this.lblTip);
            this.tbPgView.HorizontalScrollbar = true;
            this.tbPgView.HorizontalScrollbarBarColor = true;
            this.tbPgView.HorizontalScrollbarHighlightOnWheel = false;
            this.tbPgView.HorizontalScrollbarSize = 6;
            this.tbPgView.Location = new System.Drawing.Point(4, 39);
            this.tbPgView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgView.Name = "tbPgView";
            this.tbPgView.Size = new System.Drawing.Size(780, 530);
            this.tbPgView.TabIndex = 0;
            this.tbPgView.Text = "识别图片";
            this.tbPgView.ToolTipText = "识别图片";
            this.tbPgView.VerticalScrollbar = true;
            this.tbPgView.VerticalScrollbarBarColor = true;
            this.tbPgView.VerticalScrollbarHighlightOnWheel = false;
            this.tbPgView.VerticalScrollbarSize = 8;
            // 
            // lblAttractionName
            // 
            this.lblAttractionName.AutoSize = true;
            this.lblAttractionName.Location = new System.Drawing.Point(17, 106);
            this.lblAttractionName.Name = "lblAttractionName";
            this.lblAttractionName.Size = new System.Drawing.Size(0, 0);
            this.lblAttractionName.TabIndex = 8;
            // 
            // txtboxAttractionInfo
            // 
            this.txtboxAttractionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtboxAttractionInfo.CustomButton.Image = null;
            this.txtboxAttractionInfo.CustomButton.Location = new System.Drawing.Point(635, 1);
            this.txtboxAttractionInfo.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxAttractionInfo.CustomButton.Name = "";
            this.txtboxAttractionInfo.CustomButton.Size = new System.Drawing.Size(109, 109);
            this.txtboxAttractionInfo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtboxAttractionInfo.CustomButton.TabIndex = 1;
            this.txtboxAttractionInfo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtboxAttractionInfo.CustomButton.UseSelectable = true;
            this.txtboxAttractionInfo.CustomButton.Visible = false;
            this.txtboxAttractionInfo.Lines = new string[0];
            this.txtboxAttractionInfo.Location = new System.Drawing.Point(17, 150);
            this.txtboxAttractionInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtboxAttractionInfo.MaxLength = 32767;
            this.txtboxAttractionInfo.Multiline = true;
            this.txtboxAttractionInfo.Name = "txtboxAttractionInfo";
            this.txtboxAttractionInfo.PasswordChar = '\0';
            this.txtboxAttractionInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtboxAttractionInfo.SelectedText = "";
            this.txtboxAttractionInfo.SelectionLength = 0;
            this.txtboxAttractionInfo.SelectionStart = 0;
            this.txtboxAttractionInfo.ShortcutsEnabled = true;
            this.txtboxAttractionInfo.Size = new System.Drawing.Size(745, 111);
            this.txtboxAttractionInfo.TabIndex = 7;
            this.txtboxAttractionInfo.UseSelectable = true;
            this.txtboxAttractionInfo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtboxAttractionInfo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(17, 269);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(745, 261);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.UseSelectable = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(200, 200);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(216, 85);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 0);
            this.lblMsg.TabIndex = 5;
            // 
            // lblTip2
            // 
            this.lblTip2.AutoSize = true;
            this.lblTip2.Location = new System.Drawing.Point(17, 66);
            this.lblTip2.Name = "lblTip2";
            this.lblTip2.Size = new System.Drawing.Size(79, 19);
            this.lblTip2.TabIndex = 4;
            this.lblTip2.Text = "识别结果：";
            // 
            // btnWav
            // 
            this.btnWav.Location = new System.Drawing.Point(240, 20);
            this.btnWav.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWav.Name = "btnWav";
            this.btnWav.Size = new System.Drawing.Size(84, 33);
            this.btnWav.TabIndex = 3;
            this.btnWav.Text = "录音";
            this.btnWav.UseSelectable = true;
            this.btnWav.Click += new System.EventHandler(this.btnWav_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(17, 20);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(205, 19);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "请点击【录音】按钮开始录音：";
            // 
            // tbPgPosition
            // 
            this.tbPgPosition.Controls.Add(this.bMap1);
            this.tbPgPosition.Controls.Add(this.metroLabel8);
            this.tbPgPosition.HorizontalScrollbarBarColor = true;
            this.tbPgPosition.HorizontalScrollbarHighlightOnWheel = false;
            this.tbPgPosition.HorizontalScrollbarSize = 6;
            this.tbPgPosition.Location = new System.Drawing.Point(4, 39);
            this.tbPgPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgPosition.Name = "tbPgPosition";
            this.tbPgPosition.Size = new System.Drawing.Size(780, 530);
            this.tbPgPosition.TabIndex = 2;
            this.tbPgPosition.Text = "景点定位";
            this.tbPgPosition.ToolTipText = "景点定位";
            this.tbPgPosition.VerticalScrollbarBarColor = true;
            this.tbPgPosition.VerticalScrollbarHighlightOnWheel = false;
            this.tbPgPosition.VerticalScrollbarSize = 8;
            // 
            // tbPgAddAttr
            // 
            this.tbPgAddAttr.AutoScroll = true;
            this.tbPgAddAttr.Controls.Add(this.lblCity);
            this.tbPgAddAttr.Controls.Add(this.lblProvince);
            this.tbPgAddAttr.Controls.Add(this.lblY);
            this.tbPgAddAttr.Controls.Add(this.lblX);
            this.tbPgAddAttr.Controls.Add(this.metroLabel7);
            this.tbPgAddAttr.Controls.Add(this.metroLabel6);
            this.tbPgAddAttr.Controls.Add(this.metroLabel5);
            this.tbPgAddAttr.Controls.Add(this.metroLabel4);
            this.tbPgAddAttr.Controls.Add(this.txtBoxAttractionDescription);
            this.tbPgAddAttr.Controls.Add(this.txtBoxAttractionName);
            this.tbPgAddAttr.Controls.Add(this.metroLabel3);
            this.tbPgAddAttr.Controls.Add(this.metroLabel2);
            this.tbPgAddAttr.Controls.Add(this.lblText1);
            this.tbPgAddAttr.Controls.Add(this.btnSave);
            this.tbPgAddAttr.Controls.Add(this.textBox1);
            this.tbPgAddAttr.Controls.Add(this.btnSelect);
            this.tbPgAddAttr.Controls.Add(this.lblTip3);
            this.tbPgAddAttr.HorizontalScrollbar = true;
            this.tbPgAddAttr.HorizontalScrollbarBarColor = true;
            this.tbPgAddAttr.HorizontalScrollbarHighlightOnWheel = false;
            this.tbPgAddAttr.HorizontalScrollbarSize = 6;
            this.tbPgAddAttr.Location = new System.Drawing.Point(4, 39);
            this.tbPgAddAttr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgAddAttr.Name = "tbPgAddAttr";
            this.tbPgAddAttr.Size = new System.Drawing.Size(780, 530);
            this.tbPgAddAttr.TabIndex = 1;
            this.tbPgAddAttr.Text = "添加景点";
            this.tbPgAddAttr.ToolTipText = "导入图片";
            this.tbPgAddAttr.VerticalScrollbar = true;
            this.tbPgAddAttr.VerticalScrollbarBarColor = true;
            this.tbPgAddAttr.VerticalScrollbarHighlightOnWheel = false;
            this.tbPgAddAttr.VerticalScrollbarSize = 8;
            this.tbPgAddAttr.Visible = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(280, 70);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(0, 0);
            this.lblCity.TabIndex = 22;
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(113, 70);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(0, 0);
            this.lblProvince.TabIndex = 21;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(550, 70);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 0);
            this.lblY.TabIndex = 20;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(550, 28);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 0);
            this.lblX.TabIndex = 18;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(472, 28);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(79, 19);
            this.metroLabel7.TabIndex = 17;
            this.metroLabel7.Text = "景点坐标：";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(396, 70);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(23, 19);
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "市";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(224, 70);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(23, 19);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "省";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(28, 70);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 19);
            this.metroLabel4.TabIndex = 12;
            this.metroLabel4.Text = "景点地址：";
            // 
            // txtBoxAttractionDescription
            // 
            this.txtBoxAttractionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBoxAttractionDescription.CustomButton.Image = null;
            this.txtBoxAttractionDescription.CustomButton.Location = new System.Drawing.Point(519, 2);
            this.txtBoxAttractionDescription.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxAttractionDescription.CustomButton.Name = "";
            this.txtBoxAttractionDescription.CustomButton.Size = new System.Drawing.Size(209, 209);
            this.txtBoxAttractionDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBoxAttractionDescription.CustomButton.TabIndex = 1;
            this.txtBoxAttractionDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBoxAttractionDescription.CustomButton.UseSelectable = true;
            this.txtBoxAttractionDescription.CustomButton.Visible = false;
            this.txtBoxAttractionDescription.Lines = new string[0];
            this.txtBoxAttractionDescription.Location = new System.Drawing.Point(28, 130);
            this.txtBoxAttractionDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxAttractionDescription.MaxLength = 32767;
            this.txtBoxAttractionDescription.Multiline = true;
            this.txtBoxAttractionDescription.Name = "txtBoxAttractionDescription";
            this.txtBoxAttractionDescription.PasswordChar = '\0';
            this.txtBoxAttractionDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxAttractionDescription.SelectedText = "";
            this.txtBoxAttractionDescription.SelectionLength = 0;
            this.txtBoxAttractionDescription.SelectionStart = 0;
            this.txtBoxAttractionDescription.ShortcutsEnabled = true;
            this.txtBoxAttractionDescription.Size = new System.Drawing.Size(731, 214);
            this.txtBoxAttractionDescription.TabIndex = 11;
            this.txtBoxAttractionDescription.UseSelectable = true;
            this.txtBoxAttractionDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBoxAttractionDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBoxAttractionName
            // 
            // 
            // 
            // 
            this.txtBoxAttractionName.CustomButton.Image = null;
            this.txtBoxAttractionName.CustomButton.Location = new System.Drawing.Point(305, 1);
            this.txtBoxAttractionName.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxAttractionName.CustomButton.Name = "";
            this.txtBoxAttractionName.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.txtBoxAttractionName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBoxAttractionName.CustomButton.TabIndex = 1;
            this.txtBoxAttractionName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBoxAttractionName.CustomButton.UseSelectable = true;
            this.txtBoxAttractionName.CustomButton.Visible = false;
            this.txtBoxAttractionName.Lines = new string[0];
            this.txtBoxAttractionName.Location = new System.Drawing.Point(109, 23);
            this.txtBoxAttractionName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxAttractionName.MaxLength = 32767;
            this.txtBoxAttractionName.Name = "txtBoxAttractionName";
            this.txtBoxAttractionName.PasswordChar = '\0';
            this.txtBoxAttractionName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxAttractionName.SelectedText = "";
            this.txtBoxAttractionName.SelectionLength = 0;
            this.txtBoxAttractionName.SelectionStart = 0;
            this.txtBoxAttractionName.ShortcutsEnabled = true;
            this.txtBoxAttractionName.Size = new System.Drawing.Size(335, 31);
            this.txtBoxAttractionName.TabIndex = 10;
            this.txtBoxAttractionName.UseSelectable = true;
            this.txtBoxAttractionName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBoxAttractionName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(28, 107);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(79, 19);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "景点描述：";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(28, 28);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(79, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "景点名称：";
            // 
            // lblText1
            // 
            this.lblText1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(28, 471);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(0, 0);
            this.lblText1.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(659, 471);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(563, 2);
            this.textBox1.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(28, 401);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(601, 40);
            this.textBox1.TabIndex = 5;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Location = new System.Drawing.Point(659, 401);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 35);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "选择图片";
            this.btnSelect.UseSelectable = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblTip3
            // 
            this.lblTip3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTip3.AutoSize = true;
            this.lblTip3.Location = new System.Drawing.Point(28, 367);
            this.lblTip3.Name = "lblTip3";
            this.lblTip3.Size = new System.Drawing.Size(275, 19);
            this.lblTip3.TabIndex = 2;
            this.lblTip3.Text = "请点击【选择】按钮选择需要导入的图片：";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(31, 107);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(180, 550);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 84);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "景点列表";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(3, 10);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(135, 19);
            this.metroLabel8.TabIndex = 3;
            this.metroLabel8.Text = "双击定位添加景点：";
            // 
            // bMap1
            // 
            this.bMap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bMap1.AutoSize = true;
            this.bMap1.Location = new System.Drawing.Point(9, 44);
            this.bMap1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bMap1.Name = "bMap1";
            this.bMap1.Size = new System.Drawing.Size(767, 465);
            this.bMap1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 688);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabCtrl);
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(22, 80, 22, 27);
            this.Style = MetroFramework.MetroColorStyle.Custom;
            this.Text = "语音识别";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tbPgView.ResumeLayout(false);
            this.tbPgView.PerformLayout();
            this.tbPgPosition.ResumeLayout(false);
            this.tbPgPosition.PerformLayout();
            this.tbPgAddAttr.ResumeLayout(false);
            this.tbPgAddAttr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl tabCtrl;
        private MetroFramework.Controls.MetroTabPage tbPgView;
        private MetroFramework.Controls.MetroTabPage tbPgAddAttr;
        private MetroFramework.Controls.MetroLabel lblTip;
        private MetroFramework.Controls.MetroButton btnWav;
        private MetroFramework.Controls.MetroLabel lblTip2;
        private MetroFramework.Controls.MetroLabel lblMsg;
        private MetroFramework.Controls.MetroListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Controls.MetroButton btnSelect;
        private MetroFramework.Controls.MetroLabel lblTip3;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroLabel lblText1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroTabPage tbPgPosition;
        private MetroFramework.Controls.MetroTextBox txtboxAttractionInfo;
        private MetroFramework.Controls.MetroTextBox txtBoxAttractionDescription;
        private MetroFramework.Controls.MetroTextBox txtBoxAttractionName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblAttractionName;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel lblY;
        private MetroFramework.Controls.MetroLabel lblX;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel lblCity;
        private MetroFramework.Controls.MetroLabel lblProvince;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private BMapControl.BMap bMap1;

    }
}