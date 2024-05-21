using project_d.Objects;

namespace project_d;

public partial class HomeworkOverview : ContentPage
{
	public HomeworkOverview(User client)
	{
		InitializeComponent();
        User Client = client;
        ClientLbl.Text = Client.ToString();
        homeworkList.ItemsSource = new List<string>() { "Huiswerk 1, 24/05/2024", "Huiswerk 2, 27/05/2025" };
	}

    private async void OnViewHomeworkBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("View Homework", "Navigating to view homework...", "OK");
    }

    private async void OnCreateHomeworkBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Create Homework", "Navigating to create homework...", "OK");
    }
}