using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_about")]
    public class EditAbout
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; } = 1;

        /// <summary>
        /// 中文标题
        /// </summary>
        [Required(ErrorMessage = "请输入中文标题")]
        public System.String cn_title { get; set; }

        /// <summary>
        /// 英文标题
        /// </summary>
        [Required(ErrorMessage = "请输入英文标题")]
        public System.String en_title { get; set; }

        /// <summary>
        /// 富文本内容
        /// </summary>
        public System.String content { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime? update_time { get; set; } = DateTime.Now;
    }
}
