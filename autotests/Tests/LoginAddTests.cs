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
            var book = new BookData(BookToAdd);

            app.Navigation.GoToHomePage();
            app.Navigation.GoToBooksSection();
            app.Auth.Login(account);
            
            app.Book.AddBookToCollection(BookToAdd);
            
            string addAlert = app.GetAlertText();
            Assert.That(addAlert, Is.EqualTo("Book added to your collection."),
                "Книга не добавлена: неверное сообщение алерта");
            Assert.That(app.Book.IsBookInCollection(BookToAdd), 
                $"Книга '{BookToAdd}' не найдена в коллекции");
            
            app.Book.DeleteBook(BookToDeleteISBN);
            
            string deleteAlert = app.GetAlertText();
            Assert.That(deleteAlert, Is.EqualTo("Book deleted."),
                "Книга не удалена: неверное сообщение алерта");
        }
    }
}