using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game.Resources
{
    public class Resource
    {
        ResourceType ResourceType { get; }
        public Resource(ResourceType resourceType)
        {
            ResourceType = resourceType;
        } 
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
