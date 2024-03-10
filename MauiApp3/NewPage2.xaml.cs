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
            DisplayAlert("B³¹d", "Wybierz gracza przed ustawieniem preferencji.", "OK");
            return;
        }

        // Pobranie wybranego gracza z picker'a
        var selectedPlayer = playerPicker.SelectedItem as Player;

        // Ustalenie preferencji w zale¿noœci od tekstu przycisku
        bool willRollHigh = ((Button)sender).Text == "BÊDZIE WYRZUCAÆ WY¯SZ¥ LICZBÊ OCZEK";

        // Sprawdzenie, czy w s³owniku istnieje ju¿ wpis dla tego gracza
        if (playerPreferences.ContainsKey(selectedPlayer))
        {
            // Jeœli tak, zaktualizuj preferencjê dla tego gracza
            playerPreferences[selectedPlayer] = willRollHigh;
        }
        else
        {
            // Jeœli nie, dodaj nowy wpis do s³ownika
            playerPreferences.Add(selectedPlayer, willRollHigh);
        }

        // Wyœwietlenie komunikatu potwierdzaj¹cego zapisanie preferencji
        DisplayAlert("Ustawienia zapisane", $"Preferencje dla gracza '{selectedPlayer.Name}' zosta³y ustawione.", "OK");
    }

    void SetPlayerPreference_Clicked1(object sender, EventArgs e)
    {
        // Sprawdzenie, czy wybrano gracza
        if (playerPicker.SelectedItem == null)
        {
            DisplayAlert("B³¹d", "Wybierz gracza przed ustawieniem preferencji.", "OK");
            return;
        }

        // Pobranie wybranego gracza z picker'a
        var selectedPlayer = playerPicker.SelectedItem as Player;

        // Ustalenie preferencji w zale¿noœci od tekstu przycisku
        bool willRollLow = ((Button)sender).Text == "BÊDZIE WYRZUCAÆ NI¯SZ¥ LICZBÊ OCZEK";

        // Sprawdzenie, czy w s³owniku istnieje ju¿ wpis dla tego gracza
        if (playerPreferences.ContainsKey(selectedPlayer))
        {
            // Jeœli tak, zaktualizuj preferencjê dla tego gracza
            playerPreferences[selectedPlayer] = !willRollLow; // Odwrócenie wartoœci
        }
        else
        {
            // Jeœli nie, dodaj nowy wpis do s³ownika
            playerPreferences.Add(selectedPlayer, !willRollLow); // Odwrócenie wartoœci
        }

        // Wyœwietlenie komunikatu potwierdzaj¹cego zapisanie preferencji
        DisplayAlert("Ustawienia zapisane", $"Preferencje dla gracza '{selectedPlayer.Name}' zosta³y ustawione.", "OK");
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