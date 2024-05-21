namespace project_d.Objects
{
    public class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string BirthdayString { get => Birthday.ToShortDateString(); }
        private DateTime Birthday { get; }
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

        public User(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
    }
}
