namespace PCHelper
{
    partial class SendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendForm));
            this.subformHeaderPicBox = new System.Windows.Forms.PictureBox();
            this.subformClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.subformHeaderPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subformClose)).BeginInit();
            this.SuspendLayout();
            // 
            // subformHeaderPicBox
            // 
            this.subformHeaderPicBox.Image = ((System.Drawing.Image)(resources.GetObject("subformHeaderPicBox.Image")));
            this.subformHeaderPicBox.Location = new System.Drawing.Point(0, 0);
            this.subformHeaderPicBox.Name = "subformHeaderPicBox";
            this.subformHeaderPicBox.Size = new System.Drawing.Size(600, 30);
            this.subformHeaderPicBox.TabIndex = 0;
            this.subformHeaderPicBox.TabStop = false;
            // 
            // subformClose
            // 
            this.subformClose.BackColor = System.Drawing.Color.Transparent;
            this.subformClose.Image = global::PCHelper.Properties.Resources.btn_close;
            this.subformClose.Location = new System.Drawing.Point(562, 0);
            this.subformClose.Name = "subformClose";
            this.subformClose.Size = new System.Drawing.Size(26, 23);
            this.subformClose.TabIndex = 5;
            this.subformClose.TabStop = false;
            this.subformClose.Tag = "2";
            this.subformClose.Click += new System.EventHandler(this.subformClose_Click);
            this.subformClose.MouseLeave += new System.EventHandler(this.subformClose_MouseLeave);
            this.subformClose.MouseHover += new System.EventHandler(this.subformClose_MouseHover);
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 340);
            this.Controls.Add(this.subformClose);
            this.Controls.Add(this.subformHeaderPicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(150, 120);
            this.Name = "SendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务列表";
            this.Load += new System.EventHandler(this.SendForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subformHeaderPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subformClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox subformHeaderPicBox;
        private System.Windows.Forms.PictureBox subformClose;
    }
}