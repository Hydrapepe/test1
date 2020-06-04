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
            
        public string ii = "$RootDomain = \"DC=savilltech,DC=net\"\n$OUs = Get-ADOrganizationalUnit -filter* -searchbase \"$RootDomain\" -SearchScope OneLevel\nforeach($OU in $OUs)\n{\n$GroupOU = \"OU=Groups,$($OU.DistinguishedName)\"\n$UserOU = \"OU=Users,$($OU.DistinguishedName)\"\n$NewGroupName = \"$($OU.Name)Users\"\n$NewGroup = New-ADGroup -Name $NewGroupName -GroupCategory Security -GroupScope Global -DisplayName $NewGroupName -Path $GroupOU -Description \"$($OU.Name) Users Group\" -PassThru\n$Users = Get-ADUser -Filter* -SearchBase $UserOU\nforeach($User in $Users)\n{\n$User | Add-ADPrincipalGroupMembership -MemberOf $NewGroupName\n}\n};";
        public string test;
        public string test1;
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
            label1.Visible = true;
            textBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test = textBox2.Text;
            string[] words = test.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                try
                {
                    words[0] = "DC=" + words[0];
                    words[1] = "DC=" + words[1];
                    words[2] = "DC=" + words[2];
                    words[3] = "DC=" + words[3];
                    words[4] = "DC=" + words[4];
                    words[5] = "DC=" + words[5];
                }
                catch
                { }
                test1 = "$RootDomain = \"" + words[0] + "\"";
                test1 = test1 + "\"" + words[1] + "\"";
                test1 = test1 + "\"" + words[2] + "\"";
                test1 = test1 + "\"" + words[3] + "\"";
                test1 = test1 + "\"" + words[4] + "\"";
                test1 = test1 + "\"" + words[5] + "\"";
            }
            catch { label2.Text = test1; }
        }
    }
}


