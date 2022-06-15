using DigimonCardApp.ViewModel;

namespace DigimonCardApp.View;

public partial class HomePage : ContentPage
{
	public HomePage(DigimonViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}