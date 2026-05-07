using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AutoTests.Models;

namespace TestDataGenerator
{
    [XmlRoot("ArrayOfAccountData")]
    public class AccountDataList : List<AccountData> { }

    [XmlRoot("ArrayOfBookData")]
    public class BookDataList : List<BookData> { }

    class Program
    {
        static void Main(string[] args)
        {
            string type = GetArg(args, "--type", "account");
            int count = int.Parse(GetArg(args, "--count", "5"));
            string output = GetArg(args, "--output", "output.xml");

            Console.WriteLine($"Генерация: тип={type}, количество={count}, файл={output}");

            if (type == "account")
            {
                var accounts = GenerateAccounts(count);
                SerializeToXml(accounts, output);
            }
            else if (type == "book")
            {
                var books = GenerateBooks(count);
                SerializeToXml(books, output);
            }
            else
            {
                Console.WriteLine("Неизвестный тип данных. Используйте --type account или --type book");
                return;
            }

            Console.WriteLine($"Файл сохранён: {Path.GetFullPath(output)}");
        }

        static string GetArg(string[] args, string key, string defaultValue)
        {
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == key) return args[i + 1];
            }
            return defaultValue;
        }

        static List<AccountData> GenerateAccounts(int count)
        {
            var list = new List<AccountData>();
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (int i = 0; i < count; i++)
            {
                string randomStr(int len) => new string(Enumerable.Repeat(chars, len)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                list.Add(new AccountData(
                    FirstName: $"First{randomStr(4)}",
                    LastName: $"Last{randomStr(4)}",
                    UserName: $"user{randomStr(6)}",
                    Password: $"Pass{randomStr(8)}!"
                ));
            }
            return list;
        }

        static List<BookData> GenerateBooks(int count)
        {
            var list = new List<BookData>();
            var bookTitles = new[] {
                "Git Pocket Guide", "You Don't Know JS", "Learning JavaScript Design Patterns",
                "Clean Code", "The Pragmatic Programmer", "Design Patterns", "Refactoring"
            };
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                string isbn = string.Concat(Enumerable.Repeat("0123456789", 13)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                list.Add(new BookData(
                    Title: bookTitles[random.Next(bookTitles.Length)] + $" Vol.{i+1}",
                    ISBN: isbn
                ));
            }
            return list;
        }

        static void SerializeToXml<T>(T data, string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
            
            using var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
            serializer.Serialize(writer, data);
        }
    }
}