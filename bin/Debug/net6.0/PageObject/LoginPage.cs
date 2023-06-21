using OpenQA.Selenium;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.PageObject
{

    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            ObjectRepository.Driver = this.driver;
            // this.driver = driver;
        }

        By usernameField = By.XPath("//input[@id='username']");
        By passwordField = By.XPath("//input[@id='password']");
        By terms = By.CssSelector("#terms");
        By submitButton = By.CssSelector("#signInBtn");
        By invalidLogin = By.XPath("//div[@class='alert alert-danger col-md-12']");
        // string uname = ConfigurationManager.AppSettings.Get("username");
        //string pass = ConfigurationManager.AppSettings.Get("password");


        public void Enterusername(string uname)
        //public void Enterusername()
        {
            GenericHelper.GetElement(usernameField).Clear();
            ObjectRepository.Driver.FindElement(usernameField).SendKeys("uname");
            //driver.FindElement(usernameField).SendKeys("uname");
            GenericHelper.GetElement(usernameField).Clear();
            TextBoxHelper.TypeInTextBox(usernameField, uname);
            // driver.FindElement(usernameField).SendKeys(uname);
        }
        public void Enterpassword(string pass)
        // public void Enterpassword()
        {
            ObjectRepository.Driver.FindElement(passwordField).SendKeys("uname");
            GenericHelper.GetElement(passwordField).Clear();
            TextBoxHelper.TypeInTextBox(passwordField, pass);
            //driver.FindElement(passwordField).SendKeys(pass);
        }
        public void ClickTermsAndConditions()
        {
            CheckBoxHelper.CheckedCheckBox(terms); ;
            // driver.FindElement(terms).Click();
        }
        public void ClickSubmitButton()
        {
            ObjectRepository.Driver.FindElement(submitButton).Click();

        }

        public IWebElement GetTextt()
        {

            return ObjectRepository.Driver.FindElement(By.XPath("//div[@class='alert alert-danger col-md-12']"));

        }





    }




}

