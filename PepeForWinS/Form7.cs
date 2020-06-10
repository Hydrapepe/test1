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
        public int q, tex1, tex2;
        private void Button1_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "1";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "2";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "3";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "4";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "5";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "6";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "7";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.textBox1.Text = "8";
            this.Hide();
            fr8.ShowDialog();
            this.Show();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
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
                button9.Visible = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

                label1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button6.Visible = true;
                button8.Visible = true;
                button8.Visible = true;
                label2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button5.Visible = false;
        }
    }
}
