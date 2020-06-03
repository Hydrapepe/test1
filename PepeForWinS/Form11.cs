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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 fr12 = new Form12();
            this.Hide();
            fr12.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 fr13 = new Form13();
            this.Hide();
            fr13.ShowDialog();
            this.Show();
        }
    }
}
