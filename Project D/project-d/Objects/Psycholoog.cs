using SQLite;

namespace project_d.Objects;

[Table("Psychologists")]
public class Psycholoog : User
{
    public Psycholoog(string firstName, string lastName, DateTime birthday, string email, string password)
        : base(firstName, lastName, birthday, email, password)
    {
    }

    public Psycholoog() : base() { }
}
