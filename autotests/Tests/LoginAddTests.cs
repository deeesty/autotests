using NUnit.Framework;
using OpenQA.Selenium;
using AutoTests.Models;

namespace AutoTests.Tests
{
    [TestFixture]
    public class LoginAddTest : TestBase
    {
        private const string TestUser = "JohnnyMammal";
        private const string TestPassword = "**";
        private const string BookToAdd = "Git Pocket Guide";
        private const string BookToDeleteISBN = "9781449325862";

        [Test]
        public void Login_AddBook_DeleteBook_VerifyOperations()
        {
            SetupBrowser();
            NavigateToBooksSection();
            
            Login(TestUser, TestPassword);
            
            AddBookToCollection(BookToAdd);
            Assert.That(GetAlertText(), Is.EqualTo("Book added to your collection."));
            
            DeleteBook(BookToDeleteISBN);
            Assert.That(GetAlertText(), Is.EqualTo("Book deleted."));
            
            CompleteFlow();
        }

        private void SetupBrowser()
        {
            NavigateToHome();
            SetWindowSize(windowWidth, windowHeight);
        }

        private void NavigateToBooksSection()
        {
            Click(By.CssSelector("a:nth-child(6) > .card"));
        }

        private void Login(string username, string password)
        {
            Click(By.Id("login"));
            SendKeys(By.Id("userName"), username);
            SendKeys(By.Id("password"), password);
            Click(By.Id("login"));
        }

        private void AddBookToCollection(string bookTitle)
        {
            Click(By.CssSelector(".show #item-2 .text"));
            Click(By.LinkText(bookTitle));
            Click(By.CssSelector(".text-right > #addNewRecordButton"));
        }

        private void DeleteBook(string isbn)
        {
            MoveToElement(By.LinkText("Profile"));
            Click(By.CssSelector($"#delete-record-{isbn} path"));
            Click(By.Id("closeSmallModal-ok"));
        }

        private void CompleteFlow()
        {
            Click(By.Id("submit"));
        }
    }
}