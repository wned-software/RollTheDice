namespace MauiApp3;

public partial class NewPage2 : ContentPage
     
{
    static Dictionary<Player, bool> playerPreferences = new Dictionary<Player, bool>();
    List<string> players = new List<string>();
    public NewPage2()
    {
        InitializeComponent();
        players = NewPage1.playerList;
        
    }
    private async void OnImageDo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    void SetPlayerPreference_Clicked(object sender, EventArgs e)
    {
        // Sprawdzenie, czy wybrano gracza
        if (playerPicker.SelectedItem == null)
        {
            DisplayAlert("B��d", "Wybierz gracza przed ustawieniem preferencji.", "OK");
            return;
        }

        // Pobranie wybranego gracza z picker'a
        var selectedPlayer = playerPicker.SelectedItem as Player;

        // Ustalenie preferencji w zale�no�ci od tekstu przycisku
        bool willRollHigh = ((Button)sender).Text == "B�DZIE WYRZUCA� WY�SZ� LICZB� OCZEK";

        // Sprawdzenie, czy w s�owniku istnieje ju� wpis dla tego gracza
        if (playerPreferences.ContainsKey(selectedPlayer))
        {
            // Je�li tak, zaktualizuj preferencj� dla tego gracza
            playerPreferences[selectedPlayer] = willRollHigh;
        }
        else
        {
            // Je�li nie, dodaj nowy wpis do s�ownika
            playerPreferences.Add(selectedPlayer, willRollHigh);
        }

        // Wy�wietlenie komunikatu potwierdzaj�cego zapisanie preferencji
        DisplayAlert("Ustawienia zapisane", $"Preferencje dla gracza '{selectedPlayer.Name}' zosta�y ustawione.", "OK");
    }

    void SetPlayerPreference_Clicked1(object sender, EventArgs e)
    {
        // Sprawdzenie, czy wybrano gracza
        if (playerPicker.SelectedItem == null)
        {
            DisplayAlert("B��d", "Wybierz gracza przed ustawieniem preferencji.", "OK");
            return;
        }

        // Pobranie wybranego gracza z picker'a
        var selectedPlayer = playerPicker.SelectedItem as Player;

        // Ustalenie preferencji w zale�no�ci od tekstu przycisku
        bool willRollLow = ((Button)sender).Text == "B�DZIE WYRZUCA� NI�SZ� LICZB� OCZEK";

        // Sprawdzenie, czy w s�owniku istnieje ju� wpis dla tego gracza
        if (playerPreferences.ContainsKey(selectedPlayer))
        {
            // Je�li tak, zaktualizuj preferencj� dla tego gracza
            playerPreferences[selectedPlayer] = !willRollLow; // Odwr�cenie warto�ci
        }
        else
        {
            // Je�li nie, dodaj nowy wpis do s�ownika
            playerPreferences.Add(selectedPlayer, !willRollLow); // Odwr�cenie warto�ci
        }

        // Wy�wietlenie komunikatu potwierdzaj�cego zapisanie preferencji
        DisplayAlert("Ustawienia zapisane", $"Preferencje dla gracza '{selectedPlayer.Name}' zosta�y ustawione.", "OK");
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