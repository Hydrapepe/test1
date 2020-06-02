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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2 != null)
            {
                form2.DOMAINNAME = textBox1.Text;
                form2.REVERS_IP = textBox2.Text;
            }
            if (!(String.IsNullOrEmpty(form2.DOMAINNAME)) && !(String.IsNullOrEmpty(form2.REVERS_IP))) { form2.checkBox2.Checked = true; form2.checkBox2.ForeColor = Color.Lime; }
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
