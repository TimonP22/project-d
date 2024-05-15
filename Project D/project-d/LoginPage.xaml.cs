namespace project_d;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    public async void OnLoginBtnClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (email == "psycholoog@gmail.com" || password == "psycholoog123")
        {
            await Navigation.PushAsync(new PsycholoogPage());
        }
        else
        {
            await DisplayAlert("Login niet gelukt", "Email of wachtwoord niet correct", "OK");
        }
    }

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}