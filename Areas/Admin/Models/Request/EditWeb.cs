using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_common")]
    public class EditWeb
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; } = 1;

        /// <summary>
        /// logo图片地址
        /// </summary>
        [Required(ErrorMessage = "请上传logo")]
        public System.String logo { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required(ErrorMessage = "请输入联系电话")]
        public System.String phone { get; set; }

        /// <summary>
        /// qq号码
        /// </summary>
        [Required(ErrorMessage = "请输入联系QQ")]
        public System.String qq { get; set; }

        /// <summary>
        /// 微信二维码图片地址
        /// </summary>
        [Required(ErrorMessage = "请上传Wechat二维码")]
        public System.String wechat { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        [Required(ErrorMessage = "请输入版权信息")]
        public System.String copy { get; set; }

        /// <summary>
        /// 备案号
        /// </summary>
        [Required(ErrorMessage = "请输入备案号")]
        public System.String beian { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime update_time { get; set; } = DateTime.Now;

        /// <summary>
        /// SEO
        /// </summary>
        public System.String description { get; set; }

        /// <summary>
        /// SEO
        /// </summary>
        public System.String keywords { get; set; }
        /// <summary>
        /// biaoti
        /// </summary>
        public System.String title { get; set; }
    }
}
