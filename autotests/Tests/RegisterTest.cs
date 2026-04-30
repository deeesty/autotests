using NUnit.Framework;
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

            app.Navigation.GoToHomePage();
            app.Navigation.GoToBooksSection();
            app.User.Register(account);

            string alertText = app.GetAlertText();
            Assert.That(alertText, Is.EqualTo("User Registered Successfully."), 
                "Регистрация не прошла: неверное сообщение алерта");
            app.Auth.Login(account);
            Assert.That(app.IsAlertPresent() == false, 
                "После регистрации пользователь не может войти");
        }
    }
}