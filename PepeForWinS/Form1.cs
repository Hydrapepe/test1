using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace PepeForWinS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            this.Hide();
            fr2.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form11 fr11 = new Form11();
            this.Hide();
            fr11.ShowDialog();
            this.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form21 fr21 = new Form21();
            this.Hide();
            fr21.ShowDialog();
            this.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            this.Hide();
            fr7.ShowDialog();
            this.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Hide();
            fr6.ShowDialog();
            this.Show();
        }
    }
}
