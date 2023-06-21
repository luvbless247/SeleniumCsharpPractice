using OpenQA.Selenium;

namespace SpecFlowPracticeTest.ComponentHelper
{

    public class ButtonHelper
    {
        private static IWebElement element;
        public static void ClickButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }

        public static bool IsButtonEnabled(By locator)
        {
            element = GenericHelper.GetElement(locator);
            return element.Enabled;
        }

        public static string GetButtonText(By locator)
        {
            element = GenericHelper.GetElement(locator);
            if (element.GetAttribute("value") == null)
                return string.Empty;

            return element.GetAttribute("value");
        }
    }
}
