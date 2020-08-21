using SqlSugar;

namespace yiran.Areas.Admin.Models.Entity
{
    /// <summary>
    /// 菜单表	
    /// </summary>
    public class sys_menu
    {
        /// <summary>
        /// 菜单表	
        /// </summary>
        public sys_menu()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 0是一级目录 如果有儿子的话就是他的id依此类推 金字塔
        /// </summary>
        public System.Int32 parent_id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public System.String name { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public System.String path { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public System.String icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32 Static { get; set; }
        /// <summary>
        /// 如果有内容的话就是操作 不显示菜单
        /// </summary>
        public System.String action { get; set; }
    }
}
