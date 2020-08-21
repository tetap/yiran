using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Response
{
    public class ResponseModel
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回描述
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 返回内容
        /// </summary>
        public dynamic data { get; set; }
    }
}
