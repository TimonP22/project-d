using SQLite;

namespace project_d.Objects
{
    [Table("Vragen")]
    public class Vraag : HuiswerkOnderdeel
    {
        public Vraag(int homeworkId, string text)
            : base(homeworkId, text)
        {
        }

        public Vraag()
        { }
    }
}
