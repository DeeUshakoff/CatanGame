using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanMAUI.Models.Requests.GameCreation
{
    public class ConnectGameRequest : Request
    {
        public ConnectGameRequest()
        {
            Name = "ConnectGameController";
        }

        public static async Task<string> SendRequest(Guid gameGuid)
        {
            var request = new ConnectGameRequest();
            request.RequestParams.Add(Client.Id.ToString());
            request.RequestParams.Add(gameGuid.ToString());

            request.Content = new StringContent("Try to connect game");

            var response = await Client.SendRequestGetResponeAsync(request, HttpMethod.Get);
            var responseBody = await Client.ReadResponseBodyAsync(response);



            //var result = "";

            return responseBody;
        }
    }
}
