namespace DigimonCardApp.ViewModel;

public partial class BaseViewModel :ObservableObject
{
    public BaseViewModel()
    {

    }

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy => !isBusy;

}
