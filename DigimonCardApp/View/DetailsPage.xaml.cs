namespace DigimonCardApp;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DigimonDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}