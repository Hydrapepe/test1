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
            if (File.Exists("textsuka2.txt"))
            {
                Form6 fr6 = new Form6();
                this.Hide();
                fr6.ShowDialog();
                this.Show();
                File.Delete("text.txt");
                File.Delete("textsuka.txt");
                File.Delete("textsuka2.txt");
                /*Удаление из автозапуска*/
                string progName = "";
                string run = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
                Registry.SetValue(run, "Prog", progName);
            }
            Fuck();
        }
        public void Fuck()
        {
            if (File.Exists("text.txt"))
            {
               Process.Start("pepe2.ps1");
                using (FileStream fs = File.Create("textsuka.txt"))
                {
                    string info = "";
                    using (var sr = new StreamWriter(fs))
                    {
                        sr.Write(info);
                    }
                }
            }

            if (File.Exists("textsuka.txt"))
            {
                File.Delete("text.txt");
                using (FileStream fs1 = File.Create("textsuka2.txt"))
                {
                    string info = "";
                    using (var sr = new StreamWriter(fs1))
                    {
                        sr.Write(info);
                    }
                }

            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form11 fr11 = new Form11();
            fr11.Show();
            Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form21 fr21 = new Form21();
            fr21.Show();
            Hide();
        }
    }
}
