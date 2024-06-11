using project_d.Objects;

namespace project_d;

public partial class AddClientPage : ContentPage
{
    private Action refreshClientList;

    public AddClientPage(Action refreshClientList)
    {
        InitializeComponent();
        this.refreshClientList = refreshClientList;
    }

    private async void OnSaveClientBtnClicked(object sender, EventArgs e)
    {
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        DateTime birthday = BirthdayPicker.Date;

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            await DisplayAlert("Fout", "Vul alle velden in.", "OK");
            return;
        }

        var psycholoog = Helper.User as Psycholoog;
        if (psycholoog == null)
        {
            await DisplayAlert("Error", "Psycholoog niet gevonden.", "OK");
            return;
        }

        Client newClient = new Client(firstName, lastName, birthday, psychologistId: psycholoog.Id);
        psycholoog.Clients.Add(newClient);

        refreshClientList?.Invoke();

        await DisplayAlert("Opslaan", "Cliëntgegevens zijn opgeslagen.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnCancelBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
