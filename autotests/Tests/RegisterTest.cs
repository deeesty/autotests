using NUnit.Framework;
using OpenQA.Selenium;
using AutoTests.Models;

namespace AutoTests.Tests
{
    [TestFixture]
    public class RegisterTest : TestBase
    {
        [Test]
        public void RegisterNewUser_VerifySuccess()
        {
            var account = new AccountData("Johnny", "Mammal", "JohnnyMammal", "**");

            SetupBrowser();
            NavigateToBooksSection();
            
            OpenRegistrationForm();
            FillAndSubmitRegistration(account);
            
            Assert.That(GetAlertText(), Is.EqualTo("User Registered Successfully."));
            AcceptAlert();
        }

        private void SetupBrowser()
        {
            NavigateToHome();
            SetWindowSize(windowWidth, windowHeight);
        }

        private void NavigateToBooksSection()
        {
            Click(By.CssSelector("a:nth-child(6) h5"));
            ScrollTo(330);
        }

        private void OpenRegistrationForm()
        {
            Click(By.Id("login"));
            Click(By.Id("newUser"));
        }

        private void FillAndSubmitRegistration(AccountData account)
        {
            SendKeys(By.Id("firstname"), account.FirstName);
            SendKeys(By.Id("lastname"), account.LastName);
            SendKeys(By.Id("userName"), account.UserName);
            
            Click(By.CssSelector("#password-wrapper > .col-md-3"));
            
            SendKeys(By.Id("password"), account.Password);
            Click(By.Id("register"));
        }
    }
}