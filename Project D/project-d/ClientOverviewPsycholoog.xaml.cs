using project_d.Objects;

namespace project_d;

public partial class ClientOverviewPsycholoog : ContentPage
{
	public ClientOverviewPsycholoog()
	{
		InitializeComponent();
		listClients.ItemsSource = Helper.User!.Clients;
	}

	private async void OnReturnBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartschermPsycholoog());
	}
}