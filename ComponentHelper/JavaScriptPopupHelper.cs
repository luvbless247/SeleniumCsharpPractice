using OpenQA.Selenium;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class JavaScriptPopupHelper
    {
        public static bool IsAlertPopupPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }

        }
        public static string GetAlertPopText()
        {
            if (!IsAlertPopupPresent())
                return string.Empty;
            return ObjectRepository.Driver.SwitchTo().Alert().Text;
        }

        public static void AcceptAlertPopup()
        {
            if (!IsAlertPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
        }
        public static void CancelAlertPopup()
        {
            if (!IsAlertPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
        }
        public static void SendKeysToAlert(string text)
        {
            if (!IsAlertPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
