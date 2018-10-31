using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ResponseModel
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public ResponseCode Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
    public class ResponseModel<T> : ResponseModel where T : class
    {
        public T Data { get; set; }
    }

    /// <summary>
    /// 状态码
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 失败
        /// </summary>
        Fail = 1,

        /// <summary>
        /// 未登录
        /// </summary>
        NotLogin = 2,

        /// <summary>
        /// 无权限
        /// </summary>
        NotPermission = 3,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 4,

        /// <summary>
        /// 无效参数
        /// </summary>
        InvalidArgument = 5,
    }
}
