using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanMAUI.Models.Game
{
    internal interface IResource
    {
        ResourceType ResourceType { get; }
    }
    public enum ResourceType
    {
        Ore,
        Brick,
        Wood,
        Sheep,
        Wheat,
        NoResource
    }
}
