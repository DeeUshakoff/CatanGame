using CatanServer.Models.Server;

namespace CatanServer.Views
{
    public partial class MainPage : ContentPage
    {
        
        delegate void StartStopAction();
        private static VerticalStackLayout LogContentStatic { get; set; }
        public MainPage()
        {
            InitializeComponent();
            //LogContentStatic = LogContent;
            App.Server.ServerStatusChanged += ChangeStartStopButtonText;
        }
    
        private void ChangeStartStopButtonText(ServerStatus status)
        {
            StartStopServer_Button.Text = status == ServerStatus.Stopped ? "Start" : "Stop";
            ServerStatus_Label.Text = $"Server status: {status}";
        }
        private void StartStopServer_Button_Clicked(object sender, EventArgs e)
        {
            StartStopAction action = App.Server.Status == ServerStatus.Stopped ? App.Server.Start : App.Server.Stop;
            action?.Invoke();
        }

        
    }
}