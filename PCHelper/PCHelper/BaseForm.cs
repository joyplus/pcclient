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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms.Samples;
using Microsoft.Win32; 

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
        private bool connectedToShowkey;
        private bool showPanelShare = false;
        private string UPDATE_PROGRAM_NAME = "SettingsForm.exe";
        private string VERSION_REGISTER_KEY = "joyplus_pcclient_version_key";
        private string versionString;
        Process updateProcess;
        private DirectoryVideo _dir;

        TreeViewForm treeviewForm = null;

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
            settingPicBox.Parent = this.headerPicture;
            pcPictureBox.Location = new Point(0, 0);
            pcPictureBox.Parent = menuBgPic;

            cloudPictureBox.Location = new Point(140, 0);
            cloudPictureBox.Parent = menuBgPic;

            keyPictureBox.Location = new Point((140) * 2, 0);
            keyPictureBox.Parent = menuBgPic;

            pcPanel.Location = new Point(0, 124);
            pcPanel.Parent = this;
            cloudPanel.Parent = this;
            cloudPanel0.Parent = this;
            cloudPanel.Location = pcPanel.Location;
            cloudPanel0.Location = pcPanel.Location;
            keyPanel.Location = pcPanel.Location;
            sharePicBox.Parent = pcPanel;
            
            pcPanelShare.Parent = this;
            pcPanelShare.Location = pcPanel.Location;

            unbindedLabel.Parent = unbindPicBox;
            unbindedLabel.Location = new Point(17, 7);
            pushListPicBox.Parent = unbindPicBox;
            pushListPicBox.Location = new Point(791, 9);
            pushListLabel.Parent = unbindPicBox;
            pushListLabel.Location = new Point(807, -9);

            bindLabel.Parent = bindPicBox;
            bindLabel.Location = new Point(17, 7);
            bindPushPicBox.Parent = bindPicBox;
            bindPushPicBox.Location = new Point(791, 9);
            bindPushLabel.Parent = bindPicBox;
            bindPushLabel.Location = new Point(807, -9);
            rebindLabel.Parent = bindPicBox;
            rebindLabel.Location = new Point(257, 8);

            settingPicBox.Image = null;
            settingPicBox.Image = Properties.Resources.btn_setting;
            pictureBox_Min.Image = null;
            pictureBox_Min.Image = Properties.Resources.btn_min;
            pictureBox_Close.Image = null;
            pictureBox_Close.Image = Properties.Resources.btn_close;

            //versionString = ReadInfo(VERSION_REGISTER_KEY);
            versionString = "1.0.1";
            versionLabel.Text = "版本：" + versionString;
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
                    if (updateProcess != null && !updateProcess.HasExited)
                    {
                        try
                        {
                            updateProcess.CloseMainWindow();
                        }
                        finally
                        {

                        }
                    }
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

        private void VideoFileLoad()
        {
            // Set Initial Directory to My Documents
            _dir = new DirectoryVideo ( );
            this.FileViewBindingSource.DataSource = _dir;

            // Set Size column to right align
            DataGridViewColumn col = this.dataGridView1.Columns["PathCol"];

            if (null != col)
            {
                DataGridViewCellStyle style = col.HeaderCell.Style;

                style.Padding = new Padding ( style.Padding.Left, style.Padding.Top, 6, style.Padding.Bottom );
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Select first item
            col = this.dataGridView1.Columns["Name"];

            if (null != col)
            {
                this.dataGridView1.Rows[0].Cells[col.Index].Selected = true;
            }
        }

        private void dataGridView1_CellFormatting ( object sender, DataGridViewCellFormattingEventArgs e )
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "PathCol")
            {
                e.Value = "C:\\Document";
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "VideoNumCol")
            {
                e.Value = "7";
            }
        }

        private void dataGridView1_CellPainting ( object sender, DataGridViewCellPaintingEventArgs e )
        {
            Icon icon = (e.Value as Icon);

            if (null != icon)
            {
                using (SolidBrush b = new SolidBrush ( e.CellStyle.BackColor ))
                {
                    e.Graphics.FillRectangle ( b, e.CellBounds );
                }

                // Draw right aligned icon (1 pixed padding)
                e.Graphics.DrawIcon ( icon, e.CellBounds.Width - icon.Width - 1, e.CellBounds.Y + 1 );
                e.Handled = true;
            }
        }

        private void dataGridView1_RowPrePaint ( object sender, DataGridViewRowPrePaintEventArgs e )
        {

        }

        private void dataGridView1_CellMouseDoubleClick ( object sender, DataGridViewCellMouseEventArgs e )
        {
            // Call Active on DirectoryView
            try
            {
                _dir.Activate ( this.FileViewBindingSource[e.RowIndex] as FileVideo );
            }
            catch (Exception ex)
            {
                MessageBox.Show ( ex.Message );
            }
        }

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
                changePanelVisable ( false, true, false );
            }
            else if (menuBtn.Name == "keyPictureBox")
            {
                changePanelVisable(false, false, true);
            }
        }

        private void changePanelVisable(bool pcPanelVisable, bool cloudPanelVisable, bool keyPanelVisable)
        {
            this.pcPanel.Visible = pcPanelVisable;
            this.keyPanel.Visible = keyPanelVisable;
            if(pcPanelVisable)
            {
                if(showPanelShare)
                {
                    this.pcPanel.Visible = false;
                    this.pcPanelShare.Visible = true;
                    VideoFileLoad ( );
                }
                else
                {
                    this.pcPanelShare.Visible = false;
                    this.pcPanel.Visible = true;
                }
            }

            if(cloudPanelVisable){
                if (connectedToShowkey)
                {
                    this.cloudPanel.Visible = true;
                    this.cloudPanel0.Visible = false;
                }
                else
                {
                    this.cloudPanel.Visible = false;
                    this.cloudPanel0.Visible = true;
                }
            }else{
                this.cloudPanel0.Visible = false;
                this.cloudPanel.Visible = false;
            }
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

        private void pinTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pinTextBox.Text.Length == 6)
            {
                connectedToShowkey = true;
                changePanelVisable(false, true, false);
            }
        }

        private void pushPicBox_MouseHover(object sender, EventArgs e)
        {
            pushPicBox.Image = Properties.Resources.btn_push_pressed;
        }

        private void pushPicBox_MouseLeave(object sender, EventArgs e)
        {
            pushPicBox.Image = Properties.Resources.btn_push;
        }

        private void pushListPicBox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pushListPicBox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pushListPicBox_Click(object sender, EventArgs e)
        {
            SendForm sendForm = new SendForm();
            sendForm.Location = new Point(this.Location.X + 150, this.Location.Y + 120);
            sendForm.ShowDialog();
        }

        private void pushPicBox_Click(object sender, EventArgs e)
        {
			
        }

        private void settingPicBox_Click(object sender, EventArgs e)
        {
            if (updateProcess == null || updateProcess.HasExited)
            {
                string filename = Application.StartupPath + "\\" + UPDATE_PROGRAM_NAME;
                updateProcess = System.Diagnostics.Process.Start(filename, "");
            }
        }

        private void settingPicBox_MouseHover(object sender, EventArgs e)
        {
            this.settingPicBox.Image = Properties.Resources.btn_setting_pressed;
        }

        private void settingPicBox_MouseLeave(object sender, EventArgs e)
        {
            this.settingPicBox.Image = Properties.Resources.btn_setting;
        }

        private void addLabe_Click(object sender, EventArgs e)
        {
                treeviewForm = new TreeViewForm ( );
                treeviewForm.ShowDialog ( );
            
        }

        private void sharePicBox_Click(object sender, EventArgs e)
        {
            showPanelShare = true;
            changePanelVisable ( true, false, false );
        }

        private void tianmaoPicBox_MouseHover(object sender, EventArgs e)
        {
            this.tianmaoPicBox.Image = Properties.Resources.btn_tianmao_pressed;
        }

        private void tianmaoPicBox_MouseLeave(object sender, EventArgs e)
        {
            this.tianmaoPicBox.Image = Properties.Resources.btn_tianmao;
        }

        private void tianmaoPicBox_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\"); 
            string s = key.GetValue("").ToString(); 
 
            Regex reg = new Regex("\"([^\"]+)\""); 
            MatchCollection matchs = reg.Matches(s); 
 
            string filename=""; 
            if (matchs.Count > 0)
            { 
                filename = matchs[0].Groups[1].Value;
                System.Diagnostics.Process.Start(filename, "http://detail.tmall.com/item.htm?spm=a1z10.1.w5002-2393934093.3.11H9cs&id=18823181677&bucket_id=190"); 
            } 
        }

        private void rebindLabel_Click(object sender, EventArgs e)
        {
            connectedToShowkey = false;
            changePanelVisable(false, true, false);
        }

        private void StartScanBtn_Click(object sender, EventArgs e)
        {
            this.StartScanBtn.Visible = false;
            this.StopScanBtn.Visible = true;
        }

        private void StopScanBtn_Click(object sender, EventArgs e)
        {
            this.StartScanBtn.Visible = true;
            this.StopScanBtn.Visible = false;
        }

        private string m_companyname = "Joyplus", m_softwarename = "PCClient";
        private string ReadInfo(string p_KeyName)
        {
            RegistryKey SoftwareKey = Registry.LocalMachine.OpenSubKey("Software", true);
            RegistryKey CompanyKey = SoftwareKey.OpenSubKey(m_companyname);
            string strValue = "";

            if (CompanyKey == null)
                return "";
            RegistryKey SoftwareNameKey = CompanyKey.OpenSubKey(m_softwarename);//建立
            if (SoftwareNameKey == null)
                return "";

            try
            {
                strValue = SoftwareNameKey.GetValue(p_KeyName).ToString().Trim();
            }
            catch
            { }

            if (strValue == null)
                strValue = "";
            return strValue;
        }
    }
}
