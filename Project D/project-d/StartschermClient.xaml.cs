using project_d.Objects;

namespace project_d;

public partial class StartschermClient : ContentPage
{
    public StartschermClient()
    {
        InitializeComponent();
        NameLbl.Text = $"Welkom, {Helper.User!.FullName}!";
    }

    private async void OnHWOverzichtBtnClicked(object sender, EventArgs e)
    {
        // placeholder
        await DisplayAlert("Huiswerk overzicht", "navigatie nog niet geimplementeerd", "OK");
    }

    private async void OnHWKiezenBtnClicked(object sender, EventArgs e)
    {
        // placeholder 
        await DisplayAlert("Huiswerk kiezen", "navigatie nog niet geimplementeerd", "OK");
    }

    private async void OnLogoutBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(), true);
    }
}
