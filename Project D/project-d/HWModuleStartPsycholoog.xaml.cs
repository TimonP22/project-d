using project_d.Objects;

namespace project_d;

public partial class HWModuleStartPsycholoog : ContentPage
{
	public HWModuleStartPsycholoog()
	{
		InitializeComponent();
		clientPicker.ItemsSource = ((Psycholoog)Helper.User!).Clients;
	}

	private async void OnReturnBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartschermPsycholoog(), true);
	}

    private async void OnSelectBtnClicked(object sender, EventArgs e)
    {
		if (clientPicker.SelectedItem == null) return;
		var selectedClient = clientPicker.SelectedItem as User;
		await Navigation.PushAsync(new HomeworkOverview(selectedClient!), true);
    }
}