

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
           
            players.Add(entryOne.Text);
            players.Add(entryTwo.Text);
            players.Add(entryTree.Text);
            players.Add(entryFour.Text);
            
            




        }
        void RemovePlayer_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var rowIndex = Convert.ToInt32(button.CommandParameter);

            
            StackLayout stackLayout = null;
            foreach (var child in stackLayout.Children)
            {
                if (stackLayout.Children.IndexOf(child) == rowIndex)
                {
                    stackLayout = (StackLayout)child;
                    break;
                }
            }

          
            if (stackLayout != null)
            {
               
                stackLayout.Children.Clear();
            }
        }







        void AddPlayer_Clicked(object sender, EventArgs e)
        {
           
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
                TextColor = Colors.White,
                CornerRadius = 50
            };
            removeButton.Clicked += RemovePlayer_Clicked;

       
            var playerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, -20, 0, 0)
            };
            playerLayout.Children.Add(entry);
            playerLayout.Children.Add(removeButton);

           
            stackLayout.Children.Insert(stackLayout.Children.Count - 1, playerLayout);
        }

        private async void OnImage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage2());
        }

    }
}

