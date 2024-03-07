namespace MauiApp3;

public partial class NewPage2 : ContentPage
{
    List<string> players = new List<string> { "Gracz 1", "Gracz 2", "Gracz 3", "Gracz 4" };
    public NewPage2()
    {
        InitializeComponent();
        
    }
    private async void OnImageDo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
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