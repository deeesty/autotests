using NUnit.Framework;
using AutoTests.Models;

namespace AutoTests.Tests
{
    [TestFixture]
    public class RegisterTests : TestBase
    {
        [Test]
        public void RegisterNewUser_VerifySuccess()
        {
            var account = new AccountData("Johnny", "Mammal", "JohnnyMammal", "**");

            app.Navigation.GoToHomePage();
            app.Navigation.GoToBooksSection();
            app.User.Register(account);

            Assert.That(app.Book.GetAlertText(), Is.EqualTo("User Registered Successfully."));
        }
    }
}