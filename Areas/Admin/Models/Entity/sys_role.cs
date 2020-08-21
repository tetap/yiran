using SqlSugar;
using System.Collections.Generic;

namespace yiran.Areas.Admin.Models.Entity
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class sys_role
    {
        /// <summary>
        /// 角色权限表
        /// </summary>
        public sys_role()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public System.String name { get; set; }

        /// <summary>
        /// 角色拥有权限 数组
        /// </summary>
        public System.String menu_id { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? addtime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public System.String entity { get; set; }

    }
}

