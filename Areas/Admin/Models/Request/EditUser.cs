using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("sys_user")]
    public class EditUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Required(ErrorMessage = "请输入昵称")]
        public System.String name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 角色id 数组形式
        /// </summary>
        [Required(ErrorMessage = "请选择一个角色")]
        public System.String role_id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public System.Int32? Static { get; set; }
    }
}
