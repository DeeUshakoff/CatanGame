using CatanServer.Models.Game.PlacableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game
{
    internal class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<IPlacableObject> PlacedObjects { get; private set; } = new();
        public int Score { get; private set; }

        public void AddScore(int score)
        {
            Score += score;
            ScoreChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler ScoreChanged;

        //private void OnScoreChanged(EventArgs e)
        //{
        //    ScoreChanged?.Invoke(this, e);
        //}

        public Player() 
        {
            
        }
    }
}
