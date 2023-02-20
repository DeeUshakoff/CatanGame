using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game.PlacableObjects
{
    internal interface IPlacableObject
    {
        Player Owner { get; }
        
    }
}
