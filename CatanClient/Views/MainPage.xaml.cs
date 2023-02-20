using CatanMAUI.Models;
using CatanMAUI.Views;
using System.Net;
using System.Text;

namespace CatanMAUI;

public partial class MainPage : ContentPage
{


	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCreateLobbyButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new LobbyPage());
	}

    private async void StartServerButton_Clicked(object sender, EventArgs e)
    {
		//try
		//{
  //          LoadingCircle.IsVisible= true;
  //          var client = new Client();
  //          await client.ConnectToServer();
  //      }
  //      catch(Exception ex)
		//{
  //          LoadingCircle.IsVisible = false;
  //          await DisplayAlert("Error", ex.Message, "Ok");
  //      }
        
    }
    
}

