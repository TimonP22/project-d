using SQLite;

namespace project_d.Objects;

[Table("Clients")]
public class Client : User
{
    public int PsychologistId { get; set; }

    public Client(string firstName, string lastName, DateTime birthday, string email ="", string password="", int psychologistId=0)
        : base(firstName, lastName, birthday, email, password)
    {
        PsychologistId = psychologistId;
    }

    public Client() : base() { }

}
