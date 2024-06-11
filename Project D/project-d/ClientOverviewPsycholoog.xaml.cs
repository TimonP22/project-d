using project_d.Objects;
using System.Collections.ObjectModel;

namespace project_d;

public partial class ClientOverviewPsycholoog : ContentPage
{
    private ObservableCollection<Client> clients = new ObservableCollection<Client>();

    public ClientOverviewPsycholoog()
    {
        InitializeComponent();
        listClients.ItemsSource = clients;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshClientList();
    }

    private async void RefreshClientList()
    {
        clients.Clear();
        var psycholoog = Helper.User as Psycholoog;
        if (psycholoog != null)
        {
            foreach (var client in psycholoog.Clients)
            {
                clients.Add(client);
            }
        }
    }

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StartschermPsycholoog());
    }

    private async void OnAddClientBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddClientPage(RefreshClientList));
    }
}
