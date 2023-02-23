using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game
{
    internal class Game
    {
        public static List<Game> Games = new List<Game>();
        public readonly Guid Id = new();
        public List<Player> Players { get; private set; } = new();

        public delegate void PlayerConnected(Player player);
        public event PlayerConnected PlayerConnectedEvent;

        public delegate void PlayerDisconnected(Player player);
        public event PlayerDisconnected PlayerDisconnectedEvent;

        public delegate void GameStarted();
        public event GameStarted GameStartedEvent;

        public delegate void GameStopped();
        public event GameStopped GameStoppedEvent;

        public void Start()
        {
            GameStartedEvent?.Invoke();
        }
        public void Stop() 
        {
            GameStoppedEvent?.Invoke();
        }
        public void AddPlayer(Player player)
        {
            //PlayerConnectedEvent?.Invoke(player);
            Players.Add(player);
        }
        public void RemovePlayer(Player player) 
        {
            //PlayerDisconnectedEvent?.Invoke(player);
            Players.Remove(player);
        }
                
    }
}
