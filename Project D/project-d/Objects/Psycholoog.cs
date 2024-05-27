using SQLite;

namespace project_d.Objects;

[Table("Psychologists")]
public class Psycholoog : User
{
    [Ignore]
    public List<Client>? Clients { get; set; }

    public Psycholoog(string firstName, string lastName, DateTime birthday, string email, string password)
        : base(firstName, lastName, birthday, email, password)
    {
        Clients = new();
    }

    public Psycholoog() : base() { }
}
