using CatanServer.Models.Server;
using CatanServer.Views;

namespace CatanServer.Controllers;

[HttpController(nameof(Handshake))]
public class Handshake
{
    [HttpGET("")]
    public bool AuthClient(string id, string body)
    {
        if (!Guid.TryParse(id, out var clientId))
        {
            LogPage.OutputLog(id);
            return false;
        }

        if (UserList.Users.FindIndex(x => x.Id == Guid.Parse(id)) == -1)
        {

            var newUser = new User(clientId);
            UserList.Users.Add(newUser);
            LogPage.OutputLog($"Added user {newUser.Id}, users count {UserList.Users.Count}");
        }

        return true;
    }
}

