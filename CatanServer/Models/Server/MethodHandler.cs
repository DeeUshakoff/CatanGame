using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CatanServer.Controllers;
using CatanServer.Views;
namespace CatanServer.Models.Server
{
    internal class MethodHandler
    {
        public static async Task Handle(HttpListenerContext _httpContext)
        {
            HttpListenerRequest request = _httpContext.Request;

            HttpListenerResponse response = _httpContext.Response;

            //if (_httpContext.Request.Url.Segments.Length < 2) return false;

            string controllerName = _httpContext.Request.Url.Segments[1].Replace("/", "");
            //string controllerName = _httpContext.Request.Url.ToString();
            

            string[] strParams = _httpContext.Request.Url
                                    .Segments
                                    .Skip(2)
                                    .Select(s => s.Replace("/", ""))
                                    .ToArray();
        
            var assembly = Assembly.GetExecutingAssembly();
           
            var controller = assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(HttpController))).FirstOrDefault(c => c.Name.ToLower() == controllerName.ToLower());
            
            if (controller == null) return;
            
            var test = typeof(HttpController).Name;
            
            var method = controller.GetMethods().Where(t => t.GetCustomAttributes(true)
                                                              .Any(attr => attr.GetType().Name == $"Http{_httpContext.Request.HttpMethod}"))
                                                 .FirstOrDefault();

           
            if (method == null) return;

            object[] queryParams = method.GetParameters()
                                .Select((p, i) => Convert.ChangeType(strParams[i], p.ParameterType))
                                .ToArray();

            var ret = method.Invoke(Activator.CreateInstance(controller), queryParams);
            LogPage.OutputLog($"ret: {ret}");
            response.ContentType = "Application/json";

            byte[] buffer = Encoding.ASCII.GetBytes(System.Text.Json.JsonSerializer.Serialize(ret));
            //response.ContentLength64 = buffer.Length;

            
            //response.ContentLength64 = buffer.Length;
            

            Stream output = response.OutputStream;
            await output.WriteAsync(buffer);

            //output.Close();

            
        }
    }
}
