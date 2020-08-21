using SqlSugar;
using System.Collections.Generic;

namespace yiran.Areas.Admin.Models.Entity
{
    /// <summary>
    /// 后台管理员列表	
    /// </summary>
    public class sys_user
    {
        /// <summary>
        /// 后台管理员列表	
        /// </summary>
        public sys_user()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public System.String username { get; set; }

        /// <summary>
        /// 密码 加密格式MD5
        /// </summary>
        public System.String password { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? addtime { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public System.String name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 角色id 数组形式
        /// </summary>
        public System.String role_id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public List<sys_role> sys_role { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public List<sys_menu> sys_menu { get; set; }
    }
}
