namespace CatanServer.Models.Game.PlacableObjects;

abstract class Building : IPlacableObject
{
    public Player Owner { get; }

    public Building(Player player)
    {
        Owner = player;
    }
}

internal class DefaultBuilding : Building
{
    public DefaultBuilding(Player player) : base(player)
    {
    }
}
internal class BigBuilding : Building
{
    public BigBuilding(Player player) : base(player)
    {
    }
}

