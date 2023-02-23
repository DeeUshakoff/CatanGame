using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanServer.Controllers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HttpController : Attribute
    {
        public string ControllerName;

        public HttpController(string controllerName)
        {
            ControllerName = controllerName;
        }
    }
}
