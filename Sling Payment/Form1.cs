using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace Sling_Payment
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern Int32 SetForegroundWindow(int hWnd);

        static IWebDriver driver;
        static Process chromeWin;
        static List<paymentSource> paySourceList = new List<paymentSource>();

        public Form1()
        {
            InitializeComponent();

            if (!InitializeChromeDriver())
            {
                MessageBox.Show("Something went wrong when initializing Chrome Driver.");
                Application.Exit();
            }

            hideChromeWin();
            
        }


        public bool InitializeChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", "C:\\Temp");
            options.AddUserProfilePreference("intl.accept_languages", "nl");
            options.AddUserProfilePreference("download.prompt_for_download", "false");
            options.AddUserProfilePreference("safebrowsing.enabled", "true");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            //options.AddArgument("--no-startup-window");
            options.AddArguments("test-type");
            options.AddArguments("--disable-extensions");

            var chDrService = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
            chDrService.HideCommandPromptWindow = true;
            try
            {
                driver = new ChromeDriver(chDrService, options);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void hideChromeWin()
        {
            Stopwatch timeElapsed = new Stopwatch();
            timeElapsed.Start();
            while (timeElapsed.Elapsed < TimeSpan.FromMinutes(1))
            {
                Process[] p = Process.GetProcessesByName("chrome");
                foreach (Process item in p)
                {
                    if (item.MainWindowTitle.Equals("data:, - Google Chrome"))
                    {
                        timeElapsed.Stop();
                        chromeWin = item;
                        ShowWindowAsync(item.MainWindowHandle, 0);
                        break;
                    }

                }
                if (!timeElapsed.IsRunning)
                {
                    break;
                }
            }

            if (timeElapsed.Elapsed > TimeSpan.FromMinutes(1))
            {
                timeElapsed.Stop();
                Console.WriteLine("Unable to locate Chrome Window");
            }
        }

        public void navigatetoPayPal(String pwd)
        {
            try
            {
                driver.Navigate().GoToUrl("http://paypal.me/dsouzaryanv");

                driver.FindElement(By.ClassName("amount-number"), 2).SendKeys("0.01");
                driver.FindElement(By.ClassName("profile-amount-submit-button"), 2).Submit();

                driver.FindElement(By.Id("email"), 3).SendKeys("adubhai13@gmail.com");
                IWebElement nextBt = driver.FindElement(By.Id("btnNext"), 1);
                if(nextBt != null)
                {
                    nextBt.Submit();
                }
                driver.FindElement(By.Id("password"), 3).SendKeys(pwd);

                driver.FindElement(By.Id("btnLogin")).Submit();

              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to log you in, please verify your password");
            }

            try
            {
                //Getting the list of payment options.



                //int frameCount = driver.FindElements(By.TagName("iframe")).Count;

                Thread.Sleep(9000);
                IWebElement iFrameElement =  driver.FindElement(By.Id("p2p-iframe"),60);

                driver.SwitchTo().Frame(iFrameElement);

                IWebElement containerEle = driver.FindElementUntilExists(By.Id("react-transfer-container"), 60); //.FindElement(By.TagName("form"),10).FindElement(By.TagName("ul"),10);
                IWebElement formEle = containerEle.FindElement(By.TagName("form"));
                //IWebElement ulList = formEle.FindElement(By.TagName("ul"));

                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> paymentSourceRows = formEle.FindElements(By.TagName("li"));

                


                for (int i = 0; i < paymentSourceRows.Count; i++)
                {
                    paymentSource sourceObj = new paymentSource();

                    sourceObj.RadioBt = paymentSourceRows[i].FindElement(By.TagName("input"));
                    sourceObj.PaymentSourceName = paymentSourceRows[i].FindElement(By.TagName("p"));

                    RadioButton rdBt = new RadioButton();
                    rdBt.Text = sourceObj.PaymentSourceName.Text;
                    //invisibleLabel.Visible = true;
                    rdBt.Location = new Point(button1.Location.X, button1.Location.Y + ((i+1)*30));
                    rdBt.Visible = true;
                    rdBt.AutoSize = true;
                    rdBt.AutoEllipsis = false;
                    paymntSourceGrpBox.Controls.Add(rdBt);

                    sourceObj.PaySourceRdBt = rdBt;

                    paySourceList.Add(sourceObj);
                }


                


                driver.SwitchTo().DefaultContent();


                
            }
            catch(Exception ex)
            {

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigatetoPayPal(paypalPwd.Text);
            //driver.Close();
        }

        private void sendPayment()
        {
            IWebElement iFrameElement = driver.FindElement(By.Id("p2p-iframe"), 60);

            driver.SwitchTo().Frame(iFrameElement);

            for(int i=0; i<paySourceList.Count;i++)
            {
                if(paySourceList[i].PaySourceRdBt.Checked)
                {
                    paySourceList[i].RadioBt.Click();
                }
            }

            driver.FindElement(By.ClassName("nextButton_zl4iei")).Click();
            driver.FindElement(By.ClassName("submitButton_1sxl9gz"),5).Click();

            driver.SwitchTo().DefaultContent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
