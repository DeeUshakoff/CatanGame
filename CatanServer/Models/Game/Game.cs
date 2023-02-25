using CatanServer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game
{
    public class Game
    {
        public static List<Game> Games = new List<Game>();
        public Guid Id { get; private set; }
        public List<Player> Players { get; private set; } = new();

        public delegate void PlayerConnected(Player player);
        public event PlayerConnected PlayerConnectedEvent;

        public delegate void PlayerDisconnected(Player player);
        public event PlayerDisconnected PlayerDisconnectedEvent;

        public delegate void GameStarted();
        public event GameStarted GameStartedEvent;

        public delegate void GameStopped();
        public event GameStopped GameStoppedEvent;

        public Game()
        {
            Id = Guid.NewGuid();
            Games.Add(this);
        }
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
            if(!Players.Contains(player))
            {
                Players.Add(player);
            }

            LogPage.OutputLog($"GameID: {Id}, Added Player with ID {player.Id}");
        }
        public void RemovePlayer(Player player) 
        {
            //PlayerDisconnectedEvent?.Invoke(player);
            Players.Remove(player);
        }
                
    }
}
