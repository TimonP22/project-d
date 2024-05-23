namespace project_d
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            List<string> userTypes = new() { "Psycholoog", "Cliënt" };
            userTypePicker.ItemsSource = userTypes;
            userTypePicker.SelectedIndex = 0;
        }

        private async void OnLoginBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(), true);
        }

        private async void OnRegisterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }
    }

}
