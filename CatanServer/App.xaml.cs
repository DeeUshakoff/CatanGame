using CatanServer.Models.Server;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace CatanServer
{
    public partial class App : Application
    {
        public static  Server Server {get; private set;}
        public App()
        {
            InitializeComponent();
            Server = new Server();
            MainPage = new AppShell();
            
            
        }
    }
}