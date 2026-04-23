using OpenQA.Selenium;

namespace AutoTests.Helpers
{
    public class NavigationHelper : HelperBase
    {
        private readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToBooksSection()
        {
            driver.FindElement(By.CssSelector("a:nth-child(6) h5")).Click();
        }

        public void GoToLoginPage()
        {
            driver.FindElement(By.Id("login")).Click();
        }

        public void GoToRegistrationPage()
        {
            driver.FindElement(By.Id("newUser")).Click();
        }

        public void GoToBookStore()
        {
            driver.FindElement(By.Id("gotoStore")).Click();
        }

        public void GoToProfile()
        {
            driver.FindElement(By.LinkText("Profile")).Click();
        }
    }
}