namespace CatanMAUI.Views;

public partial class LobbyPage : ContentPage
{
	public LobbyPage()
	{
		InitializeComponent();
	}

    private async void Quit_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}