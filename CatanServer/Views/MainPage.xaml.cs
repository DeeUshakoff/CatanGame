using CatanServer.Models;

namespace CatanServer
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Server server = new Server();
        delegate void StartStopAction();
        private static VerticalStackLayout LogContentStatic { get; set; }
        public MainPage()
        {
            InitializeComponent();
            LogContentStatic = LogContent;
        }
        public static void OutputLog(string text)
        {
            LogContentStatic.Add(new Label() { Text = $"[{DateTime.Now.ToString()}] {text}"});
        }
        private async void StartStopServer_Button_Clicked(object sender, EventArgs e)
        {
            StartStopAction action = server.Status == ServerStatus.Stopped ? server.Start : server.Stop;
            StartStopServer_Button.Text = server.Status == ServerStatus.Stopped ? "Stop" : "Start";

            ServerStatus_Label.Text = server.Status == ServerStatus.Stopped ? "Server status: started" : "Server status: stopped";
            action.Invoke();

            //if(server.Status == ServerStatus.Started)
            //{
            //    server.Stop();
                
            //}
            //else
            //{
            //    server.Start();
            //}
            
        }

        private void ClearLog_Button_Clicked(object sender, EventArgs e)
        {
            LogContent.Clear();
        }
    }
}