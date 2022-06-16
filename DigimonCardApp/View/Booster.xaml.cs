namespace DigimonCardApp.View;

public partial class Booster : ContentPage
{
	public Booster(DigimonViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}