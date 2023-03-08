using CatanServer.Models.Game;
using CatanServer.Models.Server;
using CatanServer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Controllers
{
    
    [HttpController(nameof(GetGameFieldController))]
    public class GetGameFieldController
    {
        [HttpGET("")]
        public string SendGameField(string userID, string gameID, string body)
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
            if (!game.Players.Exists(x => x.Id == userGuid))
            {
                return "User (you) have no right to enter that game";
            }

            

            return "";  
        }
        

    }
}
