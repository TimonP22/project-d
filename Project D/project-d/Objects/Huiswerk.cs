using SQLite;

namespace project_d.Objects;

[Table("Homework")]
public class Huiswerk
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Title { get; set; }
    public int PsychologistId { get; set; }
    public int ClientId { get; set; }
    public DateTime DueDate { get; set; }
    public string DueDateString { get => $"Inleveren voor: {DueDate.ToShortDateString()}"; }

    public Huiswerk(string title, int psychologistId, int clientId)
    {
        Title = title;
        PsychologistId = psychologistId;
        ClientId = clientId;
    }

    public Huiswerk()
    {
    }
}
