using CatanServer.Models.Game.PlacableObjects;
using CatanServer.Models.Server;

namespace CatanServer.Models.Game;

public class Player : User
{

    public List<Player> PlayerList { get; set; } = new();
    public List<IPlacableObject> PlacedObjects { get; private set; } = new();
    public int Score { get; private set; }
    public Player(Guid id) : base(id)
    {

    }
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

    
}

