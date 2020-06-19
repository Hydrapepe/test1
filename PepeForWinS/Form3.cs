﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace PepeForWinS
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2 != null)
            {
                form2.IP_SERVER = textBox1.Text;
                form2.MASK = textBox2.Text;
                form2.GATEWAY = textBox3.Text;
                form2.HOSTNAME = textBox4.Text;
                form2.NETWORK = textBox5.Text;
                form2.LASTBYTE = textBox6.Text;
                form2.NAME_USER = textBox7.Text;
            }
            if (!string.IsNullOrEmpty(form2.IP_SERVER)
                && !string.IsNullOrEmpty(form2.MASK)
                && !string.IsNullOrEmpty(form2.GATEWAY)
                && !string.IsNullOrEmpty(form2.HOSTNAME)
                && !string.IsNullOrEmpty(form2.NETWORK)
                && !string.IsNullOrEmpty(form2.LASTBYTE)
                && !string.IsNullOrEmpty(form2.NAME_USER)) { form2.checkBox1.Checked = true; form2.checkBox1.ForeColor = Color.Lime; }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}