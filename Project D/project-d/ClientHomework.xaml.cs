using project_d.Objects;

namespace project_d;

public partial class ClientHomework : ContentPage
{
	public Huiswerk werk;
	public ClientHomework(Client client, Huiswerk huiswerk)
	{
		InitializeComponent();
		var Huiswerk = huiswerk;
	}
    private async void OnSubmitClicked(object sender, EventArgs e) 
	{
	}


}