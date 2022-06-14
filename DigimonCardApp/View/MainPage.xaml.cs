namespace DigimonCardApp.View;

public partial class MainPage : ContentPage
{
	public MainPage(DigimonViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

