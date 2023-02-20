using CatanMAUI.ViewModels;

namespace CatanMAUI.Views;

public partial class StartupPage : ContentPage
{
	StartupPageViewModel viewModel;
	public StartupPage()
	{
		InitializeComponent();
		viewModel = new StartupPageViewModel();
		TryConnect();
    }

    private async void TryConnect_Button_Clicked(object sender, EventArgs e)
    {
		await TryConnect();
    }
	private async Task TryConnect()
	{
		try
		{
            TryConnect_Button.IsEnabled = false;

            LoadingCircle.IsVisible = true;
            await viewModel.Initialize();
            await Navigation.PushModalAsync(new MainPage());
        }
        catch(Exception ex)
		{
            TryConnect_Button.IsEnabled = true;
            LoadingCircle.IsVisible = false;
            await DisplayAlert("Error", ex.Message, "Ok");
		}

    }
}