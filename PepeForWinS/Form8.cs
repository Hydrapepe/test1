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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form9 fr9 = new Form9();
            fr9.textBox1.Text = textBox1.Text;
            fr9.textBox2.Text = "1";
            this.Hide();
            fr9.ShowDialog();
            this.Show();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Form9 fr9 = new Form9();
            fr9.textBox1.Text = textBox1.Text;
            fr9.textBox2.Text = "2";
            this.Hide();
            fr9.ShowDialog();
            this.Show();
        }
    }
}
