using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_prouduct_list")]
    public class AddProduct
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 图片多张
        /// </summary>
        [Required(ErrorMessage = "请上传图片")]
        public System.String images { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "请输入标题")]
        public System.String title { get; set; }

        /// <summary>
        /// 联系号码
        /// </summary>
        [Required(ErrorMessage = "请输入qq号")]
        public System.String qq { get; set; }

        /// <summary>
        /// 富文本
        /// </summary>
        [Required(ErrorMessage = "请输入内容")]
        public System.String content { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 是否上架
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; }
    }
}
