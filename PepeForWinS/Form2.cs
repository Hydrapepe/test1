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

namespace PepeForWinS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        { 
            HOLLY_TERRA();
        }

        public string IP_SERVER,MASK, GATEWAY, HOSTNAME,NETWORK, LASTBYTE,DOMAINNAME, REVERS_IP, NAME_POOL, LOW_RANGE, HIGE_RANGE, MASK255, NAME_USER,PASSWORD;
        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            this.Hide();
            fr3.ShowDialog();
            this.Show();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Hide();
            fr4.ShowDialog();
            this.Show();
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static string UTF8ToWin1251(string sourceStr)
            {
                 Encoding utf8 = Encoding.UTF8;
                 Encoding win1251 = Encoding.GetEncoding("Windows-1251");
                 byte[] utf8Bytes = utf8.GetBytes(sourceStr);
                 byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
                 return win1251.GetString(win1251Bytes);
            }
        public void HOLLY_TERRA()
        {
            string[] Mars = new string[] { "pepe1.ps1", "pepe2.ps1"};
            string[] Europa = new string[] {
                /*КУскок 1*/ "New-NetIPAddress -InterfaceIndex 12 -IPAddress "+IP_SERVER+" –PrefixLength "+MASK+" -DefaultGateway "+GATEWAY+"\nSet-DnsClientServerAddress -InterfaceIndex 12 -ServerAddresses "+IP_SERVER+", "+IP_SERVER+"\nRename-Computer -NewName " + HOSTNAME + " -Force\n$pword = ConvertTo-SecureString -String \""+PASSWORD+"\" -AsPlainText -Force\nSet-LocalUser -Name "+NAME_USER+" -Password $pword\nImport-Module ServerManager\nAdd-WindowsFeature –Name AD-Domain-Services –IncludeAllSubFeature –IncludeManagementTools\nImport-Module ADDSDeployment\nInstall-ADDSForest -CreateDnsDelegation:$false -DatabasePath \"C:\\Windows\\NTDS\" -DomainMode \"Win2012\" -DomainName \"" + DOMAINNAME + "\" -DomainNetbiosName "+NAME_USER+" -ForestMode \"Win2012\" -InstallDns:$true -LogPath \"C:\\Windows\\NTDS\" -NoRebootOnCompletion:$false -SysvolPath \"C:\\Windows\\SYSVOL\" -Force:$true -SafeModeAdministratorPassword (convertto-securestring "+PASSWORD+" -asplaintext -force)",
                /*КУскок 2*/ "Add-DnsServerPrimaryZone -DynamicUpdate NonsecureAndSecure -NetworkId " + "'" + NETWORK + "/" + MASK + "'" + " -ReplicationScope Domain\nAdd-DnsServerResourceRecordPtr -Name \"" + LASTBYTE + "\" -ZoneName \"" + REVERS_IP + ".in-addr.arpa\" -AgeRecord -PtrDomainName \"$env:COMPUTERNAME." + DOMAINNAME + "\"" +"\nImport-Module ServerManager\nAdd-WindowsFeature –Name DHCP –IncludeManagementTools\nAdd-DHCPServerSecurityGroup -ComputerName $env:COMPUTERNAME\nRestart-Service dhcpserver\nAdd-DhcpServerInDC -DnsName $env:COMPUTERNAME -IPAddress " + IP_SERVER +"\n$User = \"$env:USERDOMAIN\\$env:USERNAME\"\n$PWord = ConvertTo-SecureString -String " + PASSWORD + " -AsPlainText -Force\n$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $User, $PWord\nSet-DHCPServerDnsCredential -ComputerName $env:COMPUTERNAME -Credential $Credential\nAdd-DHCPServerv4Scope -Name " + NAME_POOL + " -StartRange " + LOW_RANGE + " -EndRange " + HIGE_RANGE + " -SubnetMask " + MASK255 + " -State Active\nSet-DHCPServerv4OptionValue -ComputerName $env:COMPUTERNAME -DnsServer " + IP_SERVER + " -DnsDomain " + DOMAINNAME + " -Router " + GATEWAY+"\nSet-DHCPServerv4OptionValue -ComputerName $env:COMPUTERNAME -ScopeId "+NETWORK+" -DnsServer "+IP_SERVER+" -DnsDomain "+DOMAINNAME+" -Router " + GATEWAY + "\nRestart-Computer -Force"};
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
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Hide();
            fr5.ShowDialog();
            this.Show();
        }
    }

}