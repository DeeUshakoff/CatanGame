using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;

namespace CatanServer.Views;

public partial class LogPage : ContentPage
{
    private static VerticalStackLayout LogContentStatic { get; set; } = new();
    public LogPage()
	{
		InitializeComponent();

        foreach(var item in LogContentStatic)
            LogContent.Add(item);
        LogContentStatic = LogContent;
        
    }
    private void ClearLog_Button_Clicked(object sender, EventArgs e)
    {
        LogContent.Clear();
    }
    private async Task ExportLog()
    {
        await DisplayAlert("Alert", "Will be in the future (no)", "Ok :(");
        //var folderpicker = new FolderPicker();
     
        //await folderpicker.PickSingleFolderAsync();
    }
    
    public static void OutputLog(object obj)
    {
        LogContentStatic.Add(new Label() { Text = $"[{DateTime.Now}] {obj}" });
    }

    private async void Export_Button_Clicked(object sender, EventArgs e)
    {
        await ExportLog();
    }
}