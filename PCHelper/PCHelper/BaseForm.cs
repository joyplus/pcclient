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
        private int SELECTED_INDEX = 0;
        private string addressContent;
        public BaseForm()
        {
            InitializeComponent();
            addressTextBox.LostFocus += new System.EventHandler(addressTextBox_LostFocus);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.headerPicture.Parent = this;
            this.logo.Parent = this.headerPicture;
            pictureBox_Min.Parent = this.headerPicture;
            pictureBox_Close.Parent = this.headerPicture;

            pcPictureBox.Location = new Point(0, 0);
            pcPictureBox.Parent = menuBgPic;

            cloudPictureBox.Location = new Point(140, 0);
            cloudPictureBox.Parent = menuBgPic;

            keyPictureBox.Location = new Point((140) * 2, 0);
            keyPictureBox.Parent = menuBgPic;

            pcPanel.Parent = this;
            cloudPanel.Parent = this;
            cloudPanel.Location = pcPanel.Location;
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
            SELECTED_INDEX = 0;
            removeAddressTextBoxFocus();
            this.pcPictureBox.Image = Properties.Resources.btn_pc_pressed;
            this.cloudPictureBox.Image = Properties.Resources.btn_cloud;
            this.keyPictureBox.Image = Properties.Resources.btn_key;
            switchPanel((PictureBox)sender);
        }

        private void cloudPictureBox_Click(object sender, EventArgs e)
        {
            SELECTED_INDEX = 1;
            this.pcPictureBox.Image = Properties.Resources.btn_pc;
            this.cloudPictureBox.Image = Properties.Resources.btn_cloud_pressed;
            this.keyPictureBox.Image = Properties.Resources.btn_key;
            switchPanel((PictureBox)sender);
        }


        private void keyPictureBox_Click(object sender, EventArgs e)
        {
            SELECTED_INDEX = 2;
            removeAddressTextBoxFocus();
            this.pcPictureBox.Image = Properties.Resources.btn_pc;
            this.cloudPictureBox.Image = Properties.Resources.btn_cloud;
            this.keyPictureBox.Image = Properties.Resources.btn_key_pressed;
            switchPanel((PictureBox)sender);
        }

        private void switchPanel(PictureBox menuBtn)
        {
            if (menuBtn.Name == "pcPictureBox")
            {
                changePanelVisable(true, false, false);
            }
            else if (menuBtn.Name == "cloudPictureBox")
            {
                changePanelVisable(false, true, false);
            }
            else if (menuBtn.Name == "keyPictureBox")
            {
                changePanelVisable(false, false, true);
            }
        }

        private void changePanelVisable(bool pcPanelVisable, bool cloudPanelVisable, bool keyPanelVisable)
        {
            this.pcPanel.Visible = pcPanelVisable;
            this.cloudPanel.Visible = cloudPanelVisable;
            if (cloudPanelVisable)
            {
                if (addressContent == null || addressContent == "")
                {
                    addressTextBox.Text = Properties.Resources.address_placeholder;
                    removeAddressTextBoxFocus();
                }
                else
                {
                    addressTextBox.Text = addressContent;
                    addressTextBox.SelectionStart = addressTextBox.TextLength; 
                }
            }
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

        private void pcPictureBox_MouseHover(object sender, EventArgs e)
        {
            if (SELECTED_INDEX == 0)
            {
                this.pcPictureBox.Image = Properties.Resources.btn_pc_pressed;
            }
            else
            {
                this.pcPictureBox.Image = Properties.Resources.btn_pc_selected;
            }
        }

        private void pcPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (SELECTED_INDEX == 0)
            {
                this.pcPictureBox.Image = Properties.Resources.btn_pc_pressed;
            }
            else
            {
                this.pcPictureBox.Image = Properties.Resources.btn_pc;
            }
        }

        private void cloudPictureBox_MouseHover(object sender, EventArgs e)
        {
            if (SELECTED_INDEX == 1)
            {
                this.cloudPictureBox.Image = Properties.Resources.btn_cloud_pressed;
            }
            else
            {
                this.cloudPictureBox.Image = Properties.Resources.btn_cloud_selected;
            }
        }

        private void cloudPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (SELECTED_INDEX == 1)
            {
                this.cloudPictureBox.Image = Properties.Resources.btn_cloud_pressed;
            }
            else
            {
                this.cloudPictureBox.Image = Properties.Resources.btn_cloud;
            }
        }

        private void keyPictureBox_MouseHover(object sender, EventArgs e)
        {
            if (SELECTED_INDEX == 2)
            {
                this.keyPictureBox.Image = Properties.Resources.btn_key_pressed;
            }
            else
            {
                this.keyPictureBox.Image = Properties.Resources.btn_key_selected;
            }
        }

        private void keyPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (SELECTED_INDEX == 2)
            {
                this.keyPictureBox.Image = Properties.Resources.btn_key_pressed;
            }
            else
            {
                this.keyPictureBox.Image = Properties.Resources.btn_key;
            }
        }

        private void sendPicBox_MouseHover(object sender, EventArgs e)
        {
            this.sendPicBox.Image = Properties.Resources.btn_send_pressed;
        }

        private void sendPicBox_MouseLeave(object sender, EventArgs e)
        {
            this.sendPicBox.Image = Properties.Resources.btn_send;
        }

        private void addressTextBox_Enter(object sender, EventArgs e)
        {
            addressTextBox.Text = "";         
        }

        private void addressTextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (addressTextBox.Text == "")
            {
                addressTextBox.Text = Properties.Resources.address_placeholder;
            }
        }

        private void removeAddressTextBoxFocus()
        {
            addressContent = addressTextBox.Text;
            sendPicBox.Focus();
        }

        private void sendPicBox_Click(object sender, EventArgs e)
        {
            SendForm sendForm = new SendForm();
            sendForm.ShowDialog();
        }
    }
}
