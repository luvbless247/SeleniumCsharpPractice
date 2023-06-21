using OpenQA.Selenium;
using SpecFlowPracticeTest.Interfaces;

namespace SpecFlowPracticeTest.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
    }
}
