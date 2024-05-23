using SQLite;

namespace project_d.Objects
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private DateTime Birthday { get; set; }

        [Ignore]
        public string FullName { get => $"{FirstName} {LastName}"; }
        [Ignore]
        public string BirthdayString { get => Birthday.ToShortDateString(); }
        [Ignore]
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                int age = now.Year - Birthday.Year;
                if (now < Birthday.AddYears(age))
                    age--;
                return age;
            }
        }
        [Ignore]
        public List<User>? Clients { get; set; }

        public User(string firstName, string lastName, DateTime birthday, string email="", string password="")
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Email = email;
            Password = password;
        }

        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Birthday = DateTime.MinValue;
        }

        public override string ToString() => $"{FullName}, {Age}";
    }
}
