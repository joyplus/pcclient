﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace UpdateDemo
{
    public partial class UpdateForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private string SERVER_ADDRESS = "http://upgrade.joyplus.tv/pcclient/";
        private string VERSION_FILE_NAME = "pcclient_version.txt";
        private string VERSION_REGISTER_KEY = "joyplus_pcclient_version_key";
        private string SETTING_AUTO_UPDATE = "joyplus_pcclient_auto_update";
        private string SETTING_EXIST_OPTION = "joyplus_pcclient_exist_option";
        private string PCCLIENT_EXE_FILE_NAME = "Showkey电视助手.exe";

        private bool changed;
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.headerPicBox.Parent = this;
            this.closePicbox.Parent = headerPicBox;

            string autoUpdate = ReadInfo(SETTING_AUTO_UPDATE);
            if (autoUpdate == "1")
            {
                autoUpdateCheckBox.Checked = true;
            }
            else
            {
                autoUpdateCheckBox.Checked = false;
            }

            string existOption = ReadInfo(SETTING_EXIST_OPTION);
            if (existOption == "1")
            {
                this.exitRadio.Checked = true;
                this.minRadio.Checked = false;
            }
            else
            {
                this.exitRadio.Checked = false;
                this.minRadio.Checked = true;
            }
        }

        private void closePicbox_MouseHover(object sender, EventArgs e)
        {
            this.closePicbox.Image = Properties.Resources.btn_cloose_pressed;
        }

        private void closePicbox_MouseLeave(object sender, EventArgs e)
        {
            this.closePicbox.Image = Properties.Resources.btn_close;
        }
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数
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
            oPath.AddArc(x, h - a / 2, a, a, 90, 90);
            oPath.CloseAllFigures();
            Region = new Region(oPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
       /*     this.smoothProgressBar1.Value = 0;

            this.timer1.Interval = 1;
            this.timer1.Enabled = true;*/

            string latestVersion = getLatestVersion();
            string currentVersion = ReadInfo(VERSION_REGISTER_KEY);
            bool needUpdate = false;
            if (latestVersion != null)
            {
                if (currentVersion == null || currentVersion == "")
                {
                    if (latestVersion != "1.0" && latestVersion != "1.0.0")
                    {
                        needUpdate = true;
                    }
                }
                else
                {
                    if (currentVersion.CompareTo(latestVersion) < 0)
                    {
                        needUpdate = true;
                    }
                }
               
            }
            if (needUpdate)
            {
                triggerUpdate();
            }
            else
            {
                MessageBox.Show("已经是最新！");
            }
        }

        public void triggerUpdate()
        {
            startDownloadExe();
        }

        private void startDownloadExe()
        {
            WebClient client = new WebClient();
            WebClient ws = new WebClient();
            ws.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnDownloadProgressChanged);
            //绑定下载事件，以便于显示当前进度
            ws.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadFileCompleted);
            //绑定下载完成事件，以便于计算总进度
            ws.DownloadFileAsync(new Uri(SERVER_ADDRESS + VERSION_FILE_NAME), PCCLIENT_EXE_FILE_NAME); 

        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
         //   progbar_single.Value = e.ProgressPercentage;
         //   lbl_singleInfo.Text = "已下载" + e.BytesReceived + "字节/总计" + e.TotalBytesToReceive + "字节";//一个label框，用来显示当前下载的数据
        }
        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("complied!");//计算总下载进度，因为我在服务端XML文件里可以得到文件大小，所以我直接用服务端数据，我回头再看看有没有什么好办法

        }

        public string getLatestVersion()
        {
            WebClient client = new WebClient();
            Stream fs = client.OpenRead(SERVER_ADDRESS + VERSION_FILE_NAME);
            StreamReader sr = new StreamReader(fs);
            string version = null;
            string line = null;
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                int index = line.IndexOf("=");
                if (index > 0)
                {
                    string key = line.Substring(0, index);
                    if (key == "version")
                    {
                        version = line.Substring(index + 1);
                        break;
                    }
                }
            }
            sr.Close();
            fs.Close();
            return version;
        }

        /// <summary>
        /// 定义本软件在注册表中software下的公司名和软件名称
        /// </summary>
        private string m_companyname = "Joyplus", m_softwarename = "PCClient";
        /// <summary>
        /// 从注册表中读信息;
        /// </summary>
        /// <param name="p_KeyName">要读取的键值</param>
        /// <returns>读到的键值字符串,如果失败(如注册表尚无信息),则返回""</returns>
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
        /// <summary>
        /// 将信息写入注册表
        /// </summary>
        /// <param name="p_keyname">键名</param>
        /// <param name="p_keyvalue">键值</param>
        private void WriteInfo(string p_keyname, string p_keyvalue)
        {
            RegistryKey SoftwareKey = Registry.LocalMachine.OpenSubKey("Software", true);
            RegistryKey CompanyKey = SoftwareKey.CreateSubKey(m_companyname);
            RegistryKey SoftwareNameKey = CompanyKey.CreateSubKey(m_softwarename);
            //写入相应信息
            SoftwareNameKey.SetValue(p_keyname, p_keyvalue);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*   if (this.smoothProgressBar1.Value < 100)
               {
                   this.smoothProgressBar1.Value++;

               }
               else
               {
                   this.timer1.Enabled = false;
               }*/
        }

        private void closePicbox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            changed = false;
            saveSettings();
            applyBtn.Enabled = false;
        }

        private void saveSettings()
        {
            if (this.autoUpdateCheckBox.Checked)
            {
                WriteInfo(SETTING_AUTO_UPDATE, "1");
            }
            else
            {
                WriteInfo(SETTING_AUTO_UPDATE, "0");
            }

            if (this.exitRadio.Checked)
            {
                WriteInfo(SETTING_EXIST_OPTION, "1");
            }
            else
            {
                WriteInfo(SETTING_EXIST_OPTION, "0");
            }

        }

        private void autoUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void minRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void exitRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }
    }
}
