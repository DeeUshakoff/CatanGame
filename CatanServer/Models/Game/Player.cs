using CatanServer.Models.Game.PlacableObjects;

namespace CatanServer.Models.Game;

public class Player
{
    public Guid Id { get; private set; }
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

    public Player(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}

