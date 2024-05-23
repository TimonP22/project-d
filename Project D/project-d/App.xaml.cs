namespace project_d
{
    public partial class App : Application
    {
        public static DatabaseHelper DatabaserHelper { get; private set; }

        public App(DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            DatabaserHelper = databaseHelper;
        }
    }
}
