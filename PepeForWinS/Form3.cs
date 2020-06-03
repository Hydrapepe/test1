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
                form2.NAME_USER = textBox8.Text;
            }
            if (!(String.IsNullOrEmpty(form2.IP_SERVER)) & !(String.IsNullOrEmpty(form2.MASK)) & !(String.IsNullOrEmpty(form2.GATEWAY)) & !(String.IsNullOrEmpty(form2.HOSTNAME)) & !(String.IsNullOrEmpty(form2.NETWORK)) & !(String.IsNullOrEmpty(form2.LASTBYTE)) & !(String.IsNullOrEmpty(form2.NAME_USER)) & !(String.IsNullOrEmpty(form2.PASSWORD))) { form2.checkBox1.Checked = true; form2.checkBox1.ForeColor = Color.Lime; }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
