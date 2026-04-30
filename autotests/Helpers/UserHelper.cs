using OpenQA.Selenium;
using AutoTests.Models;

namespace AutoTests.Helpers
{
    public class UserHelper : HelperBase
    {
        public UserHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            manager.Navigation.GoToLoginPage();
            manager.Navigation.GoToRegistrationPage();
            
            driver.FindElement(By.Id("firstname")).SendKeys(account.FirstName);
            driver.FindElement(By.Id("lastname")).SendKeys(account.LastName);
            driver.FindElement(By.Id("userName")).SendKeys(account.UserName);
            driver.FindElement(By.CssSelector(".button:nth-child(1)")).Click();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("register")).Click();
        }

        public void CompleteRegistration(AccountData account)
        {
            driver.FindElement(By.Id("submit")).Click();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("register")).Click();
        }

        public AccountData GetRegisteredUserData(string expectedUserName)
        {
            return new AccountData("", "", expectedUserName, "");
        }
    }
}