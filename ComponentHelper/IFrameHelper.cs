using OpenQA.Selenium;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class IFrameHelper
    {
        public static void SwitchIframe(By locator)
        {
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(locator));
        }
    }
}
