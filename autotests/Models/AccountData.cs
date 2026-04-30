namespace AutoTests.Models
{
    public class AccountData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public AccountData(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }

        public override bool Equals(object obj)
        {
            if (obj is AccountData other)
            {
                return UserName == other.UserName && Password == other.Password;
            }
            return false;
        }

        public override int GetHashCode() => UserName?.GetHashCode() ?? 0;
    }
}