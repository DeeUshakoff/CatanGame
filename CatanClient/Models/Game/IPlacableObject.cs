using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanMAUI.Models.Game
{
    public interface IPlacableObject
    {
        Player Owner { get; }
        
    }
}
