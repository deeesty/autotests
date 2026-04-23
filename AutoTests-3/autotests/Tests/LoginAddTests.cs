using NUnit.Framework;
using AutoTests.Models;

namespace AutoTests.Tests
{
    [TestFixture]
    public class LoginAddTests : TestBase
    {
        private const string TestUser = "JohnnyMammal";
        private const string TestPassword = "**";
        private const string BookToAdd = "Git Pocket Guide";
        private const string BookToDeleteISBN = "9781449325862";

        [Test]
        public void Login_AddBook_DeleteBook_VerifyOperations()
        {
            var account = new AccountData("", "", TestUser, TestPassword);

            app.Navigation.GoToHomePage();
            app.Navigation.GoToBooksSection();
            app.Auth.Login(account);
            
            app.Book.AddBookToCollection(BookToAdd);
            Assert.That(app.Book.GetAlertText(), Is.EqualTo("Book added to your collection."));
            
            app.Book.DeleteBook(BookToDeleteISBN);
            Assert.That(app.Book.GetAlertText(), Is.EqualTo("Book deleted."));
        }
    }
}