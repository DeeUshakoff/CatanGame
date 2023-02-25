using CatanMAUI.Models;
using CatanMAUI.Models.Requests.GameCreation;
using CatanMAUI.Views;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CatanMAUI;

public partial class MainPage : ContentPage
{

    private Guid connectGameGuid = new();
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCreateLobbyButtonClicked(object sender, EventArgs e)
	{
        var lobby = new LobbyPage();
        lobby.Create();
        await Navigation.PushModalAsync(lobby);
	}



    private async void ConnectGame_Button_Clicked(object sender, EventArgs e)
    {
        var response = await ConnectGameRequest.SendRequest(connectGameGuid);

        if (response == "\"Lobby is full\"")
        {
            await App.Current.MainPage.DisplayAlert("Lobby", response, "Ok");
            return;
        }
        response = response[1..(response.Length - 1)];
        var lobby = new LobbyPage();
        
        //await App.Current.MainPage.DisplayAlert("Lobby", response, "Ok");

        var playerIds = response.Split(',').Select(Guid.Parse);
        //await App.Current.MainPage.DisplayAlert("Lobby", playerIds.FirstOrDefault().ToString() + " " + playerIds.LastOrDefault().ToString(), "Ok");
        lobby.InitializeExistingLobby(connectGameGuid, playerIds);
        await Navigation.PushModalAsync(lobby);
    }

    private void GameID_Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not Entry gameIdEntry)
        {
            return;
        }

        ConnectGame_Button.IsEnabled = Guid.TryParse(gameIdEntry.Text, out connectGameGuid);
    }

    private async void test_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new GamePage());
    }
}

