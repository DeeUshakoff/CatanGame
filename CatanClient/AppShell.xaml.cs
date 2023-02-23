namespace CatanMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}
	public async Task DisplayDialog(string title, string message)
	{
         await DisplayAlert(title, message, "Ok");
    }
}
