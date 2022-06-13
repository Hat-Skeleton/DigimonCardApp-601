using System.Net.Http.Json;

namespace DigimonCardApp;

public class DigimonService
{
    HttpClient httpClient;
    public DigimonService()
    {
        httpClient = new HttpClient();
    }

    List<DigimonCard> digimonCardList = new();
    public async Task<List<DigimonCard>> GetDigimonCard()
    {
        //    if (digimonCardList?.Count > 0)
        //        return digimonCardList;

        //FOR ONLINE USE

        //var url = "https://raw.githubusercontent.com/Hat-Skeleton/DigimonProjectJson/main/DigimonApp.json?token=GHSAT0AAAAAABU4UXQGTG54INKMTWKLM4TOYUMZBBA";

        //var response = await httpClient.GetAsync(url);

        //if (response.IsSuccessStatusCode)
        //{
        //    digimonCardList = await response.Content.ReadFromJsonAsync<List<DigimonCard>>();
        //}

        using var stream = await FileSystem.OpenAppPackageFileAsync("DigimonApp.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        digimonCardList = JsonSerializer.Deserialize<List<DigimonCard>>(contents);

        return digimonCardList;
    }
}