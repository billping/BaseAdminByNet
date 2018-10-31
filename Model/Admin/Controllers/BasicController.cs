using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Z.ViewModel;

namespace Admin.Controllers
{
    public class BasicController : ApiController
    {
        public ResponseModel Success()
        {
            return new ResponseModel()
            {
                Code = ResponseCode.Success,
                Message = "ok"
            };
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">返回的数据</param>
        /// <returns></returns>
        public ResponseModel<T> Success<T>(T data) where T : class
        {
            return new ResponseModel<T>()
            {
                Code = ResponseCode.Success,
                Message = "ok",
                Data = data
            };
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResponseModel Fail(string message)
        {
            return new ResponseModel()
            {
                Code = ResponseCode.Fail,
                Message = message,
            };
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResponseModel Error(string message)
        {
            return new ResponseModel()
            {
                Code = ResponseCode.Error,
                Message = message,
            };
        }
    }
}
