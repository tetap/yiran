using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_support_list")]
    public class Addsupport_list
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Required(ErrorMessage = "请上传图标")]
        public System.String icon { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请输入标题")]
        public System.String title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "请输入内容")]
        public System.String content { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? addtime { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 是否展示
        /// </summary>
        public System.Int32? Static { get; set; } = 1;

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; } = 1;
    }
}
