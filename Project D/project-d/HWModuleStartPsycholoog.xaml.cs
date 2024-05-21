using project_d.Objects;

namespace project_d;

public partial class HWModuleStartPsycholoog : ContentPage
{
	public HWModuleStartPsycholoog()
	{
		InitializeComponent();
		clientPicker.ItemsSource = Helper.User!.Clients;
	}
    private void PopulatePicker()
    {
         
        clientPicker.ItemsSource = Helper.User!.Clients;
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        string description = DescriptionEntry.Text;
        var selectedItem = clientpicker.SelectedItem as PickerItem;

        if (string.IsNullOrEmpty(description)
        {
            DisplayAlert("Error", "Please enter both your name and email.", "OK");
        }
        else
        {
            DisplayAlert("you're homework has been ssuccesfully added");
        }
    }
    private async void OnReturnBtnClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new StartschermPsycholoog());
	}
}