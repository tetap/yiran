using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 关于我们
    /// </summary>
    public class yr_about
    {
        /// <summary>
        /// 关于我们
        /// </summary>
        public yr_about()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 中文标题
        /// </summary>
        public System.String cn_title { get; set; }

        /// <summary>
        /// 英文标题
        /// </summary>
        public System.String en_title { get; set; }

        /// <summary>
        /// 富文本内容
        /// </summary>
        public System.String content { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime? update_time { get; set; }
    }
}
