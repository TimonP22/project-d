
using project_d.Objects;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace project_d;

public partial class HomworkChecking : ContentPage
{
    public HomworkChecking(Huiswerk huiswerk)
    {
        InitializeComponent();
        titel.Text = huiswerk.Title;
        description.Text = huiswerk.Description;
        int id = huiswerk.Id;

        // Call the async method without blocking the UI thread
        LoadAntwoordAsync(id);
    }

    private async void LoadAntwoordAsync(int homeworkId)
    {
        var antwoord = await App.DatabaserHelper.GetAntwoordAsync(homeworkId);

        if (antwoord != null && !string.IsNullOrEmpty(antwoord.Text))
        {
            antwoorde.Text = antwoord.Text;
        }
        else
        {
            antwoorde.Text = "no answer";
        }
    }
}