using project_d.Objects;

namespace project_d;

public partial class ClientHomeworkOverview : ContentPage
{
    public Client client;
	public ClientHomeworkOverview()
	{
        InitializeComponent();
        client = (Client)Helper.User!;
        homeworkPicker.ItemsSource = client.Huiswerk;
    }
    private async void OnAnswerClicked(object sender, EventArgs e)
    {
        Huiswerk selectedHomework = homeworkPicker.SelectedItem as Huiswerk;
        if (selectedHomework != null)
        {
            await Navigation.PushAsync(new HomeworkSubmittingClient(selectedHomework));
        }
    }
}