using CatanServer.Models.Game;
using System.Net;
using System.Text;
using CatanServer.Views;
namespace CatanServer.Models.Server;
public class Server
{
    HttpListener httpListener = new();
    //ServiceCollection services = new ServiceCollection();
    public delegate void ServerStatusEvent(ServerStatus status);
    public event ServerStatusEvent ServerStatusChanged;

    public ServerStatus Status { get; private set; } = ServerStatus.Stopped;
    public async void Start()
    {
        httpListener.Prefixes.Add("http://localhost:8888/");
        //services.AddLogging();

        httpListener.Start();
        Status = ServerStatus.Started;
        ServerStatusChanged?.Invoke(Status);
        LogPage.OutputLog($"Server started. Listening = {httpListener.IsListening}");
        await ListenAsync();
        
    }
    public void RemoveConnection(string id)
    {

    }

    protected internal async Task ListenAsync()
    {

        if (httpListener == null || Status != ServerStatus.Started)
        {
            LogPage.OutputLog("ERROR: Listener is null");
            return;
        }

        try
        {

            var context = await httpListener.GetContextAsync();
            var response = context.Response;

            var request = context.Request;
            
            //LogPage.OutputLog($"{string.Join('\n', request.Headers)}");


            //if (request.Headers.AllKeys.Contains("CreateLobby"))
            //{
            //    var lobbyID = request.Headers.Get("CreateLobby");

            //    var game = new Game.Game();
            //    var player = new Player(new Guid(lobbyID));
              
            //    game.AddPlayer(player);
            //    Game.Game.Games.Add(game);

            //    LogPage.OutputLog(string.Join('\n', game.Players.Select(p => $"player '{p.Name}': id {p.Id}")));
               
            //}


            await MethodHandler.Handle(context);



            // BODY

            //var body = request.InputStream;
            //var encoding = request.ContentEncoding;
            //var reader = new StreamReader(body, encoding);
            //var bodyContent = await reader.ReadToEndAsync();

            //LogPage.OutputLog(bodyContent);

            //var responseText = "Sample request";
            //byte[] responseBuffer = Encoding.UTF8.GetBytes(responseText);

            Stream output = response.OutputStream;
            //await output.WriteAsync(responseBuffer);

            
            ////reader.Dispose();
            output.Close();
            //context.Response.Close();
            
        }
        catch (HttpListenerException ex)
        {
            LogPage.OutputLog(ex.Message);
        }
        finally
        {
            if(Status == ServerStatus.Started && httpListener.IsListening)
            {
                await ListenAsync();
            }
        }

    }


    protected internal void Stop()
    {
        httpListener.Stop();
        LogPage.OutputLog($"Server stopped. Listening = {httpListener.IsListening}");
        Status = ServerStatus.Stopped;
        ServerStatusChanged?.Invoke(Status);
    }
}
