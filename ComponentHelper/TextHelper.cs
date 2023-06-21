using OpenQA.Selenium;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class TextHelper
    {
        private static IWebElement element;
        public static string GetText(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string text = element.Text;
            return text;
        }

        public static string GetAttributeValue(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string attr = element.GetAttribute("value");
            return attr;
        }
    }
}
