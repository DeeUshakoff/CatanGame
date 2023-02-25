using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanMAUI.Models.Requests.GameCreation
{
    public class CreateGameRequest : Request
    {
        public CreateGameRequest() {
            Name = "CreateGameController";
        }
      
        public static async new Task<Guid> SendRequest() 
        {
            var request = new CreateGameRequest();
            request.RequestParams.Add(Client.Id.ToString());
         
            request.Content = new StringContent("Try to create game");
            
            var response = await Client.SendRequestGetResponeAsync(request, HttpMethod.Get);
            var responseBody = await Client.ReadResponseBodyAsync(response);



            if (!Guid.TryParse(string.Join("", responseBody.Skip(1).SkipLast(1)), out var result))
            {
                await App.Current.MainPage.DisplayAlert("Error", responseBody, "Close");
            }
            
            return result;
        }
    }
}
