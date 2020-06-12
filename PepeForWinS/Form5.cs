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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2 != null)
            {
                form2.NAME_POOL = textBox1.Text;
                form2.LOW_RANGE = textBox2.Text;
                form2.HIGE_RANGE = textBox3.Text;
                form2.MASK255 = textBox4.Text;
            }
            if (!(String.IsNullOrEmpty(form2.NAME_POOL)) && !(String.IsNullOrEmpty(form2.LOW_RANGE)) && !(String.IsNullOrEmpty(form2.HIGE_RANGE)) && !(String.IsNullOrEmpty(form2.MASK255))) { form2.checkBox3.Checked = true; form2.checkBox3.ForeColor = Color.Lime; }
            if ((form2.checkBox1.Checked == true) && (form2.checkBox2.Checked == true) && (form2.checkBox3.Checked == true)) { form2.button1.Enabled = true; }
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
