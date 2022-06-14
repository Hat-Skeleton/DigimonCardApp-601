

namespace DigimonCardApp.ViewModel;

public partial class DigimonViewModel : BaseViewModel
{
    DigimonService digimonService;
    public ObservableCollection<DigimonCard> DigimonCards { get; } = new();
    


    public DigimonViewModel(DigimonService digimonService)
    {
        Title = "Booster Sets";
        this.digimonService = digimonService;
    }

    [ICommand]
    async Task GoToDetailsAsync(DigimonCard digimonCard)
    {
        if (digimonCard is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
        {
            { "DigimonCard", digimonCard }
        });
    }

    [ICommand]
    async Task GetDigimonCardsAsync()
    {
        string set1 = "RELEASE SPECIAL BOOSTER Ver.1.0【BT01-03】";
        string set2 = "RELEASE SPECIAL BOOSTER Ver.1.5【BT01-03】";
        string dash1 = "Dash Pack Ver. 1.0";
        string dash2 = "Dash Pack Ver. 1.5";
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {
                //
                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT1-"))
                {
                    if (digimoncard.Set == set1 || digimoncard.Set == set2 || digimoncard.Set == dash1 || digimoncard.Set == dash2)
                    {
                        DigimonCards.Add(digimoncard);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Here's why: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
