using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_field_li")]
    public class AddField
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
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请输入标题")]
        public System.String title { get; set; }

        /// <summary>
        /// 外链
        /// </summary>
        public System.String href { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }
    }
}
