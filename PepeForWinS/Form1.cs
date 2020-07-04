using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace PepeForWinS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size = new Size(1075, 550);
        }
        public int group, chislo, itog, q;
        public string IP_SERVER, MASK, GATEWAY, HOSTNAME, NETWORK, LASTBYTE, DOMAINNAME, REVERS_IP, NAME_POOL, LOW_RANGE, HIGE_RANGE, MASK255, NETBIOS, DOMAIN_NAME_FULL, NAME_GROUP, SERVER_NAME_FULL, SERVER_DOT_SPLIT, USER_NAME, COUNT, USER_NAME2, USER_NAME3, PASSWORD, zaglyshkaq, zaglyshka1q;

        //---------------------------------------------------------------------------------------------------
        //Main methods and other
        //---------------------------------------------------------------------------------------------------
        private void Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//exit
        private static string UTF8ToWin1251(string sourceStr)
        {
            Encoding utf8 = Encoding.UTF8;
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            byte[] utf8Bytes = utf8.GetBytes(sourceStr);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251.GetString(win1251Bytes);
        }//generate file
        private void WindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }//menu
        //---------------------------------------------------------------------------------------------------
        //Group11(Main configurate server)
        //---------------------------------------------------------------------------------------------------
        private void Button6_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = true;
            groupBox11.BringToFront();
            groupBox11.Location = new Point(200, 27);
        }//group11
        private void Button15_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = false;
            groupBox111.Visible = true;
            groupBox111.BringToFront();
            groupBox111.Location = new Point (200, 27);
        }//group111
        private void Button13_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = false;
            groupBox112.BringToFront();
            groupBox112.Visible = true;
            groupBox112.Location = new Point(200, 27);
        }//group112
        private void Button14_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = false;
            groupBox113.BringToFront();
            groupBox113.Visible = true;
            groupBox113.Location = new Point(200, 27);
        }//group113
        private void Button19_Click(object sender, EventArgs e)
        {
            IP_SERVER = textBox1.Text;
            MASK = textBox2.Text;
            GATEWAY = textBox3.Text;
            HOSTNAME = textBox7.Text;
            NETWORK = textBox5.Text;
            LASTBYTE = textBox6.Text;
            NETBIOS = textBox4.Text;
            if (!string.IsNullOrEmpty(IP_SERVER)
                && !string.IsNullOrEmpty(MASK)
                && !string.IsNullOrEmpty(GATEWAY)
                && !string.IsNullOrEmpty(HOSTNAME)
                && !string.IsNullOrEmpty(NETWORK)
                && !string.IsNullOrEmpty(LASTBYTE)
                && !string.IsNullOrEmpty(NETBIOS)) { checkBox1.Checked = true; checkBox1.ForeColor = Color.Lime; }
            if (checkBox1.Checked
                && checkBox2.Checked
                && checkBox3.Checked) { button16.Enabled = true; }
            groupBox11.Visible = true;
            groupBox11.BringToFront();
            groupBox11.Location = new Point(200, 27);
        }//GENERATE GROUP 11 part 1
        private void Button1_Click(object sender, EventArgs e)
        {
            DOMAINNAME = textBox9.Text;
            REVERS_IP = textBox8.Text;
            if (!string.IsNullOrEmpty(DOMAINNAME) && !string.IsNullOrEmpty(REVERS_IP)) { checkBox2.Checked = true; checkBox2.ForeColor = Color.Lime; }
            if (checkBox1.Checked
                && checkBox2.Checked
                && checkBox3.Checked) { button16.Enabled = true; }
            groupBox11.Visible = true;
            groupBox11.BringToFront();
            groupBox11.Location = new Point(200, 27);
        }//GENERATE GROUP 11 part 2
        private void Button12_Click(object sender, EventArgs e)
        {
            NAME_POOL = textBox13.Text;
            LOW_RANGE = textBox12.Text;
            HIGE_RANGE = textBox11.Text;
            MASK255 = textBox10.Text;
            if (!string.IsNullOrEmpty(NAME_POOL)
                && !string.IsNullOrEmpty(LOW_RANGE)
                && !string.IsNullOrEmpty(HIGE_RANGE)
                && !string.IsNullOrEmpty(MASK255)) { checkBox3.Checked = true; checkBox3.ForeColor = Color.Lime; }
            if (checkBox1.Checked
                && checkBox2.Checked
                && checkBox3.Checked) { button16.Enabled = true; }
            groupBox11.Visible = true;
            groupBox11.BringToFront();
            groupBox11.Location = new Point(200, 27);
        }//GENERATE GROUP 11 part 3
        private void Button16_Click(object sender, EventArgs e)
        {
            string[] Mars = new string[] { "pepe1.ps1", "pepe2.ps1", "pepe3.ps1" };
            string[] Europa = new string[] {
                /*КУскок 1*/ "New-NetIPAddress -InterfaceIndex 12 -IPAddress "+IP_SERVER+" –PrefixLength "+MASK+" -DefaultGateway "+GATEWAY+"\nSet-DnsClientServerAddress -InterfaceIndex 12 -ServerAddresses "+IP_SERVER+", "+IP_SERVER+"\nRename-Computer -NewName " + HOSTNAME + " -Force\nRestart-Computer -Force",
                /*КУскок 2*/ "Import-Module ServerManager\nAdd-WindowsFeature –Name AD-Domain-Services –IncludeAllSubFeature –IncludeManagementTools\nImport-Module ADDSDeployment\nInstall-ADDSForest -CreateDnsDelegation:$false -DatabasePath \"C:\\Windows\\NTDS\" -DomainMode \"Win2012\" -DomainName \"" + DOMAINNAME + "\" -DomainNetbiosName "+NETBIOS+" -ForestMode \"Win2012\" -InstallDns:$true -LogPath \"C:\\Windows\\NTDS\" -NoRebootOnCompletion:$false -SysvolPath \"C:\\Windows\\SYSVOL\" -Force:$true -SafeModeAdministratorPassword (convertto-securestring Windows1 -asplaintext -force)",
                /*КУскок 3*/ "Add-DnsServerPrimaryZone -DynamicUpdate NonsecureAndSecure -NetworkId '" + NETWORK + "/" + MASK + "' -ReplicationScope Domain\nAdd-DnsServerResourceRecordPtr -Name \"" + LASTBYTE + "\" -ZoneName \"" + REVERS_IP + ".in-addr.arpa\" -AgeRecord -PtrDomainName \"$env:COMPUTERNAME." + DOMAINNAME + "\"\nImport-Module ServerManager\nAdd-WindowsFeature –Name DHCP –IncludeManagementTools\nAdd-DHCPServerSecurityGroup -ComputerName $env:COMPUTERNAME\nRestart-Service dhcpserver\nAdd-DhcpServerInDC -DnsName $env:COMPUTERNAME -IPAddress " + IP_SERVER +"\n$User = \"$env:USERDOMAIN\\$env:USERNAME\"\n$PWord = ConvertTo-SecureString -String Windows1 -AsPlainText -Force\n$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $User, $PWord\nSet-DHCPServerDnsCredential -ComputerName $env:COMPUTERNAME -Credential $Credential\nAdd-DHCPServerv4Scope -Name " + NAME_POOL + " -StartRange " + LOW_RANGE + " -EndRange " + HIGE_RANGE + " -SubnetMask " + MASK255 + " -State Active\nSet-DHCPServerv4OptionValue -ComputerName $env:COMPUTERNAME -DnsServer " + IP_SERVER + " -DnsDomain " + DOMAINNAME + " -Router " + GATEWAY+"\nSet-DHCPServerv4OptionValue -ComputerName $env:COMPUTERNAME -ScopeId "+NETWORK+" -DnsServer "+IP_SERVER+" -DnsDomain "+DOMAINNAME+" -Router " + GATEWAY + "\nRestart-Computer -Force"};
            for (int number = 0; number != 3; number++)
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
            DialogResult = MessageBox.Show("Готово! Скрипты сгенерированы в папке с программой, Спасибо за использование PEPESOFT.");
        }//GENERATE GROUP 11 part ALL
        private void BACK1(object sender, EventArgs e)
        {
            groupBox11.Visible = true;
            groupBox11.BringToFront();
            groupBox11.Location = new Point(200, 27);
        }//Back group 11
        //---------------------------------------------------------------------------------------------------
        //Group12(Configurate User(Many))
        //---------------------------------------------------------------------------------------------------
        private void Button8_Click(object sender, EventArgs e)
        {
            groupBox12.Visible = true;
            groupBox12.BringToFront();
            groupBox12.Location = new Point(200, 27);
        }//group12
        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            group++;
            if (group % 2 == 1)
            {
                label23.Visible = true;
                label8.Visible = true;
                textBox18.Visible = true;
                textBox19.Visible = true;
            }
            else
            {
                label23.Visible = false;
                label8.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
            }
        }//checked group_user
        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            chislo++;
            if (chislo % 2 == 1)
            {
                label24.Visible = true;
                textBox21.Visible = true;
            }
            else
            {
                label24.Visible = false;
                textBox21.Visible = false;
                textBox21.Text = "1";
            }
        }//how many user generate
        private void Button2_Click(object sender, EventArgs e)
        {
            DOMAIN_NAME_FULL = textBox20.Text;
            NAME_GROUP = textBox18.Text;
            SERVER_NAME_FULL = textBox19.Text + "." + DOMAIN_NAME_FULL;
            USER_NAME = textBox17.Text;
            COUNT = textBox21.Text;
            USER_NAME2 = textBox16.Text;
            USER_NAME3 = textBox15.Text;
            PASSWORD = textBox14.Text;
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
                string zaglyshka1 = NAME_GROUP?.Length == 0
                    ? "$org=\"" + SERVER_DOT_SPLIT + "\";\n$username=\"" + USER_NAME3 + "\";\n$count=1.." + COUNT + ";\nforeach ($i in $count)\n{{New-AdUser -Name \"" + USER_NAME3 + "$i\" -GivenName \"" + USER_NAME3 + "$i\" -Surname \"" + USER_NAME2 + "$i\" -SamAccountName \"" + USER_NAME + "$i\" -UserPrincipalName \"" + USER_NAME + "$i@" + DOMAIN_NAME_FULL + "\" -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString \"" + PASSWORD + "\" -AsPlainText -force) -passThru }}"
                    : "$org=\"OU=" + NAME_GROUP + "," + SERVER_DOT_SPLIT + "\"" +
                      "\n$username=\"" + USER_NAME3 + "\"" +
                      "\n$count=1.." + COUNT +
                      "\nforeach ($i in $count)\n{New-AdUser -Name \"" + USER_NAME3 + "$i\" -GivenName \"" + USER_NAME3 + "$i\" -Surname \"" + USER_NAME2 + "$i\" -SamAccountName \"" + USER_NAME + "$i\" -UserPrincipalName \"" + USER_NAME + "$i@" + DOMAIN_NAME_FULL + "\" -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString \"" + PASSWORD + "\" -AsPlainText -force) -passThru }";

                string zaglyshkaqq = zaglyshka + zaglyshka1;

                        try
                        {
                            using (FileStream fs = File.Create("user.ps1"))
                            {
                                Encoding win1251 = Encoding.GetEncoding(1251);
                                string info = UTF8ToWin1251(zaglyshkaqq);
                                using (var sr = new StreamWriter(fs, win1251))
                                {
                                    sr.Write(info);
                                }
                            }
                        }
                        catch {}
            }
        }//generate group user and\or user(one\more)
        //---------------------------------------------------------------------------------------------------
        //Group13(Configurate User(unique))
        //---------------------------------------------------------------------------------------------------
        private void Button9_Click(object sender, EventArgs e)
        {
            groupBox13.Visible = true;
            groupBox13.BringToFront();
            groupBox13.Location = new Point(200, 27);
            q = 1;
        }//group13
        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            group++;
            if (group % 2 == 1)
            {
                label31.Visible = true;
                label25.Visible = true;
                textBox26.Visible = true;
                textBox27.Visible = true;
            }
            else
            {
                label31.Visible = false;
                label25.Visible = false;
                textBox26.Visible = false;
                textBox27.Visible = false;
            }
        }//checked group
        public void Button11_Click(object sender, EventArgs e)
        {
            DOMAIN_NAME_FULL = textBox28.Text;
            if (!checkBox7.Checked)
            { NAME_GROUP = textBox26.Text; }
            SERVER_NAME_FULL = textBox27.Text + "." + DOMAIN_NAME_FULL;
            USER_NAME = textBox25.Text;
            USER_NAME2 = textBox24.Text;
            USER_NAME3 = textBox23.Text;
            PASSWORD = textBox22.Text;

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
                if (checkBox4.Checked)
                {
                        zaglyshkaq = zaglyshkaq + "New-ADOrganizationalUnit -Name:\"" + NAME_GROUP + "\" -Path:\"" + SERVER_DOT_SPLIT + "\" -ProtectedFromAccidentalDeletion:$true -Server:\"" + SERVER_NAME_FULL + "\"\n";
                }
                zaglyshka1q = zaglyshkaq?.Length == 0
                    ? zaglyshka1q + "$org=\"" + SERVER_DOT_SPLIT + "\";\n$username=\"" + USER_NAME3 + "\";\n$count=1;\nforeach ($i in $count)\n{New-AdUser -Name \"" + USER_NAME3 + "\" -GivenName \"" + USER_NAME3 + "\" -Surname \"" + USER_NAME2 + "\" -SamAccountName \"" + USER_NAME + "\" -UserPrincipalName \"" + USER_NAME + "@" + DOMAIN_NAME_FULL + "\" -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString \"" + PASSWORD + "\" -AsPlainText -force) -passThru }"
                    : zaglyshka1q + "$org=\"OU=" + NAME_GROUP + "," + SERVER_DOT_SPLIT + "\"" +
                      "\n$username=\"" + USER_NAME3 + "\"" +
                      "\n$count=1" +
                      "\nforeach ($i in $count)\n{New-AdUser -Name \"" + USER_NAME3 + "\" -GivenName \"" + USER_NAME3 + "\" -Surname \"" + USER_NAME2 + "\" -SamAccountName \"" + USER_NAME + "\" -UserPrincipalName \"" + USER_NAME + "@" + DOMAIN_NAME_FULL + "\" -Path $org -Enabled $True -ChangePasswordAtLogon $true -AccountPassword (ConvertTo-SecureString \"" + PASSWORD + "\" -AsPlainText -force) -passThru }\n";
            }
            textBox28.Text = textBox26.Text = textBox27.Text = textBox25.Text = textBox24.Text = textBox23.Text = textBox22.Text = PASSWORD = USER_NAME3= USER_NAME2=USER_NAME= SERVER_NAME_FULL= DOMAIN_NAME_FULL="";
            label32.Text= "Всего сгенерируется пользователей :"+q++;
            checkBox7.Visible = true;
        }//memory user
        public void Button7_Click(object sender, EventArgs e)
        {
            string zaglyshkaqq= zaglyshkaq + zaglyshka1q;
            try
            {
                using (FileStream fs = File.Create("user.ps1"))
                {
                    Encoding win1251 = Encoding.GetEncoding(1251);
                    string info = UTF8ToWin1251(zaglyshkaqq);
                    using (var sr = new StreamWriter(fs, win1251))
                    {
                        sr.Write(info);
                    }
                }
            }
            catch { }
        }//generate user
    }
}