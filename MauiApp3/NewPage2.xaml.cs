namespace MauiApp3;

public partial class NewPage2 : ContentPage
     
{
      public static Dictionary<string, bool> resultsDictionary = new Dictionary<string, bool>();

    List<string> players = new List<string>();
    public NewPage2()
    {
        InitializeComponent();
        players = NewPage1.playerList;
        while (players.Count == 0)
        {


            DisplayAlert("B³¹d", "Musisz dodaæ graczy przed ustawieniem preferencji.", "OK");
            return;
        }

    }
    private async void OnImageDo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    void SetPlayerPreference_Clicked(object sender, EventArgs e)
    {
        
        if (playerPicker.SelectedItem == null)
        {
            DisplayAlert("B³¹d", "Wybierz gracza przed ustawieniem preferencji.", "OK");
            return;
        }

       
        string selectedPlayer = (string)playerPicker.SelectedItem;

        
        if (!resultsDictionary.ContainsKey(selectedPlayer))
        {
            
            resultsDictionary.Add(selectedPlayer, true);
        }
        else
        {
           
            resultsDictionary[selectedPlayer] = true;
        }

        
        DisplayAlert("Sukces", $"Preferencja dla gracza {selectedPlayer} ustawiona.", "OK");
    }


    void SetPlayerPreference_Clicked1(object sender, EventArgs e)
    {
       
        if (playerPicker.SelectedItem == null)
        {
            DisplayAlert("B³¹d", "Wybierz gracza przed ustawieniem preferencji.", "OK");
            return;
        }

        
        string selectedPlayer = (string)playerPicker.SelectedItem;

     
        if (!resultsDictionary.ContainsKey(selectedPlayer))
        {
            
            resultsDictionary.Add(selectedPlayer, false);
        }
        else
        {
            
            resultsDictionary[selectedPlayer] = false;
        }

        DisplayAlert("Sukces", $"Preferencja dla gracza {selectedPlayer} ustawiona.", "OK");
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
       
        foreach (var player in players)
        {
            playerPicker.Items.Add(player);
        }

    }
}