namespace DigimonCardApp.ViewModel;

[QueryProperty("DigimonCard", "DigimonCard")]
public partial class DigimonDetailsViewModel : BaseViewModel
{
    public DigimonDetailsViewModel()
    {

    }

    [ObservableProperty]
    DigimonCard digimonCard;
}
