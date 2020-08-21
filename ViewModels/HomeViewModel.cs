using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Models.Entity;

namespace yiran.ViewModels
{
    public class HomeViewModel
    {
        /// <summary>
        /// 网站公共信息
        /// </summary>
        public yr_common common { get; set; }
        /// <summary>
        /// banner
        /// </summary>
        public List<yr_banner> banner { get; set; }
        /// <summary>
        /// 关于我们
        /// </summary>
        public yr_about about { get; set; }
        /// <summary>
        /// 技术支持
        /// </summary>
        public yr_support support { get; set; }
        public List<yr_support_list> support_list { get; set; }
        /// <summary>
        /// 应用领域
        /// </summary>
        public yr_field field { get; set; }
        public List<yr_field_li> field_list { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public yr_prouduct product { get; set; }
        public List<yr_prouduct_list> prouduct_list { get; set; }
    }
}
