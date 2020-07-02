using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PepeForWinS
{
    public partial class Form11 : Form
    {

        public void Button1_Click(object sender, EventArgs e)
        {
            DOMAIN_NAME_FULL = textBox2.Text;
            NAME_GROUP = textBox3.Text;
            SERVER_NAME_FULL = textBox4.Text + "." + DOMAIN_NAME_FULL;
            USER_NAME = textBox5.Text;
            COUNT = textBox1.Text;
            USER_NAME2 = textBox6.Text;
            USER_NAME3 = textBox7.Text;
            PASSWORD = textBox8.Text;

            string[] words = DOMAIN_NAME_FULL.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                words[0] = "DC=" + words[0];
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
                string zaglyshka = "New-ADOrganizationalUnit -Name:\"" + NAME_GROUP + "\" -Path:\"" + SERVER_DOT_SPLIT + "\" -ProtectedFromAccidentalDeletion:$true -Server:\"" + SERVER_NAME_FULL + "\"";
                zaglyshka1 = NAME_GROUP?.Length == 0
                    ? "$org=\"" + SERVER_DOT_SPLIT + "\";\n$username=\"" + USER_NAME3 + "\";\n$count=1.." + COUNT + ";\nforeach ($i in $count)\n{{New-AdUser -Name \"" + USER_NAME3 + "$i\" -GivenName \"" + USER_NAME3 + "$i\" -Surname \"" + USER_NAME2 + "$i\" -SamAccountName \"" + USER_NAME + "$i\" -UserPrincipalName \"" + USER_NAME + "$i@" + DOMAIN_NAME_FULL + "\" -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString \"" + PASSWORD + "\" -AsPlainText -force) -passThru }}"
                    : "$org=\"OU=" + NAME_GROUP + "," + SERVER_DOT_SPLIT + "\"" +
                     "\n$username=\"" + USER_NAME3 + "\"" +
                     "\n$count=1.." + COUNT +
                     "\nforeach ($i in $count)\n{New-AdUser -Name \"" + USER_NAME3 + "$i\" -GivenName \"" + USER_NAME3 + "$i\" -Surname \"" + USER_NAME2 + "$i\" -SamAccountName \"" + USER_NAME + "$i\" -UserPrincipalName \"" + USER_NAME + "$i@" + DOMAIN_NAME_FULL + "\" -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString \"" + PASSWORD + "\" -AsPlainText -force) -passThru }";
                string[] Mars = new string[] { "group.ps1", "userM.ps1" };
                string[] Europa = new string[] { zaglyshka, zaglyshka1 };
                if (group % 2 == 1)
                {
                    for (int number = 0; number != 2; number++)
                    {
                        try
                        {
                            using (FileStream fs = File.Create(Mars[number]))
                            {
                                Encoding win1251 = Encoding.GetEncoding(1251);
                                string info = UTF8ToWin1251(Europa[number]);
                                using (var sr = new StreamWriter(fs, win1251))
                                {
                                    sr.Write(info);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    checkBox3.Checked = true;
                    checkBox3.ForeColor = Color.Lime;
                    checkBox3.Visible = true;
                }
                else
                {
                    try
                    {
                        using (FileStream fs = File.Create("userO.ps1"))
                        {
                            Encoding win1251 = Encoding.GetEncoding(1251);
                            string info = UTF8ToWin1251(zaglyshka1);
                            using (var sr = new StreamWriter(fs, win1251))
                            {
                                sr.Write(info);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    checkBox3.Checked = true;
                    checkBox3.ForeColor = Color.Lime;
                    checkBox3.Visible = true;
                }
            }
        }
    }
}