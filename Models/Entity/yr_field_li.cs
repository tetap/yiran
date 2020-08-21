using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 应用领域列表
    /// </summary>
    public class yr_field_li
    {
        /// <summary>
        /// 应用领域列表
        /// </summary>
        public yr_field_li()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public System.String image { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public System.String title { get; set; }

        /// <summary>
        /// 外链
        /// </summary>
        public System.String href { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? addtime { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }
    }
}
