using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCHelper
{
    public partial class SendForm : Form
    {
        public SendForm()
        {
            InitializeComponent();
        }


        private void SendForm_Load(object sender, EventArgs e)
        {
            this.subformHeaderPicBox.Parent = this;
            subformClose.Parent = subformHeaderPicBox;
        }

        private void subformClose_MouseHover(object sender, EventArgs e)
        {
            subformClose.Image = Properties.Resources.btn_close_pressed;
        }

        private void subformClose_MouseLeave(object sender, EventArgs e)
        {
            subformClose.Image = Properties.Resources.btn_close;
        }

        private void subformClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
