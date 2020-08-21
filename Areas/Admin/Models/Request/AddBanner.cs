using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_banner")]
    public class AddBanner
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [Required(ErrorMessage = "请上传图片")]
        public System.String image { get; set; }

        /// <summary>
        /// 图片外联
        /// </summary>
        public System.String href { get; set; }

        /// <summary>
        /// 1:pc 2:m
        /// </summary>
        [Required(ErrorMessage = "请选中客户端")]
        public System.Int32? type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 排序 数值越大排序越高
        /// </summary>
        public System.Int32? sork { get; set; }
    }
}
