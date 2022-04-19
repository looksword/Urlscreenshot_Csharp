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
                    ShowError("ChromiumDir Error.");
                    ScreenShotAll.Enabled = false;
                }
            }
            catch (Exception) { }
        }

        private void ScreenShotAll_Click(object sender, EventArgs e)
        {
            try
            {
                ShowError("");
                if(InputUrl.Text == "")
                {
                    return;
                }

                ScreenShotAll.Enabled = false;
                var filename = PageToImage(InputUrl.Text, IsHeadLess, ChromiumDir);
                string pngdir = ImageDirectory + filename.Result;
                ScreenShotPng.Load(pngdir);

                ScreenShotAll.Enabled = true;
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        public async Task<string> PageToImage(string url,bool isheadless,string chronmiumdir)
        {
            Browser browser = null;
            try
            {
                browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = isheadless,
                    ExecutablePath = chronmiumdir,
                    //Timeout = 5000,
                    Args = new string[] { /*"--no-sandbox",*/ "--start-maximized", "--window-size=1920,1080" }
                });
                var page = await browser.NewPageAsync();
                await page.SetViewportAsync(new ViewPortOptions
                {
                    Width = 1920,
                    Height = 1600
                });
                var Response = await page.GoToAsync(url, new NavigationOptions { WaitUntil = new WaitUntilNavigation[] { WaitUntilNavigation.DOMContentLoaded }, Timeout = 0 });
                
                #region if need login
                //if (page.Url.Contains("login"))
                //{
                //    await page.TypeAsync("#username", "admin");
                //    await page.TypeAsync("#password", "123456");
                //    await page.ClickAsync(".btn-block");
                //    await page.WaitForTimeoutAsync(1000);
                //    await page.ReloadAsync(new NavigationOptions { WaitUntil = new WaitUntilNavigation[] { WaitUntilNavigation.Networkidle0 }, Timeout = 0 });
                //}
                //await page.WaitForTimeoutAsync(2000);
                #endregion

                string fileName = $"{Guid.NewGuid()}.png";
                await page.ScreenshotAsync($"{ImageDirectory}{fileName}", new ScreenshotOptions { FullPage = false });
                await page.CloseAsync();
                await browser.CloseAsync();

                string pngdir = ImageDirectory + fileName;
                if (File.Exists(pngdir))
                {
                    PngDirs.Enqueue(pngdir);
                }
                if (PngDirs.Count > 50)//keep fifty screenshots
                {
                    lock (PngDirs)
                    {
                        string delpngdir = PngDirs.Dequeue();
                        if (File.Exists(delpngdir))
                        {
                            File.Delete(delpngdir);
                        }
                    }
                }

                return fileName;
            }
            catch (NavigationException ex)
            {
                throw new Exception("fails to navigate ," + ex.Url + "[" + ex.Message + "]");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception from url( " + url + ") : " + ex.Message);
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
