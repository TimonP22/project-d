using project_d.Objects;

namespace project_d;

public partial class ClientOverviewPsycholoog : ContentPage
{
	public ClientOverviewPsycholoog()
	{
		InitializeComponent();
		List<User> clients = new()
		{
			new("Tim", "Akkerman", new DateTime(1980,7,23)),
			new("Jerdy", "Schouten", new DateTime(1997,1,12)),
			new("Martin", "Larsson", new DateTime(1996,9,20)),
			new("Bryan", "Danielson", new DateTime(1981,5,22))
		};
		listClients.ItemsSource = clients;
	}

	private async void OnReturnBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartschermPsycholoog());
	}
}