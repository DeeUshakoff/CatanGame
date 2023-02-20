using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game
{
    internal class Game
    {
        public int Id { get; set; }
        public List<Player> Players { get; private set; }

        public void Start()
        {

        }
        public void Stop() 
        {

        }
    }
}
