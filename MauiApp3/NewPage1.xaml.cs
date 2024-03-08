

namespace MauiApp3
{
    public partial class NewPage1 : ContentPage
    {
         public static List<string> playerList = new List<string>();

        public NewPage1()
        {
            InitializeComponent();

            

        }
        private async void OnImageDo(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            foreach (var child in playerStackLayout.Children)
            {
                if (child is StackLayout stackLayout)
                {
                    foreach (var view in stackLayout.Children)
                    {
                        if (view is Entry entry)
                        {
                            playerList.Add(entry.Text);
                           
                        }
                    }
                }
            }

            

            /*Navigation.PushAsync(new MainPage());*/
        }




        int playerNumber = 1;
        bool playersExist = false; 

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
                Text = (playerList.Count + 1).ToString(), 
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
           
            playerList.Add(entry.Text);

            
            UpdatePlayerNumbers(playerStackLayout);
           
            if (!playersExist)
                playersExist = true;
        }

        void UpdatePlayerNumbers(StackLayout grandParentStackLayout)
        {
            
            playerNumber = 1; 

            foreach (var child in grandParentStackLayout.Children)
            {
                
                if (child is StackLayout playerLayout)
                {
                   
                    foreach (var innerChild in playerLayout.Children)
                    {
                        
                        if (innerChild is Label label && label.Text != "+" && label.Text != "-")
                        {
                            
                            label.Text = playerNumber.ToString();
                            playerNumber++; 
                            break; 
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

