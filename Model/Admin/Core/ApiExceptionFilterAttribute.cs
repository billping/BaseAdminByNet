using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Z.ViewModel;

namespace Admin.Core
{
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private HttpResponseMessage GetResponseModelMessage(ResponseModel model)
        {
            var content = new ObjectContent(typeof(ResponseModel), model, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = content
            };
        }
    }
}