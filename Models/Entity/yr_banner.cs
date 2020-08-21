using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// banner图	
    /// </summary>
    public class yr_banner
    {
        /// <summary>
        /// banner图	
        /// </summary>
        public yr_banner()
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
        /// 图片外联
        /// </summary>
        public System.String href { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? addtime { get; set; }

        /// <summary>
        /// 1:pc 2:m
        /// </summary>
        public System.Int32? type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 排序 数值越大排序越高
        /// </summary>
        public System.Int32? sork { get; set; }
    }
}
