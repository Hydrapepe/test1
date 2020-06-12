using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace PepeForWinS
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public static void Holy_Terra(CheckBox[] Europa, string[] Mars, int time)
        {
            Form9 fr9 = (Form9)Application.OpenForms["Form9"];
            int q = time;
            for (int number = 0; number != 17; number++, time--)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = Mars[number],
                    WindowStyle = ProcessWindowStyle.Hidden
                }).WaitForExit();
                Europa[number].Checked = true;
                Europa[number].ForeColor = Color.Lime;
                fr9.label2.Text = "Установленно: "+number + "/" + q;
                fr9.label1.Text = "Осталось ~ " + time + " минуты";
            }
        }
    private void Button3_Click(object sender, EventArgs e)
        {
            Form9 fr9 = (Form9)Application.OpenForms["Form9"];
            switch (Convert.ToInt32(fr9.textBox1.Text))
            {
                case 1:
                    if (Convert.ToInt32(fr9.textBox2.Text) == 1) 
                    { 
                        int q = 21;
                        fr9.checkBox18.Visible = false; fr9.checkBox22.Visible = false;
                        CheckBox[] Europa = new CheckBox[] { fr9.checkBox1, fr9.checkBox2, fr9.checkBox3, fr9.checkBox4, fr9.checkBox5, fr9.checkBox6, fr9.checkBox7, fr9.checkBox8, fr9.checkBox9, fr9.checkBox10, fr9.checkBox11, fr9.checkBox12, fr9.checkBox13, fr9.checkBox14, fr9.checkBox15, fr9.checkBox16, fr9.checkBox17 };
                        string[] Mars = new string[] { $"/c xcopy \"A:\\soft\\RadminViewer3\" \"C:\\Program\\RadminViewer3\" /E /I /y", @"/c C:\Windows\System32\wusa.exe A:\soft\WindowsTH-RSAT_WS2016-x64.msu /quiet /norestart", @"/c start /wait A:\soft\Skype-8.59.0.77.exe /VERYSILENT /SP- /NOCANCEL /NORESTART /SUPPRESSMSGBOXES /NOLAUNCH", @"/c A:\soft\office2007\SETUP /adminfile qwerty.msp", $"/c xcopy \"A:\\soft\\KasperskyAntivirusInternetSecurity\" \"C:\\Programs\\KasperskyAntivirusInternetSecurity\" /E /I /y", @"/c A:\soft\ccsetup566.exe /S /L=1049 /D=C:\CCleaner", @"/c A:\soft\Alcohol.120.v2.1.0.30316.exe /S /RU /d=C:\Alcohol120", $"/c xcopy \"A:\\soft\\KVRT\" \"C:\\Programs\\RVRT\" /E /I /y", @"/c A:\soft\putty-0.62-installer.exe /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-", @"/c A:\soft\7z.exe /S /D = 'C:\Program Files\7-Zip'", @"/c A:\soft\FileZilla_3.47.2.1_win64-setup.exe /НКРС /S /D = 'C:\Program Files\FILEZILLA'", @"/c A:\soft\PacketTracer-7.3.0-win64-setup /verysilent", $"/c xcopy \"A:\\soft\\Victoria\" \"C:\\Programs\\Victoria\" /E /I /y", @"/c A:\soft\ATI.2016.v19.0.0.6571.exe /S /RU /d=C:\Acronis True Image", @"/c A:\soft\rcsetup153.exe /S /L=1049 /D=C:\Recuva", @"/c A:\soft\AdobeAcrobat\AdobeAcrobat\setup.exe -sfx_nu /sALL /msi EULA_ACCEPT=YES", @"/c msiexec.exe /i A:\soft\FirefoxSetup.msi /qn" };
                        Holy_Terra(Europa, Mars, q);
                        Thread.Sleep(20000);
                        fr9.checkBox19.Checked = true;
                        fr9.checkBox19.ForeColor = Color.Lime;
                        fr9.label2.Text = "Установленно: 19/"+q;
                        fr9.label1.Text = "Осталось ~ 2 минуты";
                        Thread.Sleep(10000);
                        fr9.checkBox20.Checked = true;
                        fr9.checkBox20.ForeColor = Color.Lime;
                        fr9.label2.Text = "Установленно: 20/" + q;
                        Thread.Sleep(10000);
                        fr9.checkBox21.Checked = true;
                        fr9.checkBox21.ForeColor = Color.Lime;
                        fr9.label2.Text = "Установленно: 21/" + q;
                        fr9.label1.Text = "Осталось 0 минуты";
                    }
                    else 
                    {
                        fr9.checkBox18.Visible = false; fr9.checkBox22.Visible = false;
                        CheckBox[] Europa = new CheckBox[] { fr9.checkBox1, fr9.checkBox2, fr9.checkBox3, fr9.checkBox4, fr9.checkBox5, fr9.checkBox6, fr9.checkBox7, fr9.checkBox8, fr9.checkBox9, fr9.checkBox10, fr9.checkBox11, fr9.checkBox12, fr9.checkBox13, fr9.checkBox14, fr9.checkBox15, fr9.checkBox16, fr9.checkBox17 };
                        fr9.checkBox18.Visible = false; fr9.checkBox22.Visible = false;
                        for (int number = 0; number != 22; number++)
                        {
                            Random rnd = new Random();
                            int value = rnd.Next(1, 5);
                            value *= 1000;
                            Thread.Sleep(value);
                            Europa[number].Visible = false;
                            fr9.label2.Text = "Установленно: " + number + "/21";
                            if (number == 11)
                            {
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = "cmd",
                                    Arguments = @"/c A:\newsoft\7z.exe /S /D = 'C:\Program Files\7-Zip'",
                                    WindowStyle = ProcessWindowStyle.Hidden
                                }).WaitForExit();
                                fr9.checkBox10.Checked = true;
                                fr9.checkBox10.ForeColor = Color.Lime;
                            }
                        }
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                default:
                        break;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form9 fr9 = (Form9)Application.OpenForms["Form9"];
            switch (Convert.ToInt32(textBox1.Text))
            {
                case 1:
                        fr9.checkBox18.Visible = false; fr9.checkBox22.Visible = false;
                        break;

                case 2:
                        fr9.checkBox2.Visible = false; fr9.checkBox7.Visible = false; fr9.checkBox8.Visible = false; fr9.checkBox9.Visible = false; fr9.checkBox12.Visible = false; fr9.checkBox13.Visible = false; fr9.checkBox14.Visible = false; fr9.checkBox15.Visible = false; fr9.checkBox18.Visible = false; fr9.checkBox19.Visible = false;
                        break;
                case 3:
                        fr9.checkBox1.Visible = false; fr9.checkBox2.Visible = false; fr9.checkBox7.Visible = false; fr9.checkBox8.Visible = false; fr9.checkBox9.Visible = false; fr9.checkBox11.Visible = false; fr9.checkBox12.Visible = false; fr9.checkBox13.Visible = false; fr9.checkBox14.Visible = false; fr9.checkBox15.Visible = false; fr9.checkBox18.Visible = false; fr9.checkBox21.Visible = false; fr9.checkBox22.Visible = false;
                        break;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                default:
                        break;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
