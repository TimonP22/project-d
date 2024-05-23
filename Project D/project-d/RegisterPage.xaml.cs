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
        if (NameEntry == null || EmailEntry == null || PasswordEntry == null) return;
        
        var firstName = NameEntry.Text.Split()[0];
        var lastName = NameEntry.Text.Split()[1];

        Psycholoog newPsychologist = new(firstName, lastName, datePicker.Date, EmailEntry.Text, PasswordEntry.Text);
        await App.DatabaserHelper.AddNewUser(newPsychologist, this);
    }
}