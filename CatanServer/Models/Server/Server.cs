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
            
           
            await MethodHandler.Handle(context);

            Stream output = response.OutputStream;
         
            
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
