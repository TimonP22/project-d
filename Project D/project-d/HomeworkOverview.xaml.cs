namespace project_d;

public partial class HomeworkOverview : ContentPage
{
	public HomeworkOverview()
	{
		InitializeComponent();
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