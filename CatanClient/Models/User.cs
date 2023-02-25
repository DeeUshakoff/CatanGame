using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public Color Color { get; private set; }
        public User(Guid id, Color color)
        {
            Id = id;
            Color = color;
        }
    }
   
}
