namespace project_d;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    public async void OnLoginBtnClicked()
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (email == "psycholoog@gmail.com" || password == "psycholoog123")
        {
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid email or password", "OK");
        }
    }

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}