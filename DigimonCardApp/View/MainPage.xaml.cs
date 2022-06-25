using DigimonCardApp.ViewModel;

namespace DigimonCardApp.View;

public partial class MainPage : ContentPage
{
	public MainPage(DigimonViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

    }
}

