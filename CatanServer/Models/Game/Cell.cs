using CatanServer.Models.Game.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game
{
    internal class Cell
    {
        public readonly string ID;
        public readonly IResource ResourceType;
        public List<Player> Owners = new();
    }
}
