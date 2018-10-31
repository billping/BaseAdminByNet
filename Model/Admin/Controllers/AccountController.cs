using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Z.ViewModel;
namespace Admin.Controllers
{
    public class AccountController : BasicController
    {
        [HttpGet]
        [Route("api/modular/get")]
        public ResponseModel Index()
        {
            var list = new admin
            {
                id = 1
            };

            return Success(list);
        }
        public class admin
        {
            public int id { get; set; }
        }
    }
}
