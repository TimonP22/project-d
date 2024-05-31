using project_d.Objects;

namespace project_d;

public partial class HomeworkSubmittingClient : ContentPage
{
	public Huiswerk Huiswerk;
	
	public HomeworkSubmittingClient(Huiswerk huiswerk)
	{
		InitializeComponent();
		Huiswerk = huiswerk;
		titleLabel.Text = huiswerk.Title;
		descriptionLabel.Text = huiswerk.Description;
	}

	private async void OnSaveBtnClicked(object sender, EventArgs e)
	{
		var vraag = await App.DatabaserHelper.GetQuestion(Huiswerk.Id);
		var antwoord = new Antwoord(Huiswerk.Id, answerEditor.Text, vraag.Id);
		await App.DatabaserHelper.PostHomeworkContent(this, antwoord);
		await Navigation.PopAsync();
		await Navigation.PushAsync(new ClientHomeworkOverview());
	}
}