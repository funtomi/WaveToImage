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
            this.tabPg1 = new MetroFramework.Controls.MetroTabPage();
            this.listView1 = new MetroFramework.Controls.MetroListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblMsg = new MetroFramework.Controls.MetroLabel();
            this.lblTip2 = new MetroFramework.Controls.MetroLabel();
            this.btnWav = new MetroFramework.Controls.MetroButton();
            this.lblTip = new MetroFramework.Controls.MetroLabel();
            this.tabPg2 = new MetroFramework.Controls.MetroTabPage();
            this.lblText1 = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.btnSelect = new MetroFramework.Controls.MetroButton();
            this.lblTip3 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tabPg1.SuspendLayout();
            this.tabPg2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabPg1);
            this.tabCtrl.Controls.Add(this.tabPg2);
            this.tabCtrl.HotTrack = true;
            this.tabCtrl.ItemSize = new System.Drawing.Size(90, 35);
            this.tabCtrl.Location = new System.Drawing.Point(23, 63);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.ShowToolTips = true;
            this.tabCtrl.Size = new System.Drawing.Size(870, 522);
            this.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabCtrl.TabIndex = 0;
            this.tabCtrl.UseSelectable = true;
            // 
            // tabPg1
            // 
            this.tabPg1.AutoScroll = true;
            this.tabPg1.Controls.Add(this.listView1);
            this.tabPg1.Controls.Add(this.lblMsg);
            this.tabPg1.Controls.Add(this.lblTip2);
            this.tabPg1.Controls.Add(this.btnWav);
            this.tabPg1.Controls.Add(this.lblTip);
            this.tabPg1.Enabled = true;
            this.tabPg1.HorizontalScrollbar = true;
            this.tabPg1.HorizontalScrollbarBarColor = true;
            this.tabPg1.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPg1.HorizontalScrollbarSize = 10;
            this.tabPg1.Location = new System.Drawing.Point(4, 39);
            this.tabPg1.Name = "tabPg1";
            this.tabPg1.Size = new System.Drawing.Size(862, 479);
            this.tabPg1.TabIndex = 0;
            this.tabPg1.Text = "识别图片";
            this.tabPg1.ToolTipText = "识别图片";
            this.tabPg1.VerticalScrollbar = true;
            this.tabPg1.VerticalScrollbarBarColor = true;
            this.tabPg1.VerticalScrollbarHighlightOnWheel = false;
            this.tabPg1.VerticalScrollbarSize = 10;
            this.tabPg1.Visible = true;
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
            this.listView1.Location = new System.Drawing.Point(15, 107);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(832, 366);
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
            this.lblMsg.Location = new System.Drawing.Point(192, 64);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 0);
            this.lblMsg.TabIndex = 5;
            // 
            // lblTip2
            // 
            this.lblTip2.AutoSize = true;
            this.lblTip2.Location = new System.Drawing.Point(107, 64);
            this.lblTip2.Name = "lblTip2";
            this.lblTip2.Size = new System.Drawing.Size(79, 19);
            this.lblTip2.TabIndex = 4;
            this.lblTip2.Text = "识别结果：";
            // 
            // btnWav
            // 
            this.btnWav.Location = new System.Drawing.Point(15, 54);
            this.btnWav.Name = "btnWav";
            this.btnWav.Size = new System.Drawing.Size(75, 35);
            this.btnWav.TabIndex = 3;
            this.btnWav.Text = "录音";
            this.btnWav.UseSelectable = true;
            this.btnWav.Click += new System.EventHandler(this.btnWav_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(15, 15);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(205, 19);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "请点击【录音】按钮开始录音：";
            // 
            // tabPg2
            // 
            this.tabPg2.AutoScroll = true;
            this.tabPg2.Controls.Add(this.lblText1);
            this.tabPg2.Controls.Add(this.btnSave);
            this.tabPg2.Controls.Add(this.textBox1);
            this.tabPg2.Controls.Add(this.btnSelect);
            this.tabPg2.Controls.Add(this.lblTip3);
            this.tabPg2.Enabled = true;
            this.tabPg2.HorizontalScrollbar = true;
            this.tabPg2.HorizontalScrollbarBarColor = true;
            this.tabPg2.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPg2.HorizontalScrollbarSize = 10;
            this.tabPg2.Location = new System.Drawing.Point(4, 39);
            this.tabPg2.Name = "tabPg2";
            this.tabPg2.Size = new System.Drawing.Size(862, 479);
            this.tabPg2.TabIndex = 1;
            this.tabPg2.Text = "导入图片";
            this.tabPg2.ToolTipText = "导入图片";
            this.tabPg2.VerticalScrollbar = true;
            this.tabPg2.VerticalScrollbarBarColor = true;
            this.tabPg2.VerticalScrollbarHighlightOnWheel = false;
            this.tabPg2.VerticalScrollbarSize = 10;
            this.tabPg2.Visible = false;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(15, 101);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(0, 0);
            this.lblText1.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(676, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(15, 53);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(704, 30);
            this.textBox1.TabIndex = 5;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(15, 130);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 35);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "选择图片";
            this.btnSelect.UseSelectable = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblTip3
            // 
            this.lblTip3.AutoSize = true;
            this.lblTip3.Location = new System.Drawing.Point(15, 16);
            this.lblTip3.Name = "lblTip3";
            this.lblTip3.Size = new System.Drawing.Size(275, 19);
            this.lblTip3.TabIndex = 2;
            this.lblTip3.Text = "请点击【选择】按钮选择需要导入的图片：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 598);
            this.Controls.Add(this.tabCtrl);
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.Style = MetroFramework.MetroColorStyle.Custom;
            this.Text = "语音识别";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tabPg1.ResumeLayout(false);
            this.tabPg1.PerformLayout();
            this.tabPg2.ResumeLayout(false);
            this.tabPg2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl tabCtrl;
        private MetroFramework.Controls.MetroTabPage tabPg1;
        private MetroFramework.Controls.MetroTabPage tabPg2;
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

    }
}