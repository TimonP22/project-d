using project_d.Objects;

namespace project_d;

public partial class HomeworkCreate : ContentPage
{
	Client Client;
	public HomeworkCreate(Client client)
	{
		InitializeComponent();
		SetDate();
        Client = client;
    }
	private async void OnSubmitClicked(object sender, EventArgs e)
	{
		Huiswerk huiswerk = new(titleEntry.Text, descriptionEditor.Text, Helper.User.Id, Client.Id, datePicker.Date);

		await App.DatabaserHelper.PublishHomework(huiswerk);
		await App.DatabaserHelper.GetHomework(Client);
		int homeworkId = await App.DatabaserHelper.GetLatestHomeworkId();
        Vraag vraag = new(homeworkId, questionEditor.Text);
        await App.DatabaserHelper.PostHomeworkContent(this, vraag);
        await DisplayAlert("Notification", "Huiswerkopdracht succesvol aangemaakt.", "OK");
        await Navigation.PushAsync(new HomeworkOverview(Client));
    }

	private void SetDate()
	{
		datePicker.MinimumDate = DateTime.Today;
	}
}