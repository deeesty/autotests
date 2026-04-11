using System;
using System.Collections.Generic;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace AutoTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected IJavaScriptExecutor js;
        protected IDictionary<string, object> vars;
        protected readonly string baseURL = "https://demoqa.com";
        protected readonly int windowWidth = 1400;
        protected readonly int windowHeight = 812;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            
            driver = new FirefoxDriver(options);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        public void TearDown()
        {
            try { driver?.Quit(); }
            catch { /* ignore cleanup errors */ }
        }

        public void NavigateTo(string url) => driver.Navigate().GoToUrl(url);
        public void NavigateToHome() => NavigateTo(baseURL);
        public void SetWindowSize(int width, int height) => 
            driver.Manage().Window.Size = new Size(width, height);

        public void Click(By locator) => driver.FindElement(locator).Click();
        
        public void SendKeys(By locator, string text) => 
            driver.FindElement(locator).SendKeys(text);
        
        public void ClearAndSendKeys(By locator, string text)
        {
            var element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(By locator) => driver.FindElement(locator).Text;

        public void ScrollTo(int y) => js.ExecuteScript($"window.scrollTo(0,{y})");
        public void ExecuteJS(string script) => js.ExecuteScript(script);

        public void MoveToElement(By locator)
        {
            var element = driver.FindElement(locator);
            new Actions(driver).MoveToElement(element).Perform();
        }

        public string GetAlertText() => driver.SwitchTo().Alert().Text;
        public void AcceptAlert() => driver.SwitchTo().Alert().Accept();

        public void WaitForElementToBeClickable(By locator, int timeoutSec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public IWebElement WaitForElement(By locator, int timeoutSec = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            return wait.Until(d => d.FindElement(locator));
        }
    }
}