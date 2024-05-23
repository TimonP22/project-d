using project_d.Objects;

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
            // Uncomment this line to fill the database with testing values, including 1 psychologist and 4 clients
            // await App.DatabaserHelper.FillDataBase(this);
            await Navigation.PushAsync(new RegisterPage(), true);
        }

        private void OnUserTypeChanged(object sender, EventArgs e)
        {
            Helper.IsPsychologist = userTypePicker.SelectedIndex == 0;
        }
    }

}
