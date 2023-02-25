using CatanServer.Models.Game;
using CatanServer.Models.Server;
using CatanServer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatanServer.Controllers
{
    
    [HttpController(nameof(ConnectGameController))]
    public class ConnectGameController
    {
        [HttpGET("")]
        public string ConnectToGame(string userID, string gameID, string body)
        {
            _ = Guid.TryParse(gameID, out var gameGuid);
            _ = Guid.TryParse(userID, out var userGuid);

            var gameIndex = Game.Games.FindIndex(x => x.Id == gameGuid);

            

            var userIndex = UserList.Users.FindIndex(x => x.Id == userGuid);

            if (gameIndex == -1)
            {
                return "No lobby detected"; // to do replace
            }
            if (userIndex == -1)
            {
                return $"No user {userGuid} detected"; // to do replace
            }

            var game = Game.Games[gameIndex];
            

            if(!game.Players.Exists(x => x.Id == userGuid))
            {
                if (game.Players.Count >= 2)
                {
                    return "Lobby is full";
                }
                var player = new Player(userGuid);
                game.AddPlayer(player);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            return string.Join(',', game.Players.Select(x => x.Id.ToString()));
            //return game.Id.ToString();
        }

    }
}
