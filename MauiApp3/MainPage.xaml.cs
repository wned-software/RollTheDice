namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        private List<string> playerList;

        private int currentPlayerIndex = 0;
        private bool isFirstClick = true;

        public MainPage()
        {
            InitializeComponent();

            // Inicjalizacja listy graczy
            playerList = NewPage1.playerList;

            // Sprawdzenie, czy lista graczy nie jest pusta
            if (playerList.Count > 0)
            {
                // Ustaw pierwszą wartość z listy graczy jako tekst w nameEntry
                nameEntry.Text = playerList[0];
            }
            else
            {
                nameEntry.Text = "Lista graczy jest pusta";
            }

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnRollDiceClicked;
            diceImage.GestureRecognizers.Add(tapGestureRecognizer);

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnScreenTapped;
            diceImage.GestureRecognizers.Add(tapGesture);
        }

        private async void OnImageTapped(object sender, EventArgs e)
        {
            currentPlayerIndex = 0;
            isFirstClick = true;

            await Navigation.PushAsync(new NewPage1());
        }

        private async void OnImage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage2());
        }

        private async void OnRollDiceClicked(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                isFirstClick = false;
            }
            else
            {
                Random random = new Random();
                int diceValue = random.Next(1, 7);

                switch (diceValue)
                {
                    case 1:
                        diceImage.Source = "jeden.png";
                        break;
                    case 2:
                        diceImage.Source = "dwa.png";
                        break;
                    case 3:
                        diceImage.Source = "trzy.png";
                        break;
                    case 4:
                        diceImage.Source = "cztery.png";
                        break;
                    case 5:
                        diceImage.Source = "piec.png";
                        break;
                    case 6:
                        diceImage.Source = "szesc.png";
                        break;
                    default:
                        break;
                }
                label.Opacity = 0;
            }

            
        }

        private void OnScreenTapped(object sender, EventArgs e)
        {
            nameEntry.IsReadOnly = true;

            if (playerList.Count > 0)
            {
                if (currentPlayerIndex >= playerList.Count)
                {
                    currentPlayerIndex = 0; // Wróć do początku listy
                }

                nameEntry.Text = playerList[currentPlayerIndex];
                currentPlayerIndex++; // Przejdź do następnego gracza
            }
            else
            {
                // Obsługa przypadku, gdy lista graczy jest pusta
                nameEntry.Text = "Lista graczy jest pusta";
            }
        }
    }
}




