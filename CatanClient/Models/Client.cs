using CatanMAUI.Models.Requests;
using CatanMAUI.Models.Requests.GameCreation;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;

namespace CatanMAUI.Models
{
    public class Client
    {
        public static Guid Id { get; } = Guid.NewGuid();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }

        static HttpClient client;

        public Client()
        {
            client = new HttpClient();
            
        }
        public async Task ConnectToServer()
        {

            //var content = JsonContent.Create(new CreateGameRequest());
            //var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8888/Handshake/1/2");

            
            await HandshakeRequest.SendRequest();
            //request.Headers.Add("CreateLobby", Id.ToString());
            //request.Headers.Add("Name", "Test player name");
            //request.Content = content;

            //var response = await client.SendAsync(request);

            //if (response.StatusCode != System.Net.HttpStatusCode.OK)
            //{
            //    await App.Current.MainPage.DisplayAlert("Error", $"{response.StatusCode}", "Ok");
            //}
            
            //var responseContet = response.Content.ReadAsStreamAsync().Result;
            
            //var reader = new StreamReader(responseContet, Encoding.UTF8);
            //var bodyContent = await reader.ReadToEndAsync();
            
        }
        public static async Task<HttpResponseMessage> SendRequestGetResponeAsync(Request request, HttpMethod httpMethod)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, request.GenerateURI());
            requestMessage.Content = request.Content;

            var response = await client.SendAsync(requestMessage);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{response.StatusCode}", "Ok");
            }
            
            return response;
        }
        public static async Task<string> ReadResponseBodyAsync(HttpResponseMessage response)
        {
            var responseContent = response.Content.ReadAsStreamAsync().Result;

            var reader = new StreamReader(responseContent, Encoding.UTF8);
            var bodyContent = await reader.ReadToEndAsync();

            reader.Close();
            return bodyContent;
        }
        protected internal void Close()
        {
            //client.Dispose();
        }
    }
}
