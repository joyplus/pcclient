using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace PCHelper
{
    public partial class BaseForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.headerPicture.Parent = this;
            this.logo.Parent = this.headerPicture;
            pictureBox_Min.Parent = this.headerPicture;
            pictureBox_Close.Parent = this.headerPicture;

            pcPictureBox.Location = new Point(0, 0);
            pcPictureBox.Parent = menuBgPic;

            cloudPictureBox.Location = new Point(140 + 3, 0);
            cloudPictureBox.Parent = menuBgPic;

            keyPictureBox.Location = new Point((140 + 2) * 2 + 1, 0);
            keyPictureBox.Parent = menuBgPic;

            pcPanel.Parent = this;
            cloudPanel.Parent = this;
            sharePicBox.Parent = pcPanel;

            pictureBox_Min.Image = null;
            pictureBox_Min.Image = Properties.Resources.btn_min;
            pictureBox_Close.Image = null;
            pictureBox_Close.Image = Properties.Resources.btn_close;
        }

        #region  设置窗体的最大化、最小化和关闭按钮的单击事件
        /// <summary>
        /// 设置窗体的最大化、最小化和关闭按钮的单击事件
        /// </summary>
        /// <param Frm_Tem="Form">窗体</param>
        /// <param n="int">标识</param>
        public void FrmClickMeans(Form Frm_Tem, int n)
        {
            switch (n)
            {
                case 0:
                    Frm_Tem.WindowState = FormWindowState.Minimized;
                    break;
                case 2:
                    Frm_Tem.Close();
                    break;
            }
        }
        #endregion

        #region  控制图片的切换状态
        /// <summary>
        /// 控制图片的切换状态
        /// </summary>
        /// <param Frm_Tem="Form">要改变图片的对象</param>
        /// <param n="int">标识</param>
        /// <param ns="int">移出移入标识</param>
        public static PictureBox Tem_PictB = new PictureBox();
        public void ImageSwitch(object sender, int n, int ns)
        {
            Tem_PictB = (PictureBox)sender;

            switch (n)
            {
                case 0:
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                            Tem_PictB.Image = Properties.Resources.btn_min_pressed;
                        if (ns == 1)
                            Tem_PictB.Image = Properties.Resources.btn_min;
                        break;
                    }
                case 2:
                    {
                        Tem_PictB.Image = null;
                        if (ns == 0)
                        {
                            Tem_PictB.Image = Properties.Resources.btn_close_pressed;
                        }
                        if (ns == 1)
                        {
                            Tem_PictB.Image = Properties.Resources.btn_close;
                        }
                        break;
                    }
            }
        }
        #endregion

        private void pictureBox_Close_Click(object sender, EventArgs e)
        {
            FrmClickMeans(this, Convert.ToInt16(((PictureBox)sender).Tag.ToString()));
        }

        private void pictureBox_Close_MouseEnter(object sender, EventArgs e)
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 0);
        }

        private void pictureBox_Close_MouseLeave(object sender, EventArgs e)
        {
            ImageSwitch(sender, Convert.ToInt16(((PictureBox)sender).Tag.ToString()), 1);
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath oPath = new GraphicsPath();
            int x = 0;
            int y = 0;
            int w = Width;
            int h = Height;
            int a = 10;
            Graphics g = CreateGraphics();
            oPath.AddArc(x, y, a, a, 180, 90);
            oPath.AddArc(w - a, y, a, a, 270, 90);
            oPath.AddArc(w - a / 2, h - a / 2, a / 2, a / 2, 0, 90);
            oPath.AddArc(x, h - a/2, a, a, 90, 90);
            oPath.CloseAllFigures();
            Region = new Region(oPath);
        }
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
        }

        private void pcPictureBox_Click(object sender, EventArgs e)
        {
            switchPanel((PictureBox)sender);
        }

        private void cloudPictureBox_Click(object sender, EventArgs e)
        {
            switchPanel((PictureBox)sender);
        }

        private void switchPanel(PictureBox menuBtn)
        {
            if (menuBtn.Name == "pcPictureBox")
            {
                changePanelVisable(true, false);
            }
            else if (menuBtn.Name == "cloudPictureBox")
            {
                changePanelVisable(false, true);
            }
        }

        private void changePanelVisable(bool pcPanelVisable, bool cloudPanelVisable)
        {
            this.pcPanel.Visible = pcPanelVisable;
            this.cloudPanel.Visible = cloudPanelVisable;
        }

        private void versionLabel_Paint(object sender, PaintEventArgs e)
        {
            versionLabel.Location = new Point(15,10);
            bottomPicBox.Controls.Add(versionLabel);
        }

        private void commentLabel_Paint(object sender, PaintEventArgs e)
        {
            commentLabel.Location = new Point(720, 10);
            bottomPicBox.Controls.Add(commentLabel);
        }
    }
}
