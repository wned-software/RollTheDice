

namespace MauiApp3
{
    public partial class NewPage1 : ContentPage
    {
        public List<string> players;

        public NewPage1()
        {
            InitializeComponent();

            // Dodaj pocz¹tkowych 4 graczy

        }
        private async void OnImageDo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        private  async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
           
           
            
            




        }
        

        int playerNumber = 1;
        bool playersExist = false; // Zmienna przechowuj¹ca informacjê o istnieniu graczy

        void RemovePlayer_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var parentStackLayout = (StackLayout)button.Parent;
            var grandParentStackLayout = (StackLayout)parentStackLayout.Parent;
            grandParentStackLayout.Children.Remove(parentStackLayout);
            UpdatePlayerNumbers(grandParentStackLayout);
        }

        void AddPlayer_Clicked(object sender, EventArgs e)
        {
            var frame = new Frame
            {
                BackgroundColor = Color.FromHex("#c7c7c6"),
                Margin = new Thickness(20, 0, 20, 0),
                Padding = new Thickness(10, 0),
                HeightRequest = 65,
                CornerRadius = 10,
                BorderColor = Colors.Black,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var label = new Label
            {
                Text = playersExist ? playerNumber.ToString() : "5", // Jeœli nie ma jeszcze graczy, ustawiaj¹c pocz¹tkow¹ wartoœæ na 5
                VerticalOptions = LayoutOptions.Center,
                FontSize = 90,
                FontFamily = "Miniver-Regular",
                Margin = new Thickness(20, 0, 0, 0)
            };

            var entry = new Entry
            {
                IsEnabled = true,
                IsReadOnly = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 15
            };

            var removeButton = new Button
            {
                Text = "-",
                BackgroundColor = Colors.Black,
                HeightRequest = 50,
                WidthRequest = 50,
                TextColor = Color.FromHex("#c7c7c6"),
                CornerRadius = 50,
                FontSize = 100,
                Margin = new Thickness(0, 0, 20, 0),
                Padding = new Thickness(0, -53, 0, 0)
            };
            removeButton.Clicked += RemovePlayer_Clicked;

            var playerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, -20, 0, 0)
            };

            frame.Content = entry;

            playerLayout.Children.Add(label);
            playerLayout.Children.Add(frame);
            playerLayout.Children.Add(removeButton);

            playerNumber++;

            playerStackLayout.Children.Insert(playerStackLayout.Children.Count, playerLayout);

            // Zaktualizuj flagê playersExist na true po dodaniu pierwszego gracza
            if (!playersExist)
                playersExist = true;
        }

        void UpdatePlayerNumbers(StackLayout grandParentStackLayout)
        {
            // Pocz¹tkowa wartoœæ numerka gracza
            playerNumber = playersExist ? 1 : 5; // Ustaw pocz¹tkow¹ wartoœæ na 1, jeœli istniej¹ ju¿ gracze, w przeciwnym razie na 5

            // Przejrzyj wszystkie StackLayout-y zawieraj¹ce numery graczy
            foreach (var child in grandParentStackLayout.Children)
            {
                // Jeœli dziecko jest StackLayout-em
                if (child is StackLayout playerLayout)
                {
                    // Przejrzyj wszystkie elementy w danym StackLayout-ie
                    foreach (var innerChild in playerLayout.Children)
                    {
                        // Jeœli dziecko jest etykiet¹ (Label), która wyœwietla numer gracza
                        if (innerChild is Label label && label.Text != "+" && label.Text != "-")
                        {
                            // Zaktualizuj numer gracza
                            label.Text = playerNumber.ToString();
                            playerNumber++; // PrzejdŸ do nastêpnego numeru gracza
                            break; // PrzejdŸ do nastêpnego StackLayout-a z numerem gracza
                        }
                    }
                }
            }
        }



        private async void OnImage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage2());
        }

    }
}

