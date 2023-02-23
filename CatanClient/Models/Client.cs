using System.Diagnostics;
using System.Text;

namespace CatanMAUI.Models
{

    interface IRequest
    {
        string Name { get; }
        string Content { get; set; }
    }
    class HandshakeRequest : IRequest
    {
        public string Name { get; } = "Handshake";
        public string Content { get; set; }
    }
    class Client
    {
        protected internal string Id { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }

        HttpClient client;

        public Client()
        {
            client = new HttpClient();
            
        }
        public async Task ConnectToServer()
        {

            var content = new StringContent($"{Id}");
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8888/Handshake");

            request.Headers.Add("CreateLobby", Id);
            request.Headers.Add("Name", "Test player name");
            request.Content = content;

            var response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{response.StatusCode}", "Ok");
            }
            
            var responseContet = response.Content.ReadAsStreamAsync().Result;
            
            var reader = new StreamReader(responseContet, Encoding.UTF8);
            var bodyContent = await reader.ReadToEndAsync();

        }
        public async Task CreateLobby()
        {

        }

        protected internal void Close()
        {
            //client.Dispose();
        }
    }
}
