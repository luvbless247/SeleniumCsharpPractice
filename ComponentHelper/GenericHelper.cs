using OpenQA.Selenium;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found:" + locator.ToString());
        }
    }
}
