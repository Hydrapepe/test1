﻿using System;
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

        static readonly string[] Scopes = { DriveService.Scope.Drive };
        static readonly string ApplicationName = "PepeSoft";
        static readonly string FolderId = "12S8KdEPIuKl73B4RJT1wi90HCKdfyB2i";
        static readonly string _fileName = "test";
        static readonly string _filePath = Directory.GetCurrentDirectory() + @"\Pepe.txt";
        static readonly string _contentType= "application/xml";
        static string UTF8ToWin1251(string sourceStr)
        {
            Encoding utf8 = Encoding.UTF8;
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            byte[] utf8Bytes = utf8.GetBytes(sourceStr);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            return win1251.GetString(win1251Bytes);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = System.IO.File.Create("Pepe.txt"))
                {
                    Encoding win1251 = Encoding.GetEncoding(1251);
                    string info = UTF8ToWin1251(textBox1.Text);
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
    }
}