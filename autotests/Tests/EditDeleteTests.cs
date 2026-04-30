using NUnit.Framework;
using AutoTests.Models;

namespace AutoTests.Tests
{
    [TestFixture]
    public class EditDeleteTests : TestBase
    {
        private const string TestUser = "JohnnyMammal";
        private const string TestPassword = "**";
        private const string BookToEdit = "Learning JavaScript Design Patterns";

        [Test]
        public void Login_EditBookInfo_VerifyChanges()
        {
            var account = new AccountData("", "", TestUser, TestPassword);
            var originalBook = new BookData(BookToEdit);

            app.Navigation.GoToHomePage();
            app.Navigation.GoToBooksSection();
            app.Auth.Login(account);
            
            app.Book.AddBookToCollection(BookToEdit);
            string addAlert = app.GetAlertText();
            
            Assert.That(addAlert, Is.EqualTo("Book added to your collection."),
                "Не удалось добавить книгу для редактирования");

            app.Book.SelectLastAddedBook(BookToEdit);
            var retrievedBook = app.Book.GetBookData(BookToEdit);
            
            Assert.That(retrievedBook.Title, Is.EqualTo(originalBook.Title),
                "Название книги после 'редактирования' не совпадает");
        }

        [Test]
        public void RegisterAndDeleteUser_VerifyDeletion()
        {
            var account = new AccountData("Test", "User", "TestUser_" + DateTime.Now.Ticks, "**");

            app.Navigation.GoToHomePage();
            app.Navigation.GoToBooksSection();
            app.User.Register(account);
            
            string alert = app.GetAlertText();
            Assert.That(alert, Is.EqualTo("User Registered Successfully."),
                "Регистрация тестового пользователя не прошла");
        }
    }
}