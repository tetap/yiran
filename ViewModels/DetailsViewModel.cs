using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Models.Entity;

namespace yiran.ViewModels
{
    public class DetailsViewModel
    {
        /// <summary>
        /// 公共信息
        /// </summary>
        public yr_common common { get; set; }
        /// <summary>
        /// 产品信息
        /// </summary>
        public yr_prouduct_list product { get; set; }
        /// <summary>
        /// 上一条
        /// </summary>
        public yr_prouduct_list prevproduct { get; set; }
        /// <summary>
        /// 下一条
        /// </summary>
        public yr_prouduct_list nextproduct { get; set; }
    }
}
