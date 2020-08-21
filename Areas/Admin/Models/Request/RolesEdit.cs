using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("sys_role")]
    public class RolesEdit
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [Required(ErrorMessage = "请输入角色名")]
        public System.String name { get; set; }

        /// <summary>
        /// 角色拥有权限 数组
        /// </summary>
        public System.String menu_id { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }
    }
}
