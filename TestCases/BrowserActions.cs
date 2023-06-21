using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTest.BaseClass;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.TestCases
{
    public class BrowserActions
    {
        [Test]
        public static void BrowsActions()
        {
            ObjectRepository.Config = new AppConfigReader();
            BrowserFactory.SelectBrowser();
            BrowserHelper.MaximiseBrowser();
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetLink());

            LinkHelper.ClickLink(By.XPath("//div[@class='nav-outer clearfix']//a[normalize-space()='Courses']"));
            Thread.Sleep(1000);
            BrowserHelper.GoBack();
            Thread.Sleep(1000);
            // WaitHelper.TestImplicitWait();
            BrowserHelper.GoForward();
            Thread.Sleep(1000);
            // WaitHelper.TestImplicitWait();
            BrowserHelper.RefreshPage();
            Thread.Sleep(1000);
            // WaitHelper.TestImplicitWait();
            BrowserFactory.stopBrowser();
        }
    }
}

