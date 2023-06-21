using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class SearchBoxHelper
    {
        private static IWebElement element;
        public static IWebElement SearchBox(By locator, string searchItem)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(searchItem);
            Actions action = new Actions(ObjectRepository.Driver);
            action.SendKeys(Keys.Enter).Perform();

            return element;
        }

    }
}
