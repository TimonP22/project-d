using project_d.Objects;

namespace project_d;

public partial class HomeworkOverview : ContentPage
{
    public Client Client; 
    public Huiswerk _selectedItem;
    public HomeworkOverview(Client client)
    {
        InitializeComponent();
        Client = client;
        ClientLbl.Text = Client.ToString();
        homeworkList.ItemsSource = Client.Huiswerk;
        NoHomework.IsVisible = Client.Huiswerk?.Count == 0;

        homeworkList.ItemSelected += OnItemSelected;
    }
    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Huiswerk selectedItem)
        {
            _selectedItem = selectedItem;
        }
    }
    private async void OnViewHomeworkBtnClicked(object sender, EventArgs e)
    {
        if (_selectedItem != null)
        {
            await Navigation.PushAsync(new HomworkChecking(_selectedItem));
        }
        else
        {
        }
    }

     private async void OnCreateHomeworkBtnClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new HomeworkCreate(Client));
    }

    private async void OnReturnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HWModuleStartPsycholoog(), true);
    }
} 