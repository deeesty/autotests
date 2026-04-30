using OpenQA.Selenium;
using AutoTests.Models;

namespace AutoTests.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            manager.Navigation.GoToLoginPage();
            driver.FindElement(By.Id("userName")).SendKeys(account.UserName);
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("login")).Click();
        }

        public void Logout() => manager.Navigation.GoToHomePage();
    }
}