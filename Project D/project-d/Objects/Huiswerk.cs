using SQLite;

namespace project_d.Objects;

[Table("Homework")]
public class Huiswerk
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int PsychologistId { get; set; }
    public int ClientId { get; set; }
    public DateTime DueDate { get; set; }
    public string DueDateString { get => $"Inleveren voor: {DueDate.ToShortDateString()}"; }

    public Huiswerk(string title, string description, int psychologistId, int clientId, DateTime dueDate)
    {
        Title = title;
        Description = description;
        PsychologistId = psychologistId;
        ClientId = clientId;
        DueDate = dueDate;
    }

    public Huiswerk()
    {
    }
}
