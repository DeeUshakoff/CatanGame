using CatanServer.Models.Server;
using CatanServer.Views;
using Microsoft.UI.Xaml;


namespace CatanServer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LogPage", typeof(LogPage));
            App.Server.ServerStatusChanged += ChangeServerStatusLabel;
        }

        private void ChangeServerStatusLabel(ServerStatus status)
        {
            ServerStatusLabel.Text = $"server status: {status}";
            BALL.Fill = status == ServerStatus.Started ? Brush.Green : Brush.Red;
        }        
    }
}