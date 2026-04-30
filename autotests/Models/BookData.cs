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

        public override bool Equals(object obj)
        {
            if (obj is BookData other)
            {
                return Title == other.Title;
            }
            return false;
        }

        public override int GetHashCode() => Title?.GetHashCode() ?? 0;
    }
}