using OpenQA.Selenium;
using AutoTests.Models;

namespace AutoTests.Helpers
{
    public class BookHelper : HelperBase
    {
        public BookHelper(ApplicationManager manager) : base(manager) { }

        public void AddBookToCollection(string bookTitle)
        {
            manager.Navigation.GoToBookStore();
            driver.FindElement(By.LinkText(bookTitle)).Click();
            driver.FindElement(By.Id("addNewRecordButton")).Click();
            driver.FindElement(By.CssSelector(".text-right > #addNewRecordButton")).Click();
        }

        public void DeleteBook(string isbn)
        {
            driver.FindElement(By.CssSelector($"#delete-record-{isbn} path")).Click();
            driver.FindElement(By.Id("closeSmallModal-ok")).Click();
        }

        public string GetAlertText()
        {
            return CloseAlertAndGetItsText();
        }
    }
}