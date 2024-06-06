namespace project_d;

public partial class AddClientPage : ContentPage
{
    public AddClientPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClientBtnClicked(object sender, EventArgs e)
    {
        // client opslaan nog toevoegen
        await DisplayAlert("Opslaan", "Cli�ntgegevens zijn opgeslagen (nog niet ge�mplementeerd)", "OK");
        await Navigation.PopAsync();
    }

    private async void OnCancelBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
