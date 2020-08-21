using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 技术支持列表
    /// </summary>
    public class yr_support_list
    {
        /// <summary>
        /// 技术支持列表
        /// </summary>
        public yr_support_list()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public System.String icon { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public System.String title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public System.String content { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? addtime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 是否展示
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; }
    }
}
