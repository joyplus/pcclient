namespace PCHelper
{
    partial class TreeViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( TreeViewForm ) );
            this.listView1 = new System.Windows.Forms.ListView ( );
            this.AddBtn = new System.Windows.Forms.Button ( );
            this.DelBtn = new System.Windows.Forms.Button ( );
            this.SubmmitBtn = new System.Windows.Forms.Button ( );
            this.CancelBtn = new System.Windows.Forms.Button ( );
            this.headerPicBox = new System.Windows.Forms.PictureBox ( );
            this.explorerTreeView1 = new WilsonProgramming.ExplorerTreeView ( );
            ((System.ComponentModel.ISupportInitialize)(this.headerPicBox)).BeginInit ( );
            this.SuspendLayout ( );
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point ( 349, 39 );
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size ( 215, 261 );
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler ( this.listView1_MouseClick );
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddBtn.BackgroundImage = global::PCHelper.Properties.Resources.Button;
            this.AddBtn.Location = new System.Drawing.Point ( 223, 98 );
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size ( 76, 29 );
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "添加";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler ( this.AddBtn_Click );
            // 
            // DelBtn
            // 
            this.DelBtn.BackgroundImage = global::PCHelper.Properties.Resources.Button;
            this.DelBtn.Location = new System.Drawing.Point ( 223, 167 );
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size ( 76, 29 );
            this.DelBtn.TabIndex = 3;
            this.DelBtn.Text = "删除";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler ( this.DelBtn_Click );
            // 
            // SubmmitBtn
            // 
            this.SubmmitBtn.BackgroundImage = global::PCHelper.Properties.Resources.Button;
            this.SubmmitBtn.Location = new System.Drawing.Point ( 360, 309 );
            this.SubmmitBtn.Name = "SubmmitBtn";
            this.SubmmitBtn.Size = new System.Drawing.Size ( 76, 29 );
            this.SubmmitBtn.TabIndex = 4;
            this.SubmmitBtn.Text = "确定";
            this.SubmmitBtn.UseVisualStyleBackColor = true;
            this.SubmmitBtn.Click += new System.EventHandler ( this.SubmmitBtn_Click );
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackgroundImage = global::PCHelper.Properties.Resources.Button;
            this.CancelBtn.Location = new System.Drawing.Point ( 483, 308 );
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size ( 76, 29 );
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler ( this.CancelBtn_Click );
            // 
            // headerPicBox
            // 
            this.headerPicBox.Image = ((System.Drawing.Image)(resources.GetObject ( "headerPicBox.Image" )));
            this.headerPicBox.Location = new System.Drawing.Point ( 0, 1 );
            this.headerPicBox.Name = "headerPicBox";
            this.headerPicBox.Size = new System.Drawing.Size ( 574, 30 );
            this.headerPicBox.TabIndex = 6;
            this.headerPicBox.TabStop = false;
            // 
            // explorerTreeView1
            // 
            this.explorerTreeView1.Location = new System.Drawing.Point ( 17, 41 );
            this.explorerTreeView1.Name = "explorerTreeView1";
            this.explorerTreeView1.Size = new System.Drawing.Size ( 173, 261 );
            this.explorerTreeView1.TabIndex = 7;
            // 
            // TreeViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size ( 576, 338 );
            this.Controls.Add ( this.explorerTreeView1 );
            this.Controls.Add ( this.headerPicBox );
            this.Controls.Add ( this.CancelBtn );
            this.Controls.Add ( this.SubmmitBtn );
            this.Controls.Add ( this.DelBtn );
            this.Controls.Add ( this.AddBtn );
            this.Controls.Add ( this.listView1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TreeViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreeViewForm";
            this.Load += new System.EventHandler ( this.TreeViewForm_Load );
            ((System.ComponentModel.ISupportInitialize)(this.headerPicBox)).EndInit ( );
            this.ResumeLayout ( false );

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button SubmmitBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.PictureBox headerPicBox;
        private WilsonProgramming.ExplorerTreeView explorerTreeView1;
    }
}