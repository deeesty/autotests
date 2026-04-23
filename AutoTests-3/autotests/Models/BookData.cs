namespace AutoTests.Models
{
    public class BookData
    {
        public string Title { get; set; }
        public string ISBN { get; set; }

        public BookData(string title, string isbn = null)
        {
            Title = title;
            ISBN = isbn;
        }
    }
}