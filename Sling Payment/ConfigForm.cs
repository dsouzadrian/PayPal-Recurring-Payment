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
using System.IO;
using Microsoft.Win32.TaskScheduler;

namespace Paypal_Recurring_Payment
{
    public partial class configForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern Int32 SetForegroundWindow(int hWnd);

        static IWebDriver driver;
        static Process chromeWin;
        static List<paymentSource> paySourceList = new List<paymentSource>();
        static string logFilePath = "C:\\Users\\" + Environment.UserName + "\\Documents\\paypalRecurringLogFile.txt";
        static int appMode;


        public configForm(int mode, string pathToDriver = "", string hideChromeWind = "true")
        {
            /*
             * The APPMODE will determine the mode in which the app is run.
             * APPMODE = 0 --> configuration mode, a GUI is presented to the user to configure payment options etc for the recurring payment.
             * APPMODE = 1 --> this is the mode the CRON job should be set up with. During this mode, no GUI is 
             * presented to the user and the job runs in the background to log a payment
             * 
             * 
             */

            appMode = mode;
            File.WriteAllText(logFilePath, contents: Environment.NewLine + "APPMODE = " + appMode + Environment.NewLine + "Initializing Components: Running Paypal Recurring payment on " + DateTime.Today.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString());
            if (mode == 0)
            {
                InitializeComponent();



                if (!InitializeChromeDriver(""))
                {

                    File.AppendAllText(logFilePath, Environment.NewLine + "Something went wrong when initializing the chromeDriver. Please verify that the chromeDriver executable exists in your directory.");
                    //MessageBox.Show("Something went wrong when initializing Chrome Driver.");
                    Application.Exit();
                }
                CheckPreviousPreferences();
                if (hideChromeWind.Equals("true"))
                {
                    hideChromeWin();
                }
            }
            else
            {
                if (!InitializeChromeDriver(pathToDriver))
                {

                    File.AppendAllText(logFilePath, Environment.NewLine + "\n Something went wrong when initializing the chromeDriver. Please verify that the chromeDriver executable exists in your directory.");
                    //MessageBox.Show("Something went wrong when initializing Chrome Driver.");
                    Application.Exit();
                }
                if (hideChromeWind.Equals("true"))
                {
                    hideChromeWin();
                }
                getPaymentSources();
                sendPayment();
                //driver.Dispose();
                driver.Close();
                //Checking syncing process. .... 123
                Application.Exit();

            }


        }

        public void CheckPreviousPreferences()
        {
            paypalUsername.Text = Properties.Settings.Default.username;
            paypalPwd.Text = Properties.Settings.Default.password;
            sendUser.Text = Properties.Settings.Default.payToUsername;
            amountTxtBox.Text = Properties.Settings.Default.Amount.ToString();

            savePref.Enabled = false;
            savePref.BackColor = Color.Gray;
        }


        public bool InitializeChromeDriver(string pathToDriver)
        {
            File.AppendAllText(logFilePath, Environment.NewLine + "Initialize ChromeDriver - Begin()");

            try
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

                if (pathToDriver == "")
                {
                    var chDrService = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
                    chDrService.HideCommandPromptWindow = true;
                    driver = new ChromeDriver(chDrService, options);
                }
                else
                {
                    var chDrService = ChromeDriverService.CreateDefaultService(pathToDriver);
                    chDrService.HideCommandPromptWindow = true;
                    driver = new ChromeDriver(chDrService, options);
                }

            }
            catch (Exception ex)
            {
                File.AppendAllText(logFilePath, Environment.NewLine + "Initialize ChromeDriver - There was an exception " + ex.ToString());
                return false;
            }
            File.AppendAllText(logFilePath, Environment.NewLine + "Initialize ChromeDriver - End()");
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
                File.AppendAllText(logFilePath, "\nUnable to locate chrome window");
            }
        }

        public bool getPaymentSources()
        {
            File.AppendAllText(logFilePath, Environment.NewLine + "GetPaymentSources() - Begin");
            if (!loginToPayPal())
            {

                File.AppendAllText(logFilePath, Environment.NewLine + "GetPaymentSources() - Unable to login");
                return false;

            }

            try
            {
                //Getting the list of payment options.
                Thread.Sleep(9000);
                IWebElement iFrameElement = driver.FindElement(By.Id("p2p-iframe"), 60);

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

                    if (appMode == 0)
                    {
                        RadioButton rdBt = new RadioButton();
                        rdBt.Text = sourceObj.PaymentSourceName.Text;
                        //invisibleLabel.Visible = true;
                        rdBt.Location = new Point(GetPaySourceBT.Location.X, (GetPaySourceBT.Location.Y + 30) + ((i + 1) * 30));
                        rdBt.Visible = true;
                        rdBt.AutoSize = true;
                        rdBt.AutoEllipsis = false;
                        paymntSourceGrpBox.Controls.Add(rdBt);
                        sourceObj.PaySourceRdBt = rdBt;
                    }


                    paySourceList.Add(sourceObj);
                }

                driver.SwitchTo().DefaultContent();



            }
            catch (Exception ex)
            {
                File.AppendAllText(logFilePath, Environment.NewLine + "GetPaymentSources() - There was an issue capturing the payment sources" + ex.ToString());
                return false;
            }
            File.AppendAllText(logFilePath, Environment.NewLine + "GetPaymentSources() - Retrieved Payment Sources successfully - End");
            return true;



        }

        private bool loginToPayPal()
        {
            try
            {
                if (String.IsNullOrEmpty(Properties.Settings.Default.payToUsername))
                {
                    driver.Navigate().GoToUrl("http://paypal.me/" + sendUser.Text);
                }
                else
                {
                    driver.Navigate().GoToUrl("http://paypal.me/" + Properties.Settings.Default.payToUsername);
                }

                if (Properties.Settings.Default.Amount > 0)
                {
                    driver.FindElement(By.ClassName("amount-number"), 2).SendKeys(Properties.Settings.Default.Amount.ToString());
                }
                else
                {
                    driver.FindElement(By.ClassName("amount-number"), 2).SendKeys("0.01");
                }


                driver.FindElement(By.ClassName("profile-amount-submit-button"), 2).Submit();

                IWebElement emailElement = driver.FindElement(By.Id("email"), 3);
                if (String.IsNullOrEmpty(Properties.Settings.Default.username))
                {
                    if (!String.IsNullOrEmpty(paypalUsername.Text))
                    {
                        emailElement.Clear();
                        emailElement.SendKeys(paypalUsername.Text);
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    emailElement.Clear();
                    emailElement.SendKeys(Properties.Settings.Default.username);
                }
                IWebElement nextBt = driver.FindElement(By.Id("btnNext"), 1);
                if (nextBt != null)
                {
                    nextBt.Submit();
                }

                if (String.IsNullOrEmpty(Properties.Settings.Default.password))
                {
                    if (!String.IsNullOrEmpty(paypalPwd.Text))
                    {
                        Thread.Sleep(3000);
                        driver.FindElement(By.Id("password"), 3).SendKeys(paypalPwd.Text);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Thread.Sleep(3000);
                    driver.FindElementUntilExists(By.Id("password"), 10).SendKeys(Properties.Settings.Default.password);
                }

                driver.FindElement(By.Id("btnLogin")).Submit();


            }
            catch (Exception ex)
            {
                File.AppendAllText(logFilePath, "\n There was an error logging in \n " + ex.ToString());
                return false;
            }
            File.AppendAllText(logFilePath, "\nLogged in Successfully.");
            return true;
        }

        private void sendPayment()
        {
            File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - Begin");
            IWebElement iFrameElement = driver.FindElement(By.Id("p2p-iframe"), 60);

            driver.SwitchTo().Frame(iFrameElement);
            File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - Preferences Default payment --> " + Properties.Settings.Default.paymentSourceIndex +
                " : " + Properties.Settings.Default.paymentSourceName);

            bool paymentMatched = false;

            for (int i = 0; i < paySourceList.Count; i++)
            {
                File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - Retrieved Payment Source Name --> " + i + " : " + paySourceList[i].PaymentSourceName.Text);
                if (i == Properties.Settings.Default.paymentSourceIndex && paySourceList[i].PaymentSourceName.Text.Equals(Properties.Settings.Default.paymentSourceName))
                {
                    try
                    {
                        paymentMatched = true;
                        File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - Payment Source matched - Sending Payment");
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                        paySourceList[i].RadioBt.Click();
                        IWebElement nextBt = driver.FindElement(By.ClassName("nextButton_zl4iei"));
                        js.ExecuteScript("window.scrollTo(0," + (nextBt.Location.Y - 200) + ")");
                        nextBt.Click();

                        IWebElement submitBt = driver.FindElement(By.ClassName("submitButton_1sxl9gz"), 5);
                        js.ExecuteScript("window.scrollTo(0," + (submitBt.Location.Y - 200) + ")");
                        submitBt.Click();
                        File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - Payment Source matched - Payment Successful");


                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - Payment Source Matched but payment failed " + ex.ToString());
                    }
                }

            }

            if (!paymentMatched)
            {
                File.AppendAllText(logFilePath, Environment.NewLine + "SendPayment() - no payment sources matched - sending payment failed.");
            }

        }

        private void savePref_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = paypalUsername.Text;
            Properties.Settings.Default.password = paypalPwd.Text;
            Properties.Settings.Default.payToUsername = sendUser.Text;
            Properties.Settings.Default.Amount = Convert.ToDouble(amountTxtBox.Text);

            for (int i = 0; i < paySourceList.Count; i++)
            {
                if (paySourceList[i].PaySourceRdBt.Checked)
                {
                    IWebElement iFrameElement = driver.FindElement(By.Id("p2p-iframe"), 60);

                    driver.SwitchTo().Frame(iFrameElement);

                    Properties.Settings.Default.paymentSourceIndex = i;
                    Properties.Settings.Default.paymentSourceName = paySourceList[i].PaymentSourceName.Text;
                }

            }

            Properties.Settings.Default.Save();
            MessageBox.Show("Preferences Saved!!");

        }

        private void GetPaySourceBT_Click(object sender, EventArgs e)
        {
            GetPaySourceBT.Enabled = false;
            GetPaySourceBT.BackColor = Color.Gray;
            loadText.Visible = true;
            Application.DoEvents();

            if (!getPaymentSources())
            {
                loadText.Text = "There was an error retreving payment sources";
            }
            else
            {
                loadText.Visible = false;
            }
            GetPaySourceBT.Enabled = true;
            GetPaySourceBT.BackColor = Color.DodgerBlue;
            savePref.BackColor = Color.DodgerBlue;
            savePref.Enabled = true;

        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            driver.Close();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            driver.Close();

        }

        private void jobSchedBt_Click(object sender, EventArgs e)
        {
            
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Does something";

                // Create a trigger that will fire the task at this time every other day
                td.Triggers.Add(new MonthlyTrigger(Int32.Parse(dayMonthTxtBox.Text), MonthsOfTheYear.AllMonths));

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(Environment.CurrentDirectory + "\\Paypal_Recurring_Payment.exe", "1 '"+Environment.CurrentDirectory+"\\chromedriver.exe' 'false'"));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(taskNameTxtBox.Text, td);
            }
        }

       
    }

}
