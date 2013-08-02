using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender, EventArgs e )
        {

        }

        private void button1_MouseHover( object sender, EventArgs e )
        {
            this.button1.BackgroundImage = Properties.Resources.Button_pressed;
        }

        private void button1_MouseLeave(object sender , EventArgs e)
        {
            this.button1.BackgroundImage = Properties.Resources.Button;
        }

    }
}
