using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatanMAUI.Models;
namespace CatanMAUI.ViewModels
{
    class StartupPageViewModel
    {
        public Client Client { get; private set; }
        public StartupPageViewModel()
        {
            Client = new Client();
        }
        public async Task Initialize()
        {
            Client.Close();
            await Client.ConnectToServer();
        }
    }
}
