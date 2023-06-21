using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.BaseClass
{
    /* public class ExtentReport
     {
         private static ExtentReports _extentReports;
         private static ExtentTest _feature;
         private static ExtentTest _scenario;
         private static IWebDriver _driver;
         private static string _testResultPath;

         public static void ExtentReportInit()
         {
             string dir = AppDomain.CurrentDomain.BaseDirectory;
             _testResultPath = Path.Combine(dir.Replace("bin\\Debug\\net6.0", "TestResults"));

             var htmlReporter = new ExtentHtmlReporter(_testResultPath);
             htmlReporter.Config.ReportName = "Automation Status Report";
             htmlReporter.Config.DocumentTitle = "Automation Status Report";
             htmlReporter.Config.Theme = Theme.Dark;
             htmlReporter.Start();

             _extentReports = new ExtentReports();
             _extentReports.AttachReporter(htmlReporter);
             _extentReports.AddSystemInfo("Application", "ecommerce");
             _extentReports.AddSystemInfo("Browser", "chrome");
             _extentReports.AddSystemInfo("OS", "Windows");
         }

         public static void ExtentReportTearDown()
         {
             _extentReports.Flush();
         }

         public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
         {
             string timestamp = DateTime.Now.ToString("MMddHHmmss");
             ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
             Screenshot screenshot = takesScreenshot.GetScreenshot();
             string screenshotLocation = Path.Combine(_testResultPath, $"{scenarioContext.ScenarioInfo.Title}_{timestamp}.Png");
             screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
             return screenshotLocation;
         }

         public static void StartBrowser()
         {
             _driver = BrowserFactory.CreateWebDriver();
             string url = ConfigurationManager.AppSettings.Get("URL");
             _driver.Manage().Window.Maximize();
             _driver.Url = url;
         }


         public static void CloseBrowser()
         {
             _driver.Quit();
         }

         public static IWebDriver GetDriver()
         {
             return _driver;
         }

         public static ExtentTest GetFeature()
         {
             return _feature;
         }

         public static ExtentTest GetScenario()
         {
             return _scenario;
         }
     }
 }*/
    public class ExtentReport
    {

        // private static readonly object lockObject = new object();
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        //public static IWebDriver driver;
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
        //stResultPath = Path.Combine(dir.Replace("bin\\Debug\\net6.0", ""), "TestResults");
        // public static string reportFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestResults");
        //public static string testResultPath = Path.Combine(reportFilePath, "TestReport.html");


        public static void ExtentReportInit()
        {
            ObjectRepository.Config = new AppConfigReader();

            string app = ObjectRepository.Config.GetApp();

            string OperatingSystem = ObjectRepository.Config.GetOS();

            string browser = ObjectRepository.Config.GetBrowser().ToString();


            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();


            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", app);
            _extentReports.AddSystemInfo("Browser", browser);
            _extentReports.AddSystemInfo("OS", OperatingSystem);
        }

        //public static void SendReportByEmail()
        //{
        //    // After generating the report, send it via email
        //    string senderEmail = "luvblessgb@gmail.com";
        //    string senderPassword = "@aUSTINE247";
        //    string recipientEmail = "godbless.enaigbe@gmail.com";
        //    string smtpHost = "smtp.gmail.com";
        //    int smtpPort = 587;

        //    MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail);
        //    mailMessage.Subject = "Test Execution Report";
        //    mailMessage.Body = "Please find the attached test execution report.";
        //    mailMessage.Attachments.Add(new Attachment(testResultPath));

        //    SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
        //    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        //    smtpClient.EnableSsl = true;

        //    try
        //    {
        //        smtpClient.Send(mailMessage);
        //        Console.WriteLine("Report sent successfully.");
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Failed to send report: " + ex.Message);
        //    }

        //}



        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }


        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ObjectRepository.Driver = driver;
            string timestamp = DateTime.Now.ToString("MMddHHmmss");
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ObjectRepository.Driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLacation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + "_" + timestamp + ".Png");
            screenshot.SaveAsFile(screenshotLacation, ScreenshotImageFormat.Png);
            return screenshotLacation;
        }
        // public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public void startBrowser()
        {
            ObjectRepository.Config = new AppConfigReader();
            ObjectRepository.Driver = BrowserFactory.SelectBrowser();
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetURL());
            // NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetLink());
            // ObjectRepository.Driver.Manage().Window.Maximize();
            //Enter url from here when framework is ready
            //string url = ConfigurationManager.AppSettings.Get("URL");
            //string url = ObjectRepository.Config.GetURL();
            //if (string.IsNullOrEmpty(url))
            //{
            //    throw new ArgumentException("URL is not specified in the configuration file.");
            //}
            //ObjectRepository.Driver.Navigate().GoToUrl(url);



        }
        public void closeBrowser()
        {
            ObjectRepository.Config = new AppConfigReader();
            BrowserFactory.stopBrowser();
            //    if (ObjectRepository.Driver != null)
            //    {
            //        ObjectRepository.Driver.Close();
            //    }
        }


    }
}


