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
            Helper.User = new Psycholoog("John", "Doe", new DateTime(2000,1,1), "jdoe@pd.nl", "jdoe");
            ((Psycholoog)Helper.User).Clients = new()
            {
                new("Tim", "Akkerman", new DateTime(1980,7,23), "takkerman@gmail.com", "tak", Helper.User.Id),
                new("Jerdy", "Schouten", new DateTime(1997,1,12), "jschouten@gmail.com", "jsc", Helper.User.Id),
                new("Martin", "Larsson", new DateTime(1996,9,20), "mlarsson@gmail.com", "mla", Helper.User.Id),
                new("Bryan", "Danielson", new DateTime(1981,5,22), "bdanielson@gmail.com", "bda", Helper.User.Id)
            };
            await Navigation.PushAsync(new StartschermPsycholoog(), true);
            return;
        }
        if (EmailEntry.Text == "fill")
        {
            await App.DatabaserHelper.FillDataBase(this);
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