using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class ComboBoxHelper
    {
        private static SelectElement select;
        public static void SelectElementByIndex(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);
        }

        public static void SelectElementByText(By locator, string visibletext)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByText(visibletext);
        }

        public static void SelectElementByValue(By locator, string valueText)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByValue(valueText);
        }
        //public static void SelectElementTry(IWebElement element, string visibletext)
        //{
        //    select = new SelectElement(element);
        //    select.SelectByValue(visibletext);
        //}

        public static IList<string> GetAllItem(By locator)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            return select.Options.Select((x) => x.Text).ToList();

        }
    }
}
