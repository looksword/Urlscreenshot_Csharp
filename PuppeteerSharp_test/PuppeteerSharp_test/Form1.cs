using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using PuppeteerSharp;

namespace PuppeteerSharp_test
{
    public partial class Form1 : Form
    {
        #region base

        private bool IsHeadLess = true;
        private string ChromiumDir = "";
        private Queue<string> PngDirs = new Queue<string>();
        public static string ImageDirectory = "";

        #endregion

        public Form1()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            string currDir = Assembly.GetExecutingAssembly().Location.ToString();
            string[] dirs = currDir.Split('\\', '/');
            currDir = "";
            for (int i = 0; i < dirs.Length - 1; i++)
            {
                if (i > 0)
                {
                    currDir += "\\";
                }
                currDir += dirs[i];
            }
            DirectoryInfo dirInfo = new DirectoryInfo(currDir + "\\Image\\");
            if (!dirInfo.Exists)
                dirInfo.Create();
            ImageDirectory = currDir + "\\Image\\";

            DirectoryInfo root = new DirectoryInfo(ImageDirectory);
            foreach (FileInfo file in root.GetFiles("*.png"))
            {
                PngDirs.Enqueue(file.FullName);
            }

            try
            {
                IsHeadLess = bool.Parse(ConfigurationManager.AppSettings["IsHeadLess"]);
                ChromiumDir = ConfigurationManager.AppSettings["ChromiumDir"];

                FileInfo Filetest = new FileInfo(ChromiumDir);
                if (!Filetest.Exists)
                {
                    ShowError("Chromium.exe Not Exist.");
                    ScreenShotAll.Enabled = false;
                }
            }
            catch (Exception) { }
        }

        private async void ScreenShotAll_Click(object sender, EventArgs e)
        {
            Browser browser = null;
            try
            {
                ShowError("");
                if(InputUrl.Text == "")
                {
                    return;
                }

                ScreenShotAll.Enabled = false;

                string url = InputUrl.Text;

                browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = IsHeadLess,
                    ExecutablePath = ChromiumDir,
                    Args = new string[] { /*"--no-sandbox",*/ "--start-maximized", "--window-size=1920,1080" }
                });
                var page = await browser.NewPageAsync();
                await page.SetViewportAsync(new ViewPortOptions
                {
                    Width = 1920,
                    Height = 1600
                });
                await page.GoToAsync(url);
                ScreenshotOptions screenshotOptions = new ScreenshotOptions();
                string fileName = $"{Guid.NewGuid()}.png";
                await page.ScreenshotAsync($"{ImageDirectory}{fileName}", screenshotOptions);
                string pngdir = ImageDirectory + fileName;

                ScreenShotPng.Load(pngdir);

                ScreenShotAll.Enabled = true;
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                if (browser != null)
                {
                    await browser.CloseAsync();
                    browser.Dispose();
                }
            }
        }

        public void ShowError(string errmsg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    textError.Text = errmsg;
                }));
            }
            else
            {
                textError.Text = errmsg;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
