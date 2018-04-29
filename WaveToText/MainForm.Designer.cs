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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtboxAttractionInfo = new MetroFramework.Controls.MetroTextBox();
            this.listView1 = new MetroFramework.Controls.MetroListView();
            this.lblMsg = new MetroFramework.Controls.MetroLabel();
            this.lblTip2 = new MetroFramework.Controls.MetroLabel();
            this.btnWav = new MetroFramework.Controls.MetroButton();
            this.lblTip = new MetroFramework.Controls.MetroLabel();
            this.btnAdd = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(200, 200);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(31, 107);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(180, 525);
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
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(236, 408);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(856, 235);
            this.webBrowser1.TabIndex = 16;
            // 
            // txtboxAttractionInfo
            // 
            this.txtboxAttractionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtboxAttractionInfo.CustomButton.Image = null;
            this.txtboxAttractionInfo.CustomButton.Location = new System.Drawing.Point(746, 1);
            this.txtboxAttractionInfo.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtboxAttractionInfo.CustomButton.Name = "";
            this.txtboxAttractionInfo.CustomButton.Size = new System.Drawing.Size(109, 109);
            this.txtboxAttractionInfo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtboxAttractionInfo.CustomButton.TabIndex = 1;
            this.txtboxAttractionInfo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtboxAttractionInfo.CustomButton.UseSelectable = true;
            this.txtboxAttractionInfo.CustomButton.Visible = false;
            this.txtboxAttractionInfo.Lines = new string[0];
            this.txtboxAttractionInfo.Location = new System.Drawing.Point(236, 177);
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
            this.txtboxAttractionInfo.Size = new System.Drawing.Size(856, 55);
            this.txtboxAttractionInfo.TabIndex = 15;
            this.txtboxAttractionInfo.UseSelectable = true;
            this.txtboxAttractionInfo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtboxAttractionInfo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listView1.FullRowSelect = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(236, 236);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(856, 165);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.UseSelectable = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(321, 154);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(65, 19);
            this.lblMsg.TabIndex = 13;
            this.lblMsg.Text = "识别结果";
            // 
            // lblTip2
            // 
            this.lblTip2.AutoSize = true;
            this.lblTip2.Location = new System.Drawing.Point(236, 154);
            this.lblTip2.Name = "lblTip2";
            this.lblTip2.Size = new System.Drawing.Size(79, 19);
            this.lblTip2.TabIndex = 12;
            this.lblTip2.Text = "识别结果：";
            // 
            // btnWav
            // 
            this.btnWav.Location = new System.Drawing.Point(459, 101);
            this.btnWav.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWav.Name = "btnWav";
            this.btnWav.Size = new System.Drawing.Size(84, 33);
            this.btnWav.TabIndex = 11;
            this.btnWav.Text = "录音";
            this.btnWav.UseSelectable = true;
            this.btnWav.Click += new System.EventHandler(this.btnWav_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(236, 108);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(205, 19);
            this.lblTip.TabIndex = 10;
            this.lblTip.Text = "请点击【录音】按钮开始录音：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(99, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "+";
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 663);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.txtboxAttractionInfo);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblTip2);
            this.Controls.Add(this.btnWav);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.07563F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(22, 80, 22, 27);
            this.Style = MetroFramework.MetroColorStyle.Custom;
            this.Text = "语音识别";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.ImageList imageList1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MetroFramework.Controls.MetroTextBox txtboxAttractionInfo;
        private MetroFramework.Controls.MetroListView listView1;
        private MetroFramework.Controls.MetroLabel lblMsg;
        private MetroFramework.Controls.MetroLabel lblTip2;
        private MetroFramework.Controls.MetroButton btnWav;
        private MetroFramework.Controls.MetroLabel lblTip;
        private MetroFramework.Controls.MetroButton btnAdd;

    }
}