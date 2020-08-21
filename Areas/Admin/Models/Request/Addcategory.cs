using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    /// <summary>
    /// 添加菜单
    /// </summary>
    [SugarTable("sys_menu")]
    public class Addcategory
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public System.Int32 id { get; set; }
        /// <summary>
        /// 0是一级目录 如果有儿子的话就是他的id依此类推 金字塔
        /// </summary>
        public System.Int32 parent_id { get; set; } = 0;

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入分类名")]
        public System.String name { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Required(ErrorMessage = "请输入规则")]
        public System.String path { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public System.String icon { get; set; } = "&#xe696;";

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; } = 1;
        /// <summary>
        /// 操作
        /// </summary>
        public System.String action { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }
    }
}
