using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTest.BaseClass;
using SpecFlowPracticeTest.ComponentHelper;

namespace SpecFlowPracticeTest.TestCases
{
    public class TestPopups
    {
        [Test]
        public void SwitchToFrameToAccept()
        {

            BrowserFactory.SelectBrowser();
            BrowserHelper.MaximiseBrowser();
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.Id("accept-choices"));
            ButtonHelper.ClickButton(By.XPath("//a[@href='tryit.asp?filename=tryjs_confirm']"));
            Thread.Sleep(1000);
            BrowserHelper.SwitchToChildWindow(1);
            Thread.Sleep(5000);
            IFrameHelper.SwitchIframe(By.Name("iframeResult"));
            Thread.Sleep(1000);
            ButtonHelper.ClickButton(By.XPath("//button[normalize-space()='Try it']"));
            Thread.Sleep(1000);
            JavaScriptPopupHelper.GetAlertPopText();
            Console.WriteLine(JavaScriptPopupHelper.GetAlertPopText());
            JavaScriptPopupHelper.AcceptAlertPopup();
            Thread.Sleep(1000);
            //TextBoxHelper.ClearTextBox(By.XPath("//div[@id='textareawrapper']"));
            //TextBoxHelper.TypeInTextBox(By.XPath("//div[@id='textareawrapper']"),
            //JavaScriptPopupHelper.GetAlertPopText());
            Thread.Sleep(1000);
            BrowserFactory.stopBrowser();

        }
        [Test]
        public void SwitchToFrameToCancel()
        {
            BrowserFactory.SelectBrowser();
            BrowserHelper.MaximiseBrowser();
            NavigationHelper.NavigateToUrl("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.Id("accept-choices"));
            ButtonHelper.ClickButton(By.XPath("//a[@href='tryit.asp?filename=tryjs_confirm']"));
            Thread.Sleep(1000);
            BrowserHelper.SwitchToChildWindow(1);
            Thread.Sleep(5000);
            IFrameHelper.SwitchIframe(By.Name("iframeResult"));
            Thread.Sleep(1000);
            ButtonHelper.ClickButton(By.XPath("//button[normalize-space()='Try it']"));
            Thread.Sleep(1000);
            JavaScriptPopupHelper.GetAlertPopText();
            Console.WriteLine(JavaScriptPopupHelper.GetAlertPopText());
            JavaScriptPopupHelper.CancelAlertPopup();
            Thread.Sleep(1000);
            BrowserFactory.stopBrowser();

        }
    }
}
