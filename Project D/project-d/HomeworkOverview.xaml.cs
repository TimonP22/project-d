using project_d.Objects;

namespace project_d;

public partial class HomeworkOverview : ContentPage
{
    public Client Client;
	public HomeworkOverview(Client client)
	{
		InitializeComponent();
        Client = client;
        ClientLbl.Text = Client.ToString();
        homeworkList.ItemsSource = Client.Huiswerk;
	}

    private async void OnViewHomeworkBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("View Homework", "Navigating to view homework...", "OK");
    }

    private async void OnCreateHomeworkBtnClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new HomeworkCreate(Client));
    }
} 