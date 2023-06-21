using SpecFlowPracticeTest.Configuration;

namespace SpecFlowPracticeTest.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetLink();
        string GetURL();
        int GetPageLoadTimeout();
        int GetImplicitWaitTimeout();
        int GetExplicitWaitTimeout();
        string GetApp();
        string GetOS();

    }
}
