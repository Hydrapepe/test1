using System;
using System.IO.Pipes;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace PepeForWinS
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public string NAME_POLISY,text,DOMAIN_NAME_FULL, NAME_GROUP,SERVER_DOT_SPLIT;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
                button3.Enabled = true;
                DOMAIN_NAME_FULL = textBox3.Text;
                NAME_POLISY = textBox1.Text;
                NAME_GROUP = textBox2.Text;

                string[] words = DOMAIN_NAME_FULL.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    words[0] = "OU="+NAME_GROUP+ ",DC=" + words[0];
                    SERVER_DOT_SPLIT = words[0];
                    words[1] = ",DC=" + words[1];
                    SERVER_DOT_SPLIT += words[1];
                    words[2] = ",DC=" + words[2];
                    SERVER_DOT_SPLIT += words[2];
                    words[3] = ",DC=" + words[3];
                    SERVER_DOT_SPLIT += words[3];
                    words[4] = ",DC=" + words[4];
                    SERVER_DOT_SPLIT += words[4];
                    words[5] = ",DC=" + words[5];
                    SERVER_DOT_SPLIT += words[5];
                }
                catch
                {
                    text = "New-GPO -Name \"" + NAME_POLISY + "\" | New-GPLink -Target \""+SERVER_DOT_SPLIT+"\"\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKCU\\Software\\Policies\\Microsoft\\Windows\\System\" -ValueName DisableCMD -Type DWord -Value 1\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\" -ValueName NoRun -Type DWord -Value 1\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\" -ValueName DisableRegistryTools -Type DWord -Value 1\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\" -ValueName NoControlPanel -Type DWord -Value 1\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\" -ValueName ScreenSaveActive -Type String -Value 0\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ActiveDesktop\" -ValueName NoChangingWallPaper -Type DWord -Value 1\nSet-GPRegistryValue -Name \"" + NAME_POLISY + "\" -Key \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon\" - ValueName EnableFirstLogonAnimation  -Type DWord -Value 0";
                    using (FileStream fs = File.Create("polisy.ps1"))
                    {
                        Encoding win1251 = Encoding.GetEncoding(1251);
                        string info = UTF8ToWin1251(text);
                        using (var sr = new StreamWriter(fs, win1251))
                        {
                            sr.Write(info);
                        }
                    }
                }
            }
        private static string UTF8ToWin1251(string sourceStr)
        {
            Encoding utf8 = Encoding.UTF8;
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            byte[] utf8Bytes = utf8.GetBytes(sourceStr);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251.GetString(win1251Bytes);
        }
    }
}