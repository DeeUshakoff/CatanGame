using CatanServer.Models.Game.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game
{
    public class Cell
    {
        public readonly int ID;
        public readonly Resource Resource;
        public List<Player> Owners = new();
        public Cell(int id, Resource resource)
        {
            ID = id;
            Resource = resource;
        }
    }
}
