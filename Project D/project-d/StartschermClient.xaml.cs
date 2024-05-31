using project_d.Objects;

namespace project_d;

public partial class StartschermClient : ContentPage
{
    public StartschermClient()
    {
        InitializeComponent();
        NameLbl.Text = $"Welkom, {Helper.User!.FullName}!";
    }

    private async void OnHWModBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientHomeworkOverview(), true);
    }

    private async void OnPlaceholderBtnClicked(object sender, EventArgs e)
    {
        // placeholder 
        await DisplayAlert("Placeholder", "Nog niet ge�mplementeerd", "OK");
    }

    private async void OnLogoutBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(), true);
    }
}
