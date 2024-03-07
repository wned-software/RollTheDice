namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public List<string> PlayersList;

        public MainPage()
        {

            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnRollDiceClicked;
            diceImage.GestureRecognizers.Add(tapGestureRecognizer);
            
        }
        private async void OnImageTapped(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new NewPage1());

        }
        private async void OnImage(object sender, EventArgs e)
        {
         
            await Navigation.PushAsync(new NewPage2());
        }

        private async void OnRollDiceClicked(object sender, EventArgs e)
        {
         
            Random random = new Random();
            int diceValue = random.Next(1, 7);

          
            switch (diceValue)
            {
                case 1:

                    /* Niescalona zmiana z projektu „MauiApp3 (net6.0-windows10.0.19041.0)”
                    Przed:
                                        diceImage.Source = "jeden.png";


                                        break;
                    Po:
                                        diceImage.Source = "jeden.png";


                                        break;
                    */

                    /* Niescalona zmiana z projektu „MauiApp3 (net6.0-maccatalyst)”
                    Przed:
                                        diceImage.Source = "jeden.png";


                                        break;
                    Po:
                                        diceImage.Source = "jeden.png";


                                        break;
                    */

                    /* Niescalona zmiana z projektu „MauiApp3 (net6.0-ios)”
                    Przed:
                                        diceImage.Source = "jeden.png";


                                        break;
                    Po:
                                        diceImage.Source = "jeden.png";


                                        break;
                    */
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
}


