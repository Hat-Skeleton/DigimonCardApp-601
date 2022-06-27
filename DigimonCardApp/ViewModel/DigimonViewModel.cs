using DigimonCardApp.View;

namespace DigimonCardApp.ViewModel;

[QueryProperty(nameof(Set), nameof(Set))]

public partial class DigimonViewModel : BaseViewModel
{
    DigimonService digimonService;
    public ObservableCollection<DigimonCard> DigimonCards { get; set; } = new();

    [ObservableProperty]
    string set;

    public DigimonViewModel(DigimonService digimonService)
    {
        Title = Set;
        this.digimonService = digimonService;
    }

    [ICommand]
    async Task Navigate(string setNo)
    {
        Set = setNo;
        await ClearCards();
        await Shell.Current.GoToAsync($"{nameof(MainPage)}?Set={Set}");
        switch (Set)
        {
            case "New Evolution":
                await GetBT1CardsAsync();
                break;

            case "Ultimate Power":
                await GetBT2CardsAsync();
                break;
            case "Union Impact":
                await GetBT3CardsAsync();
                break;
            case "Great Legend":
                await GetBT4CardsAsync();
                break;
            case "Battle Of Omni":
                await GetBT5CardsAsync();
                break;
            case "Double Diamond":
                await GetBT6CardsAsync();
                break;

        }
    }

    [ICommand]
    async Task ClearCards()
    {
        try
        {
            if (DigimonCards.Count != 0)
                DigimonCards.Clear();
        }
        
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Here's why: {ex.Message}", "OK");
        }
    }

        [ObservableProperty]
    bool isRefreshing;


    [ICommand]
    async Task SearchCards(string query)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();
            digimonCards.Sort();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {

                string cardid = digimoncard.Name.ToLower();
                if (cardid.Contains(query.ToLower()))
                {

                    DigimonCards.Add(digimoncard);

                }
            }

            if (DigimonCards.Count == 0)
            {

                await Shell.Current.DisplayAlert("No Cards Found",
                 $"Try again\n:", "OK");
            }

        }
        catch (Exception ex)
        {
            //Debug.WriteLine(ex);
            //await Shell.Current.DisplayAlert("Error!",
            //    $"Here's why it not work\n: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
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
    async Task GetBT1CardsAsync()
    {
        string set1 = "RELEASE SPECIAL BOOSTER Ver.1.0【BT01-03】";
        string set2 = "RELEASE SPECIAL BOOSTER Ver.1.5【BT01-03】";
        string dash1 = "Dash Pack Ver. 1.0";
        string dash2 = "Dash Pack Ver. 1.5";
        if (IsBusy)
            return;
        try
        {

            //try adding to list then order, then add to DigimonCards
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {
              
                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT1-"))
                {
                    if (digimoncard.Set == set1 || digimoncard.Set == set2 || digimoncard.Set == dash1 || digimoncard.Set == dash2)
                    {
                        DigimonCards.Add(digimoncard);
                    }
                }
            }
            //DigimonCards = new ObservableCollection<DigimonCard>(DigimonCards.OrderByDescending(i => i.CardID).ToList());
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
            isRefreshing = false;
        }
    }

    [ICommand]
    async Task GetBT2CardsAsync()
    {
        string set1 = "RELEASE SPECIAL BOOSTER Ver.1.0【BT01-03】";
        string set2 = "RELEASE SPECIAL BOOSTER Ver.1.5【BT01-03】";
        string dash1 = "Dash Pack Ver. 1.0";
        string dash2 = "Dash Pack Ver. 1.5";
        if (IsBusy)
            return;
        try
        {

            //try adding to list then order, then add to DigimonCards
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {

                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT2-"))
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
            isRefreshing = false;
        }
    }

    [ICommand]
    async Task GetBT3CardsAsync()
    {
        string set1 = "RELEASE SPECIAL BOOSTER Ver.1.0【BT01-03】";
        string set2 = "RELEASE SPECIAL BOOSTER Ver.1.5【BT01-03】";
        string dash1 = "Dash Pack Ver. 1.0";
        string dash2 = "Dash Pack Ver. 1.5";
        if (IsBusy)
            return;
        try
        {

            //try adding to list then order, then add to DigimonCards
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {

                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT3-"))
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
            isRefreshing = false;
        }
    }

    [ICommand]
    async Task GetBT4CardsAsync()
    {
        string set1 = "BOOSTER -GREAT LEGEND- [BT04]";

        if (IsBusy)
            return;
        try
        {

            //try adding to list then order, then add to DigimonCards
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {

                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT4-"))
                {
                    if (digimoncard.Set == set1)
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
            isRefreshing = false;
        }
    }

    [ICommand]
    async Task GetBT5CardsAsync()
    {
        string set1 = "BOOSTER -BATTLE OF OMNI- [BT05]";

        if (IsBusy)
            return;
        try
        {

            //try adding to list then order, then add to DigimonCards
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {

                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT5-"))
                {
                    if (digimoncard.Set == set1)
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
            isRefreshing = false;
        }
    }

    [ICommand]
    async Task GetBT6CardsAsync()
    {
        string set1 = "BOOSTER DOUBLE DIAMOND [BT-06]";

        if (IsBusy)
            return;
        try
        {

            //try adding to list then order, then add to DigimonCards
            IsBusy = true;
            var digimonCards = await digimonService.GetDigimonCard();

            if (DigimonCards.Count != 0)
                DigimonCards.Clear();

            foreach (var digimoncard in digimonCards)
            {

                string cardid = digimoncard.CardID;
                if (cardid.Contains("BT6-") || cardid.Contains("BT1-"))
                {
                    if (digimoncard.Set == set1)
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
            isRefreshing = false;
        }
    }
}
