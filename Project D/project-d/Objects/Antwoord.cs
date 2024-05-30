using SQLite;

namespace project_d.Objects;

[Table("Antwoorden")]
public class Antwoord : HuiswerkOnderdeel
{
    public Antwoord(int homeworkId, string text)
        : base(homeworkId, text)
    { }

    public Antwoord()
    { }
}
