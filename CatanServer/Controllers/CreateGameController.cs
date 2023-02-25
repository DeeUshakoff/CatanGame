using CatanServer.Models.Game;
using CatanServer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatanServer.Controllers
{
    
    [HttpController(nameof(CreateGameController))]
    public class CreateGameController
    {
        [HttpGET("")]
        public string CreateGame(string userID, string body)
        {
            var game = new Game();
            LogPage.OutputLog("created game " + game.Id.ToString());
            return game.Id.ToString();
        }

    }
}
