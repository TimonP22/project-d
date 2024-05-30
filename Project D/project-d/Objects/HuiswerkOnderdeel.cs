using SQLite;

namespace project_d.Objects;

public abstract class HuiswerkOnderdeel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int HomeworkId { get; set; }
    public string? Text { get; set; }

    protected HuiswerkOnderdeel(int homeworkId, string text)
    {
        HomeworkId = homeworkId;
        Text = text;
    }

    protected HuiswerkOnderdeel()
    { }
}
