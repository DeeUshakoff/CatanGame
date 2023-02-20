using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Microsoft.Maui.Controls;
using System.Diagnostics.Metrics;
using Microsoft.Maui.Devices.Sensors;
using System.Reflection.PortableExecutable;



// запускаем сервер

namespace CatanServer.Models
{
    
    public class Server
    {
        HttpListener httpListener = new();
        public ServerStatus Status { get; private set; } = ServerStatus.Stopped;
        public async void Start()
        {
            httpListener.Prefixes.Add("http://localhost:8888/");

            httpListener.Start();
            Status = ServerStatus.Started;
            await ListenAsync();
        }
        public void RemoveConnection(string id)
        {
            
        }
        
        protected internal async Task ListenAsync()
        {
            try
            {
                if (httpListener == null || Status != ServerStatus.Started)
                {
                    MainPage.OutputLog("ERROR: Listener is null");
                    return;
                }
               
                MainPage.OutputLog("Waiting for connection...");



                while (Status == ServerStatus.Started)
                {
                    var context = await httpListener.GetContextAsync();
                    var response = context.Response;

                    var request = context.Request;

                    MainPage.OutputLog($"{string.Join('\n', request.Headers)}");
                    
                    var body = request.InputStream;
                    var encoding = request.ContentEncoding;
                    var reader = new StreamReader(body, encoding);
                    var bodyContent = await reader.ReadToEndAsync();

                    MainPage.OutputLog(bodyContent);

                    var responseText = "Sample request";
                    byte[] responseBuffer = Encoding.UTF8.GetBytes(responseText);

                    Stream output = response.OutputStream;
                    await output.WriteAsync(responseBuffer);

                    output.Close();
                    context.Response.Close();                    
                }
            }
            catch (HttpListenerException ex)
            {
                MainPage.OutputLog(ex.Message);
            }
            finally
            {
                
            }
        }

      
        protected internal void Stop()
        {
                        
            httpListener.Stop(); //остановка сервера
            MainPage.OutputLog($"Server stopped");
            Status = ServerStatus.Stopped;
        }
    }
    
}
