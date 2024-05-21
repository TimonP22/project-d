using project_d.Objects;

namespace project_d;

public partial class HWModuleStartPsycholoog : ContentPage
{
	public HWModuleStartPsycholoog()
	{
		InitializeComponent();
		clientPicker.ItemsSource = Helper.User!.Clients;
	}

	private async void OnReturnBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartschermPsycholoog());
	}
}