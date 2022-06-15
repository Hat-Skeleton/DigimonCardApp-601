using DigimonCardApp.View;

namespace DigimonCardApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}