using CatanMAUI.Models;
using CatanMAUI.Models.Requests.GameCreation;
using CatanServer.Models;
using Microsoft.Maui.Dispatching;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace CatanMAUI.Views;

public partial class LobbyPage : ContentPage
{
    Guid GameID;
    List<User> ConnectedUsers = new();
    Timer timer;
    public static LobbyPage StaticLobbyPage;
    public LobbyPage()
	{
        
        InitializeComponent();
        

        StaticLobbyPage = this;
        
	}
    public void Create()
    {
        SetGameID();
    }
    static void MakeBackgroundConnectRequests(object state)
    {

        StaticLobbyPage.UpdateUserList();
    }
    public void InitializeExistingLobby(Guid gameID, IEnumerable<Guid> playerIds)
    {
        GameID = gameID;
        StaticLobbyPage = this;
        Copy_Button.IsEnabled = true;

        timer = new Timer(MakeBackgroundConnectRequests, null, 0, 1000);

    }
    public async void UpdateUserList()
    {
        var response = await ConnectGameRequest.SendRequest(GameID);

        var playerIds = response[1..(response.Length - 1)].Split(',').Select(Guid.Parse);

        foreach (var playerId in playerIds)
        {
            if (ConnectedUsers.Exists(x => x.Id == playerId))
                continue;
            var user = new User(playerId, new Color(100, 100, 255));
            ConnectedUsers.Add(user);
            await App.Current.Dispatcher.DispatchAsync((Action)(() => PlayerList_ListView.Add(CreateUserListItem(user))));
        }

      

    }
    public HorizontalStackLayout CreateUserListItem(User user)
    {
        var root = new HorizontalStackLayout();
        root.Add(new Label { Text = user.Id == Client.Id ? "You" : "Player", VerticalTextAlignment= TextAlignment.Center});
        root.Add(new Button() { Text = user.Id.ToString().Split('-').FirstOrDefault(), WidthRequest=100 });
        root.Add(new Button { BackgroundColor = user.Color });
        root.Spacing = 10;
        
        return root;
    }
    async void SetGameID()
    {
        GameID = await CreateGameRequest.SendRequest();
        
        Copy_Button.IsEnabled = true;


        timer = new Timer(MakeBackgroundConnectRequests, null, 0, 1000);
    }
    private async void Quit_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void Copy_Button_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(GameID.ToString());
        await DisplayAlert("", "Lobby key has been copied to the clipboard", "Ok");
    }
}