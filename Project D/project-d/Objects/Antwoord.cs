using SQLite;

namespace project_d.Objects;

[Table("Antwoorden")]
public class Antwoord : HuiswerkOnderdeel
{
    public int QuestionId { get; set; }
    public Antwoord(int homeworkId, string text, int questionId)
        : base(homeworkId, text)
    {
        QuestionId = questionId;
    }

    public Antwoord()
    { }
}
