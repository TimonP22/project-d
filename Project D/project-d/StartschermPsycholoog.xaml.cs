using project_d.Objects;

namespace project_d;

public partial class StartschermPsycholoog : ContentPage
{
	public StartschermPsycholoog()
	{
		InitializeComponent();
		NameLbl.Text = $"Welkom, {Helper.User!.FullName}!";
	}

	private async void OnLogoutBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage(), true);
	}

	private async void OnClientOverviewBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ClientOverviewPsycholoog(), true);
	}
}