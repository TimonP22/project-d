using SQLite;

namespace project_d.Objects;

[Table("Clients")]
public class Client : User
{
    public Client(string firstName, string lastName, DateTime birthday, string email, string password)
        : base(firstName, lastName, birthday, email, password)
    {
    }

    public Client() : base() { }

}
