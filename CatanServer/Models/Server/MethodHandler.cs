using CatanServer.Controllers;
using CatanServer.Views;
using Microsoft.UI.Xaml.Documents;
using System.Net;
using System.Reflection;
using System.Text;
namespace CatanServer.Models.Server
{
    internal class MethodHandler
    {
        public static async Task Handle(HttpListenerContext _httpContext)
        {
            HttpListenerRequest request = _httpContext.Request;
            HttpListenerResponse response = _httpContext.Response;

            if (_httpContext.Request.Url.Segments.Length < 2) return;

            string controllerName = _httpContext.Request.Url.Segments[1].Replace("/", "");

            string[] strParams = _httpContext.Request.Url
                                    .Segments
                                    .Skip(2)
                                    .Select(s => s.Replace("/", ""))
                                    .ToArray();

            var assembly = Assembly.GetExecutingAssembly();

            var controller = assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(HttpController))).FirstOrDefault(c => c.Name.ToLower() == controllerName.ToLower());

            if (controller == null)
            {
                await SendErrorRespone(response, "Incorrect controller type");
                return;
            }

            var method = controller.GetMethods().Where(t => t.GetCustomAttributes(true)
                                                .Any(attr => attr.GetType().Name == $"Http{_httpContext.Request.HttpMethod}"))
                                                .FirstOrDefault();

            if (method == null) 
            {
                await SendErrorRespone(response, "Incorrect request type");
                return; 
            }

            object[] queryParams = method.GetParameters()
                                .Select((p, i) => Convert.ChangeType(strParams[i], p.ParameterType))
                                .ToArray();

            var body = await ReadRequestBodyAsync(request);
            if (string.IsNullOrWhiteSpace(body))
            {
                await SendErrorRespone(response, "No request body detected");
                return;
            }
            queryParams[queryParams.Length - 1] = body;

            var ret = method.Invoke(Activator.CreateInstance(controller), queryParams);
            
            response.ContentType = "Application/json";

            byte[] buffer = Encoding.ASCII.GetBytes(System.Text.Json.JsonSerializer.Serialize(ret));

            Stream output = response.OutputStream;
            await output.WriteAsync(buffer);
        }
        public static async Task SendErrorRespone(HttpListenerResponse response, string message)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            await response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes(message));
            response.OutputStream.Close();
        }
        public static async Task<string> ReadRequestBodyAsync(HttpListenerRequest request)
        {
            var stream = request.InputStream;
            var encoding = request.ContentEncoding;
            var reader = new StreamReader(stream, encoding);
            var bodyContent = await reader.ReadToEndAsync();

            stream.Close();

            return bodyContent;
        }
    }
}
