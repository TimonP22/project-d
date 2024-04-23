namespace project_d;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}