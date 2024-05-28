using project_d.Objects;

namespace project_d;

public partial class HomeworkCreate : ContentPage
{
	User Client;
	public HomeworkCreate(User client)
	{
		InitializeComponent();
		SetDate();
        Client = client;
    }
	private async void OnSubmitClicked(object sender, EventArgs e)
	{
		Huiswerk huiswerk = new(titleEntry.Text, descriptionEditor.Text, Helper.User.Id, Client.Id, datePicker.Date);

		await App.DatabaserHelper.PublishHomework(huiswerk);
		await DisplayAlert("Notification", "Huiswerkopdracht succesvol aangemaakt.", "OK");
        await Navigation.PushAsync(new StartschermPsycholoog());
    }

	private void SetDate()
	{
		datePicker.MinimumDate = DateTime.Today;
	}
}