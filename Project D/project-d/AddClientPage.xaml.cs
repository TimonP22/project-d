using project_d.Objects;

namespace project_d;

public partial class AddClientPage : ContentPage
{
    public AddClientPage()
    {
        InitializeComponent();
        clientPicker.ItemsSource = Helper.UnassignedClients;
    }

    private async void OnSaveClientBtnClicked(object sender, EventArgs e)
    {
        if (clientPicker.SelectedItem == null) return;

        Client client = (Client)clientPicker.SelectedItem;
        client.PsychologistId = Helper.User!.Id; 

        await App.DatabaserHelper.BindClientToPsychologist(client);
        await DisplayAlert("Notification", $"Cliënt {client.FullName} is succesvol toegevoegd!", "OK");
    }

    private async void OnCancelBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
