using project_d.Objects;

namespace project_d;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        datePicker.MaximumDate = new DateTime(DateTime.Today.Year - 13, 1, 1);
	}

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnRegisterBtnClicked(object sender, EventArgs e)
    {
        if (FirstNameEntry.Text == null || LastNameEntry.Text == null || EmailEntry.Text == null || PasswordEntry.Text == null)
        {
            await DisplayAlert("Error", "Niet alle gegevens zijn correct ingevuld.", "OK");
            return;
        }

        Psycholoog newPsychologist = new(FirstNameEntry.Text, LastNameEntry.Text, datePicker.Date, EmailEntry.Text.ToLower(), PasswordEntry.Text);
        await App.DatabaserHelper.AddNewUser(newPsychologist, this);
    }
}