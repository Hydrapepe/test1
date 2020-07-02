using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PepeForWinS
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            progressBar1.Value = 1;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string[] Mars = new string[] { "/c xcopy \"A:\\soft\\RadminViewer3\" \"C:\\Program\\RadminViewer3\" /E /I /y", @"/c C:\Windows\System32\wusa.exe A:\soft\WindowsTH-RSAT_WS2016-x64.msu /quiet /norestart", @"/c start /wait A:\soft\Skype-8.59.0.77.exe /VERYSILENT /SP- /NOCANCEL /NORESTART /SUPPRESSMSGBOXES /NOLAUNCH", @"/c A:\soft\office2007\SETUP /adminfile qwerty.msp", "/c xcopy \"A:\\soft\\KasperskyAntivirusInternetSecurity\" \"C:\\Programs\\KasperskyAntivirusInternetSecurity\" /E /I /y", @"/c A:\soft\ccsetup566.exe /S /L=1049 /D=C:\CCleaner", @"/c A:\soft\Alcohol.120.v2.1.0.30316.exe /S /RU /d=C:\Alcohol120", "/c xcopy \"A:\\soft\\KVRT\" \"C:\\Programs\\RVRT\" /E /I /y", @"/c A:\soft\putty-0.62-installer.exe /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-", @"/c A:\soft\7z.exe /S /D = 'C:\Program Files\7-Zip'", @"/c A:\soft\FileZilla_3.47.2.1_win64-setup.exe /НКРС /S /D = 'C:\Program Files\FILEZILLA'", @"/c A:\soft\PacketTracer-7.3.0-win64-setup /verysilent", "/c xcopy \"A:\\soft\\Victoria\" \"C:\\Programs\\Victoria\" /E /I /y", @"/c A:\soft\ATI.2016.v19.0.0.6571.exe /S /RU /d=C:\Acronis True Image", @"/c A:\soft\rcsetup153.exe /S /L=1049 /D=C:\Recuva", @"/c A:\soft\AdobeAcrobat\AdobeAcrobat\setup.exe -sfx_nu /sALL /msi EULA_ACCEPT=YES", @"/c msiexec.exe /i A:\soft\FirefoxSetup.msi /qn" };
            for (int number = 0; number != 17; number++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = Mars[number],
                        WindowStyle = ProcessWindowStyle.Hidden
                    }).WaitForExit();
                    worker.ReportProgress(number);
                }
            }
            for (int number = 17; number != 21; number++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(10000);
                    worker.ReportProgress(number);
                }
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Form9 fr9 = (Form9)Application.OpenForms["Form9"];
            CheckBox[] Europa = new CheckBox[] { fr9.checkBox1, fr9.checkBox2, fr9.checkBox3, fr9.checkBox4, fr9.checkBox5, fr9.checkBox6, fr9.checkBox7, fr9.checkBox8, fr9.checkBox9, fr9.checkBox10, fr9.checkBox11, fr9.checkBox12, fr9.checkBox13, fr9.checkBox14, fr9.checkBox15, fr9.checkBox16, fr9.checkBox17, fr9.checkBox19, fr9.checkBox20, fr9.checkBox21 };
            Europa[e.ProgressPercentage].Checked = true;
            Europa[e.ProgressPercentage].ForeColor = Color.Lime;
            progressBar1.Value++;
            int t = progressBar1.Value - 1;
            fr9.label2.Text = ("Установленно: " + t + "/20");
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label2.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label2.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label2.Text = "Done!";
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
                        if (!backgroundWorker1.IsBusy)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        if (!backgroundWorker2.IsBusy)
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }
                    }
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    if (Convert.ToInt32(fr9.textBox2.Text) == 1)
                    {
                        if (!backgroundWorker1.IsBusy)
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        if (!backgroundWorker2.IsBusy)
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }
                    }
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;

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

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs ew)
        {
            BackgroundWorker worker1 = sender as BackgroundWorker;

            for (int number = 0; number != 20; number++)
            {
                if (worker1.CancellationPending)
                {
                    ew.Cancel = true;
                    break;
                }
                else
                {
                    Random rnd = new Random();
                    int value = rnd.Next(1, 5);
                    value *= 1000;
                    Thread.Sleep(value);
                    worker1.ReportProgress(number);
                    if (number == 11)
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = @"/c A:\newsoft\7z.exe /S /D = 'C:\Program Files\7-Zip'",
                            WindowStyle = ProcessWindowStyle.Hidden
                        }).WaitForExit();
                    }
                    worker1.ReportProgress(number);
                }
            }
        }

        private void BackgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs ew)
        {
            Form9 fr9 = (Form9)Application.OpenForms["Form9"];
            CheckBox[] Pluto = new CheckBox[] { fr9.checkBox1, fr9.checkBox2, fr9.checkBox3, fr9.checkBox4, fr9.checkBox5, fr9.checkBox6, fr9.checkBox7, fr9.checkBox8, fr9.checkBox9, fr9.checkBox10, fr9.checkBox11, fr9.checkBox12, fr9.checkBox13, fr9.checkBox14, fr9.checkBox15, fr9.checkBox16, fr9.checkBox17, fr9.checkBox19, fr9.checkBox20, fr9.checkBox21 };
            Pluto[ew.ProgressPercentage].Visible = false;
            if (ew.ProgressPercentage == 11)
            {
                fr9.checkBox10.Visible = true;
                fr9.checkBox10.Checked = true;
                fr9.checkBox10.ForeColor = Color.Lime;
            }
            progressBar1.Value++;
            int t = progressBar1.Value - 1;
            fr9.label2.Text = "Проверка обновления: " + t + "/20";
        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs ew)
        {
            if (ew.Cancelled)
            {
                label2.Text = "Canceled!";
            }
            else if (ew.Error != null)
            {
                label2.Text = "Error: " + ew.Error.Message;
            }
            else
            {
                label2.Text = "Done!";
            }
        }
    }
}