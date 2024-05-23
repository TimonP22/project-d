using project_d.Objects;

namespace project_d;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        Title += Helper.IsPsychologist ? " Psycholoog" : " Cliënt";
	}

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(), true);
    }

    private async void OnLoginBtnClicked(object sender, EventArgs e)
    {
        if (EmailEntry.Text == "psy")
        {
            Helper.User = new("John", "Doe", new DateTime(2000,1,1));
            Helper.User.Clients = new()
            {
                new("Tim", "Akkerman", new DateTime(1980,7,23)),
                new("Jerdy", "Schouten", new DateTime(1997,1,12)),
                new("Martin", "Larsson", new DateTime(1996,9,20)),
                new("Bryan", "Danielson", new DateTime(1981,5,22))
            };
            await Navigation.PushAsync(new StartschermPsycholoog(), true);
            return;
        }
        if (EmailEntry.Text == null || PasswordEntry.Text == null)
        {
            await DisplayAlert("Inloggen", "Niet alle gegevens zijn volledig ingevuld.", "OK");
            return;
        }
        await App.DatabaserHelper.LogIn(this, EmailEntry.Text.ToLower(), PasswordEntry.Text);
    }
}