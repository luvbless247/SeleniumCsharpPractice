using OpenQA.Selenium;
using SpecFlowPracticeTest.Settings;
using System.Collections.ObjectModel;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class BrowserHelper
    {

        public static void MaximiseBrowser()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }
        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }
        public static void GoForward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }
        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToChildWindow(int index = 0)
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            if (windows.Count < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index" + index);
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
        }
        //    //public static void SwitchParent()
        //    //{
        //    //    var windows = ObjectRepository.Driver.WindowHandles;
        //    //    string initialWindowHandle = ObjectRepository.Driver.CurrentWindowHandle;

        //    //    foreach (string window in windows)
        //    //    {
        //    //        if (window != initialWindowHandle)
        //    //        {
        //    //            ObjectRepository.Driver.Close();
        //    //            ObjectRepository.Driver.SwitchTo().Window(window);

        //    //        }
        //    //    }

        //    //    ObjectRepository.Driver.SwitchTo().Window(initialWindowHandle);
        //    //}

        public static void SwitchToParentWindow()
        {
            var windows = ObjectRepository.Driver.WindowHandles;
            for (int i = windows.Count - 1; i > 0;)
            {
                ObjectRepository.Driver.Close();
                i = i - 2;
                Thread.Sleep(1000);
                ObjectRepository.Driver.SwitchTo().Window(windows[i]);
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[0]);

        }

        //public static void SwitchToChildWindow(int index = 0)
        //{
        //    ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
        //    if (windows.Count <= index)
        //    {
        //        throw new NoSuchWindowException("Invalid Browser Window Index: " + index);
        //    }

        //    string targetWindow = windows[index];
        //    ObjectRepository.Driver.SwitchTo().Window(targetWindow);

        //    // Wait for the window to fully load
        //    WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(10));
        //    wait.Until(driver => driver.WindowHandles.Contains(targetWindow));
        //}

        //public static void SwitchToParentWindow()
        //{
        //    var windows = ObjectRepository.Driver.WindowHandles;
        //    for (int i = windows.Count - 1; i > 0; i--)
        //    {
        //        string targetWindow = windows[i];
        //        ObjectRepository.Driver.Close();

        //        // Wait for the window to close
        //        WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(10));
        //        wait.Until(driver => !driver.WindowHandles.Contains(targetWindow));
        //    }
        //    ObjectRepository.Driver.SwitchTo().Window(windows[0]);
        //}


    }
}
