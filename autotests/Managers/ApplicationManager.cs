using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using AutoTests.Helpers;

namespace AutoTests.Managers
{
    public class ApplicationManager
    {
        private static ThreadLocal<ApplicationManager> appInstance 
            = new ThreadLocal<ApplicationManager>();

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private readonly string baseURL;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private UserHelper user;
        private BookHelper book;

        private ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (!appInstance.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoToHomePage();
                appInstance.Value = newInstance;
            }
            return appInstance.Value;
        }

        ~ApplicationManager()
        {
            try { driver?.Quit(); }
            catch (Exception) { /* ignore */ }
        }

        public IWebDriver Driver => driver;
        public string BaseURL => baseURL;
        public NavigationHelper Navigation => navigation;
        public LoginHelper Auth => auth;
        public UserHelper User => user;
        public BookHelper Book => book;

        public string GetAlertText() => book.GetAlertText();
        
        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void ResetState()
        {
            Navigation.GoToHomePage();
        }
    }
}