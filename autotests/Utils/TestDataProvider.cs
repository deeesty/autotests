using System;
using AutoTests.Models;

namespace AutoTests.Utils
{
    public static class TestDataProvider
    {
        public static AccountData GenerateUniqueAccount(string prefix = "User")
        {
            string uniqueId = DateTime.Now.Ticks.ToString().Substring(8);
            return new AccountData(
                firstName: prefix + "First",
                lastName: prefix + "Last", 
                userName: prefix + uniqueId,
                password: "Pass123!"
            );
        }

        public static BookData GetPopularBook()
        {
            return new BookData("Git Pocket Guide");
        }
    }
}