using CatanMAUI.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanMAUI.Models.Game
{
    public class Cell
    {
        public readonly int ID;
        public readonly ResourceType ResourceType;
        public List<Player> Owners = new();
        public Cell(int id, ResourceType resourceType)
        {
            ID = id;
            ResourceType = resourceType;
        }
    }
}
