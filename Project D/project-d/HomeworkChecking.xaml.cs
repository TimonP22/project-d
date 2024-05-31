
using project_d.Objects;
	
namespace project_d;

public partial class HomeworkChecking : ContentPage
{
	Client clients;
	public HomeworkChecking(Huiswerk huiswerk)
	{
		InitializeComponent();
        titel.Text=huiswerk.Title;
		description.Text=huiswerk.Description;
		int id = huiswerk.Id;
        var antwoords = App.DatabaserHelper.GetAntwoord(id);
		Antwoord ans = antwoords.Result;
		 clients= App.DatabaserHelper.GetClient(huiswerk.ClientId).Result;
        try
		{
			if (ans != null)
			{

				antwoord.Text = ans.Text;
			}
			else {
				antwoord.Text = "here is no answer";

            }

        }
		catch
		{
			antwoord.Text = "here is no answer";
		}
    }
    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
		
        await Navigation.PushAsync(new HomeworkOverview(clients),true);
    }
}
