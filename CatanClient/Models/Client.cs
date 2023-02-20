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
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8888/");

            request.Headers.Add("ID", "Dick");
            request.Content = content;

            var response = await client.SendAsync(request);
            var responseContet = response.Content.ReadAsStreamAsync().Result;
            
            var reader = new StreamReader(responseContet, Encoding.UTF8);
            var bodyContent = await reader.ReadToEndAsync();
            
        }


        protected internal void Close()
        {
            //client.Dispose();
        }
    }
}
