using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using AutoTests.Helpers;

namespace AutoTests.Managers
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private readonly string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private UserHelper user;
        private BookHelper book;

        public ApplicationManager()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            
            var options = new FirefoxOptions();
            driver = new FirefoxDriver(options);
            
            driver.Manage().Window.Size = new System.Drawing.Size(1400, 812);
            baseURL = "https://demoqa.com";
            verificationErrors = new StringBuilder();

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            user = new UserHelper(this);
            book = new BookHelper(this);
        }

        public IWebDriver Driver => driver;
        public string BaseURL => baseURL;
        public NavigationHelper Navigation => navigation;
        public LoginHelper Auth => auth;
        public UserHelper User => user;
        public BookHelper Book => book;

        public void Stop()
        {
            try { driver?.Quit(); }
            catch { /* ignore */ }
            
            string verificationErrorString = verificationErrors.ToString();
            if (!"".Equals(verificationErrorString))
            {
                throw new Exception(verificationErrorString);
            }
        }
    }
}