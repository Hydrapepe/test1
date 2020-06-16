using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using System.Globalization;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v3.Data;
using System.IO;

namespace PepeForWinS
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string Hydra, NAME_USER,IP_ADDRESS,DOMAIN_NAME_FULL, SERVER_DOT_SPLIT;
        private static readonly string[] Scopes = { DriveService.Scope.Drive };
        private static readonly string ApplicationName = "PepeSoft";
        private static readonly string FolderId = "12S8KdEPIuKl73B4RJT1wi90HCKdfyB2i";
        private static readonly string _fileName = "test";
        private static readonly string _filePath = Directory.GetCurrentDirectory() + @"\Pepe.sh";
        private static readonly string _contentType = "application/x-sh";

        private static string UTF8ToWin1251(string sourceStr)
        {
            Encoding utf8 = Encoding.UTF8;
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            byte[] utf8Bytes = utf8.GetBytes(sourceStr);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251.GetString(win1251Bytes);
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Contains("."))
            {
                try
                {
                    using (FileStream fs = System.IO.File.Create("Pepe.sh"))
                    {
                        Pepegoto();
                        Encoding win1251 = Encoding.GetEncoding(1251);
                        string info = UTF8ToWin1251(Hydra);
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
                UserCredential credential = GetUserCredential();
                DriveService service = GetDriveServise(credential);
                UploadFileToDrive(service, _fileName, _filePath, _contentType);
            }
            else
            {
                label1.Visible = true;
                label1.Text = "Вы алексей!";
            }
        }

        static private DriveService GetDriveServise(UserCredential credential)
        {
            return new DriveService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });
        }

        static private UserCredential GetUserCredential()
        {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCredentials", "drive-credentials.json");

                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "User",
                    CancellationToken.None,
                    new FileDataStore(creadPath, true)).Result;
            }
        }

        private static string UploadFileToDrive(DriveService service,string fileName, string filePath, string contentType)
        {
            var fileMatadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = fileName,
                Parents = new List<string> { FolderId }
            };
            FilesResource.CreateMediaUpload request;
            using(var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMatadata, stream, contentType);
                request.Upload();
            }
            var file = request.ResponseBody;
            return file.Id;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Pepegoto()
        {
            DOMAIN_NAME_FULL = textBox4.Text;
            IP_ADDRESS = textBox2.Text;
            NAME_USER = textBox5.Text;
            string[] words = DOMAIN_NAME_FULL.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string WORKGROUP = words[0].ToUpper(new CultureInfo("en-US", false));
            DOMAIN_NAME_FULL = DOMAIN_NAME_FULL.ToUpper(new CultureInfo("en-US", false));
            Hydra = "#!/bin/bash\nadusername='" + NAME_USER + "'\nip='"+IP_ADDRESS+ "'\ndomain='"+ words[0] + "'\nworkgroup='"+ WORKGROUP + "'\nrealm='"+ DOMAIN_NAME_FULL + "'\napt update\napt install net-tools -y\napt install krb5-user samba winbind -y\nrm -rf /etc/resolv.conf\necho -e \"domain $domain\\nsearch $domain\\nnameserver $ip\" > /etc/resolv.conf\nsed - i 's/WORKGROUP/'$workgroup'/' / etc / samba / smb.conf\nsed -i '/Networking/a realm = '$realm'' /etc/samba/smb.conf\nsed -i 's/standalone server/member server/' /etc/samba/smb.conf\necho '**************************************'\necho 'Vvedite parol ot uchetki Active Directory'\necho '**************************************'\nnet ads join -U $adusername -D $realm\necho ''\necho '**************************************'\necho 'Informaciya o Domene'\necho '**************************************'\nnet ads info";
        }
    }
}