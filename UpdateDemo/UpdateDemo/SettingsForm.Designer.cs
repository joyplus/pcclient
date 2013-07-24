namespace UpdateDemo
{
    partial class UpdateForm
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.regularLabel = new System.Windows.Forms.Label();
            this.updateLabel = new System.Windows.Forms.Label();
            this.aboutUsLabel = new System.Windows.Forms.Label();
            this.regularPanel = new System.Windows.Forms.Panel();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.exitRadio = new System.Windows.Forms.RadioButton();
            this.minRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updatePanel = new System.Windows.Forms.Panel();
            this.updateBtn = new System.Windows.Forms.PictureBox();
            this.checkingLabel = new System.Windows.Forms.Label();
            this.aboutusPicBox = new System.Windows.Forms.PictureBox();
            this.updatePicBox = new System.Windows.Forms.PictureBox();
            this.regularPicBox = new System.Windows.Forms.PictureBox();
            this.closePicbox = new System.Windows.Forms.PictureBox();
            this.headerPicBox = new System.Windows.Forms.PictureBox();
            this.aboutusPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.regularPanel.SuspendLayout();
            this.updatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutusPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regularPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePicbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPicBox)).BeginInit();
            this.aboutusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // regularLabel
            // 
            this.regularLabel.AutoSize = true;
            this.regularLabel.BackColor = System.Drawing.Color.Transparent;
            this.regularLabel.ForeColor = System.Drawing.Color.DimGray;
            this.regularLabel.Location = new System.Drawing.Point(32, 37);
            this.regularLabel.Name = "regularLabel";
            this.regularLabel.Size = new System.Drawing.Size(53, 12);
            this.regularLabel.TabIndex = 5;
            this.regularLabel.Text = "常规设置";
            this.regularLabel.Click += new System.EventHandler(this.regularPicBox_Click);
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.BackColor = System.Drawing.Color.Transparent;
            this.updateLabel.ForeColor = System.Drawing.Color.DimGray;
            this.updateLabel.Location = new System.Drawing.Point(32, 69);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(53, 12);
            this.updateLabel.TabIndex = 6;
            this.updateLabel.Text = "软件更新";
            this.updateLabel.Click += new System.EventHandler(this.updatePicBox_Click);
            // 
            // aboutUsLabel
            // 
            this.aboutUsLabel.AutoSize = true;
            this.aboutUsLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutUsLabel.ForeColor = System.Drawing.Color.DimGray;
            this.aboutUsLabel.Location = new System.Drawing.Point(32, 99);
            this.aboutUsLabel.Name = "aboutUsLabel";
            this.aboutUsLabel.Size = new System.Drawing.Size(53, 12);
            this.aboutUsLabel.TabIndex = 7;
            this.aboutUsLabel.Text = "关于我们";
            this.aboutUsLabel.Click += new System.EventHandler(this.aboutusPicBox_Click);
            // 
            // regularPanel
            // 
            this.regularPanel.Controls.Add(this.applyBtn);
            this.regularPanel.Controls.Add(this.cancelBtn);
            this.regularPanel.Controls.Add(this.confirmBtn);
            this.regularPanel.Controls.Add(this.exitRadio);
            this.regularPanel.Controls.Add(this.minRadio);
            this.regularPanel.Controls.Add(this.label2);
            this.regularPanel.Controls.Add(this.autoUpdateCheckBox);
            this.regularPanel.Controls.Add(this.label1);
            this.regularPanel.Location = new System.Drawing.Point(146, 30);
            this.regularPanel.Name = "regularPanel";
            this.regularPanel.Size = new System.Drawing.Size(434, 374);
            this.regularPanel.TabIndex = 8;
            // 
            // applyBtn
            // 
            this.applyBtn.ForeColor = System.Drawing.Color.DimGray;
            this.applyBtn.Location = new System.Drawing.Point(354, 332);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(60, 23);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "应用";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.ForeColor = System.Drawing.Color.DimGray;
            this.cancelBtn.Location = new System.Drawing.Point(277, 332);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(60, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.ForeColor = System.Drawing.Color.DimGray;
            this.confirmBtn.Location = new System.Drawing.Point(199, 332);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(60, 23);
            this.confirmBtn.TabIndex = 5;
            this.confirmBtn.Text = "确认";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // exitRadio
            // 
            this.exitRadio.AutoSize = true;
            this.exitRadio.ForeColor = System.Drawing.Color.DimGray;
            this.exitRadio.Location = new System.Drawing.Point(27, 129);
            this.exitRadio.Name = "exitRadio";
            this.exitRadio.Size = new System.Drawing.Size(95, 16);
            this.exitRadio.TabIndex = 4;
            this.exitRadio.TabStop = true;
            this.exitRadio.Text = "退出应用程序";
            this.exitRadio.UseVisualStyleBackColor = true;
            this.exitRadio.CheckedChanged += new System.EventHandler(this.exitRadio_CheckedChanged);
            // 
            // minRadio
            // 
            this.minRadio.AutoSize = true;
            this.minRadio.ForeColor = System.Drawing.Color.DimGray;
            this.minRadio.Location = new System.Drawing.Point(27, 106);
            this.minRadio.Name = "minRadio";
            this.minRadio.Size = new System.Drawing.Size(95, 16);
            this.minRadio.TabIndex = 3;
            this.minRadio.TabStop = true;
            this.minRadio.Text = "最小化到托盘";
            this.minRadio.UseVisualStyleBackColor = true;
            this.minRadio.CheckedChanged += new System.EventHandler(this.minRadio_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "关闭应用程序";
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.ForeColor = System.Drawing.Color.DimGray;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(27, 36);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(168, 16);
            this.autoUpdateCheckBox.TabIndex = 1;
            this.autoUpdateCheckBox.Text = "在系统启动时自动检查更新";
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.autoUpdateCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "启动设置";
            // 
            // updatePanel
            // 
            this.updatePanel.Controls.Add(this.downloadProgressBar);
            this.updatePanel.Controls.Add(this.updateBtn);
            this.updatePanel.Controls.Add(this.checkingLabel);
            this.updatePanel.Location = new System.Drawing.Point(188, 30);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Size = new System.Drawing.Size(437, 374);
            this.updatePanel.TabIndex = 8;
            this.updatePanel.Visible = false;
            // 
            // updateBtn
            // 
            this.updateBtn.Image = global::UpdateDemo.Properties.Resources.btn_update;
            this.updateBtn.Location = new System.Drawing.Point(178, 198);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(76, 24);
            this.updateBtn.TabIndex = 1;
            this.updateBtn.TabStop = false;
            this.updateBtn.Visible = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            this.updateBtn.MouseLeave += new System.EventHandler(this.updateBtn_MouseLeave);
            this.updateBtn.MouseHover += new System.EventHandler(this.updateBtn_MouseHover);
            // 
            // checkingLabel
            // 
            this.checkingLabel.AutoSize = true;
            this.checkingLabel.ForeColor = System.Drawing.Color.DimGray;
            this.checkingLabel.Location = new System.Drawing.Point(137, 133);
            this.checkingLabel.Name = "checkingLabel";
            this.checkingLabel.Size = new System.Drawing.Size(119, 12);
            this.checkingLabel.TabIndex = 0;
            this.checkingLabel.Text = "正在检测，请稍后...";
            // 
            // aboutusPicBox
            // 
            this.aboutusPicBox.Location = new System.Drawing.Point(0, 90);
            this.aboutusPicBox.Name = "aboutusPicBox";
            this.aboutusPicBox.Size = new System.Drawing.Size(140, 30);
            this.aboutusPicBox.TabIndex = 4;
            this.aboutusPicBox.TabStop = false;
            this.aboutusPicBox.Click += new System.EventHandler(this.aboutusPicBox_Click);
            // 
            // updatePicBox
            // 
            this.updatePicBox.Location = new System.Drawing.Point(0, 60);
            this.updatePicBox.Name = "updatePicBox";
            this.updatePicBox.Size = new System.Drawing.Size(140, 30);
            this.updatePicBox.TabIndex = 3;
            this.updatePicBox.TabStop = false;
            this.updatePicBox.Click += new System.EventHandler(this.updatePicBox_Click);
            // 
            // regularPicBox
            // 
            this.regularPicBox.Location = new System.Drawing.Point(0, 30);
            this.regularPicBox.Name = "regularPicBox";
            this.regularPicBox.Size = new System.Drawing.Size(140, 30);
            this.regularPicBox.TabIndex = 2;
            this.regularPicBox.TabStop = false;
            this.regularPicBox.Click += new System.EventHandler(this.regularPicBox_Click);
            // 
            // closePicbox
            // 
            this.closePicbox.BackColor = System.Drawing.Color.Transparent;
            this.closePicbox.Image = global::UpdateDemo.Properties.Resources.btn_close;
            this.closePicbox.Location = new System.Drawing.Point(554, 0);
            this.closePicbox.Name = "closePicbox";
            this.closePicbox.Size = new System.Drawing.Size(26, 33);
            this.closePicbox.TabIndex = 1;
            this.closePicbox.TabStop = false;
            this.closePicbox.Click += new System.EventHandler(this.closePicbox_Click);
            this.closePicbox.MouseLeave += new System.EventHandler(this.closePicbox_MouseLeave);
            this.closePicbox.MouseHover += new System.EventHandler(this.closePicbox_MouseHover);
            // 
            // headerPicBox
            // 
            this.headerPicBox.Image = ((System.Drawing.Image)(resources.GetObject("headerPicBox.Image")));
            this.headerPicBox.Location = new System.Drawing.Point(0, 0);
            this.headerPicBox.Name = "headerPicBox";
            this.headerPicBox.Size = new System.Drawing.Size(600, 30);
            this.headerPicBox.TabIndex = 0;
            this.headerPicBox.TabStop = false;
            this.headerPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_MouseDown);
            // 
            // aboutusPanel
            // 
            this.aboutusPanel.Controls.Add(this.label3);
            this.aboutusPanel.Location = new System.Drawing.Point(489, 30);
            this.aboutusPanel.Name = "aboutusPanel";
            this.aboutusPanel.Size = new System.Drawing.Size(437, 374);
            this.aboutusPanel.TabIndex = 9;
            this.aboutusPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(137, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "About Panel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(140, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 420);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(154, 157);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(124, 19);
            this.downloadProgressBar.TabIndex = 2;
            this.downloadProgressBar.Visible = false;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(592, 416);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.aboutusPanel);
            this.Controls.Add(this.updatePanel);
            this.Controls.Add(this.regularPanel);
            this.Controls.Add(this.aboutUsLabel);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.regularLabel);
            this.Controls.Add(this.aboutusPicBox);
            this.Controls.Add(this.updatePicBox);
            this.Controls.Add(this.regularPicBox);
            this.Controls.Add(this.closePicbox);
            this.Controls.Add(this.headerPicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.regularPanel.ResumeLayout(false);
            this.regularPanel.PerformLayout();
            this.updatePanel.ResumeLayout(false);
            this.updatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutusPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regularPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePicbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPicBox)).EndInit();
            this.aboutusPanel.ResumeLayout(false);
            this.aboutusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox headerPicBox;
        private System.Windows.Forms.PictureBox closePicbox;
        private System.Windows.Forms.PictureBox regularPicBox;
        private System.Windows.Forms.PictureBox updatePicBox;
        private System.Windows.Forms.PictureBox aboutusPicBox;
        private System.Windows.Forms.Label regularLabel;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Label aboutUsLabel;
        private System.Windows.Forms.Panel regularPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoUpdateCheckBox;
        private System.Windows.Forms.RadioButton minRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton exitRadio;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Panel updatePanel;
        private System.Windows.Forms.Label checkingLabel;
        private System.Windows.Forms.PictureBox updateBtn;
        private System.Windows.Forms.Panel aboutusPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
    }
}

