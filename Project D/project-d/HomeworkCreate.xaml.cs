using project_d.Objects;

namespace project_d;

public partial class HomeworkCreate : ContentPage
{
	public HomeworkCreate(User client)
	{
		InitializeComponent();
        User Client = client;
    }
	private void OnSubmitClicked(object sender, EventArgs e)
	{
		string description = Entrydescription.Text;

        Navigation.PushAsync(new StartschermPsycholoog());

    }
}