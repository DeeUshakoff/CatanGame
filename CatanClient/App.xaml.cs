using CatanMAUI.Models;

namespace CatanMAUI;

public partial class App : Application
{
	
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
	}
}
