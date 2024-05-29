using project_d.Objects;

namespace project_d;

public partial class ClientHomeworkOverview : ContentPage
{
    public Client clent;
	public ClientHomeworkOverview(Client client, List<Huiswerk> huiswerk)
	{
		InitializeComponent();
        homeworkPicker.ItemsSource = huiswerk;
        clent = client;
    }
    private async void OnAnswerClicked(object sender, EventArgs e)
    {
        Huiswerk selectedHomework = homeworkPicker.SelectedItem as Huiswerk;

        await Navigation.PushAsync(new ClientHomework(clent,selectedHomework));
    }
}