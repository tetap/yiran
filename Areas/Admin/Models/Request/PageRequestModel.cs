using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    public class PageRequestModel
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int active { get; set; }
        /// <summary>
        /// 返回文字描述
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic data { get; set; }
    }
}
