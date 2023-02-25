using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Models.Server
{
    public class User
    {
        public Guid Id { get; private set; }
      
        public User(Guid id)
        {
            Id = id;

            
        }
    }
    public class UserList
    {
        public static List<User> Users { get; private set; } = new();
    }
}
