using BLL;
using JWT;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Z.ViewModel;

namespace Admin.Core
{
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // 登录验证
            var content = actionContext.Request.Properties["MS_HttpContext"] as HttpContextBase;
            var token = content.Request.Headers["Token"];
            if (token == null)
            {
                actionContext.Response = GetResponseModelMessage(new ResponseModel()
                {
                    Code = ResponseCode.NotLogin,
                    Message = "未检测到Token"
                });
                return;
            }
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);


                var json = decoder.DecodeToObject<Login>(token, Consts.Token_secret, verify: true);
                
            }
            catch
            {
                actionContext.Response = GetResponseModelMessage(new ResponseModel()
                {
                    Code = ResponseCode.Error,
                    Message = "Token验证失败"
                });
                return;
            }
            

            //验证 Token


        }
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