using CatanServer.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace CatanServer.Controllers
{
    [HttpController(nameof(Handshake))]
    public class Handshake
    {
        [HttpGET("")]
        public Player GetAuth()
        {
            return new Player(new Guid(), "Yelan");
        }
    }
}
