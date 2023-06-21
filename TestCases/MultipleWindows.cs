using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTest.BaseClass;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.TestCases
{
    public class MultipleWindows
    {
        [Test]
        public void MultiWindleHandle()
        {
            BrowserFactory.SelectBrowser();
            BrowserHelper.MaximiseBrowser();
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            Thread.Sleep(1000);
            LinkHelper.ClickLink(By.Id("accept-choices"));
            Thread.Sleep(1000);
            ButtonHelper.ClickButton(By.XPath("//a[@href='tryit.asp?filename=tryjs_confirm']"));
            BrowserHelper.SwitchToChildWindow(1);
            LinkHelper.ClickLink(By.XPath("//a[@id='getwebsitebtn']"));
            //ObjectRepository.Driver.Close();
            //BrowserHelper.SwitchToWindow(0);
            BrowserHelper.SwitchToParentWindow();
            Console.WriteLine(WindowHelper.GetTile());
            Assert.AreEqual("JavaScript Popup Boxes", WindowHelper.GetTile());
            ObjectRepository.Driver.Quit();
        }
    }
}
