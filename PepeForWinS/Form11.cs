using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PepeForWinS
{
    public partial class Form11 : Form
    {
        public int group,chislo,itog;  
        public string DOMAIN_NAME_FULL, NAME_GROUP, SERVER_NAME_FULL, SERVER_DOT_SPLIT, USER_NAME,COUNT, USER_NAME2, USER_NAME3, PASSWORD;

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            group += 1;
            if (group % 2 == 1)
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else 
            {
                label2.Visible = false;
                label3.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
        }

        public Form11()
        {
            InitializeComponent();
        }

        public void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            chislo += 1;
            if (chislo % 2 == 1)
            {
                label1.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label1.Visible = false;
                textBox1.Visible = false;
                textBox1.Text = "1";
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            DOMAIN_NAME_FULL = textBox2.Text;
            NAME_GROUP = textBox3.Text;
            SERVER_NAME_FULL = textBox4.Text + DOMAIN_NAME_FULL;
            USER_NAME = textBox5.Text;
            COUNT = textBox1.Text;
            USER_NAME2 = textBox6.Text;
            USER_NAME3 = textBox7.Text;
            PASSWORD = textBox8.Text;

            string[] words = DOMAIN_NAME_FULL.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                words[0] = "DC=" + words[0] + ",";
                SERVER_DOT_SPLIT = words[0];
                words[1] = "DC=" + words[1] + ",";
                SERVER_DOT_SPLIT += words[1];
                words[2] = "DC=" + words[2] + ",";
                SERVER_DOT_SPLIT += words[2];
                words[3] = "DC=" + words[3] + ",";
                SERVER_DOT_SPLIT += words[3];
                words[4] = "DC=" + words[4] + ",";
                SERVER_DOT_SPLIT += words[4];
                words[5] = "DC=" + words[5];
                SERVER_DOT_SPLIT += words[5];
            }
            catch
            {
                string zaglyshka = "New-ADOrganizationalUnit -Name:" + NAME_GROUP + "-Path:" + SERVER_DOT_SPLIT + " -ProtectedFromAccidentalDeletion:$true -Server:" + SERVER_NAME_FULL + "";
                string zaglyshka1 = "{$org=\"OU=" + NAME_GROUP + "," + SERVER_DOT_SPLIT + "\"" + 
                    "\n$username=" + USER_NAME + 
                    "\n$count=1.." + COUNT +
                    "\nforeach ($i in $count)\n{New-AdUser -Name $username$i" + "-GivenName \"" + USER_NAME3 + "$i" + "\"" + "-Surname " + "\"" + USER_NAME2 + "$i" + "\"" + "- SamAccountName " + "\"" + USER_NAME + "$i" + "\"" + "-UserPrincipalName " + "\"" + "$username$i@" + DOMAIN_NAME_FULL + "\"" + " -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString" + "\"" + PASSWORD +"\""+ "-AsPlainText - force) - passThru}}";

                if (group % 2 == 1) {itog=1;}
                else { itog = 0; }
                switch (itog)
                {
                    case 1:
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "powershell.exe",
                            Arguments = zaglyshka,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }).WaitForExit();
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "powershell.exe",
                            Arguments = zaglyshka1,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }).WaitForExit();
                        checkBox3.Checked = true;
                        checkBox3.ForeColor = Color.Lime;
                        checkBox3.Visible = true;
                        break;
                    case 0:
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "powershell.exe",
                            Arguments = zaglyshka1,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }).WaitForExit();
                        checkBox3.Checked = true;
                        checkBox3.ForeColor = Color.Lime;
                        checkBox3.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}


