using project_d.Objects;

namespace project_d;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
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
            await Navigation.PushAsync(new StartschermPsycholoog(), true);
        }
    }
}