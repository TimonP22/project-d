using project_d.Objects;

namespace project_d;

public partial class HomeworkSubmittingClient : ContentPage
{
	public HomeworkSubmittingClient(Huiswerk huiswerk)
	{
		InitializeComponent();
		titleLabel.Text = huiswerk.Title;
		descriptionLabel.Text = huiswerk.Description;
	}
}