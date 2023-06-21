using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.PageObject
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            ObjectRepository.Driver = this.driver;
            PageFactory.InitElements(ObjectRepository.Driver, this);

        }


        //  By reg = By.XPath("//a[normalize-space()='Register']");
        // By setUp = By.CssSelector("button[value='email']");
        //  By fullname = By.CssSelector("#user_name");
        //  By email = By.CssSelector("#user_email");
        // By password = By.CssSelector("#password");
        // By signUp = By.CssSelector("input[value='Sign up']");

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Register']")]
        private IWebElement reg;

        [FindsBy(How = How.CssSelector, Using = "button[value = 'email']")]
        private IWebElement setUp;

        [FindsBy(How = How.CssSelector, Using = "#user_name")]
        private IWebElement fullname;

        [FindsBy(How = How.CssSelector, Using = "#user_email")]
        private IWebElement email;

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign up']")]
        private IWebElement signUp;


        public IWebElement ClickRegister()
        {
            return reg;
        }
        public IWebElement ClickSetUp()
        {
            return setUp;
        }

        public IWebElement EnterFullName()
        {
            return fullname;
        }

        public IWebElement EnterEmailAddress()
        {
            return email;
        }

        public IWebElement EnterPassword()
        {
            return password;
        }
        public IWebElement ClickSignUp()
        {
            return signUp;
        }
    }
}
