using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepeForWinS
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public int tex1, tex2;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                label2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button5.Visible = true;
                label1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

                label1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button6.Visible = true;
                button8.Visible = true;
                label2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button5.Visible = false;
        }
    }
}
