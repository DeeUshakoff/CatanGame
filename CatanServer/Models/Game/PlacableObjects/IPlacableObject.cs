using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Game.PlacableObjects
{
    public interface IPlacableObject
    {
        Player Owner { get; }
        
    }
}
