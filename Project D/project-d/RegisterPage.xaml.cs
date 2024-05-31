using project_d.Objects;

namespace project_d;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        datePicker.MaximumDate = new DateTime(DateTime.Today.Year - 13, 1, 1);
        Title += Helper.IsPsychologist ? " Psycholoog" : " Cliënt";
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

        if (!IsValidEmail(EmailEntry.Text))
        {
            await DisplayAlert("Error", "Ingevoerde e-mailadres is niet geldig.", "OK");
            return;
        }

        User user;
        if (Helper.IsPsychologist)
            user = new Psycholoog(FirstNameEntry.Text, LastNameEntry.Text, datePicker.Date, EmailEntry.Text.ToLower(), PasswordEntry.Text);
        else
            user = new Client(FirstNameEntry.Text, LastNameEntry.Text, datePicker.Date, EmailEntry.Text.ToLower(), PasswordEntry.Text);
        await App.DatabaserHelper.AddNewUser(user, this);
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        return email.Contains("@");
    }
}