using project_d.Objects;

namespace project_d;

public partial class HomeworkCreate : ContentPage
{
	User Client;
	public HomeworkCreate(User client)
	{
		InitializeComponent();
        Client = client;
    }
	private async void OnSubmitClicked(object sender, EventArgs e)
	{
		Huiswerk huiswerk = new(Entrydescription.Text, Helper.User.Id, Client.Id);

		await App.DatabaserHelper.PublishHomework(huiswerk);
		await DisplayAlert("Notification", "Huiswerkopdracht succesvol aangemaakt.", "OK");
        await Navigation.PushAsync(new StartschermPsycholoog());
    }
}