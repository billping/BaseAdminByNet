using Admin.Core;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Z.ViewModel;
using BLL;
namespace Admin.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("api/login")]
        public ResponseModel Login(Login model)
        {
            if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Pwd))
                return Fail("用户名/密码为空");

            if(model.UserName.ToUpper()=="ADMIN" && model.Pwd.ToUpper() == "ADMIN")
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(model, Consts.Token_secret);
                return Success(new
                {
                    Token = token
                });
            }
            return Fail("登陆失败");
        }
        [HttpGet]
        [Route("api/test")]
        [BasicAuthorize]
        public ResponseModel Test()
        {
            return Success();
        }
    }
}
