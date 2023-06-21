using OpenQA.Selenium;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class LinkHelper
    {
        private static IWebElement element;
        public static void ClickLink(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }
    }
}
