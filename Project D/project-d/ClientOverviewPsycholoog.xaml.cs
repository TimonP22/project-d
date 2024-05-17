namespace project_d;

public partial class ClientOverviewPsycholoog : ContentPage
{
	public ClientOverviewPsycholoog()
	{
		InitializeComponent();
		List<string> Clients = new() { "Henk", "Kees", "Pieter", "Alexander", "Gerard", "Teun" };
		listClients.ItemsSource = Clients;
	}

	private async void OnReturnBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartschermPsycholoog());
	}
}