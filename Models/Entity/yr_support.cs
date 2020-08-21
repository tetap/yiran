using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 技术支持
    /// </summary>
    public class yr_support
    {
        /// <summary>
        /// 技术支持
        /// </summary>
        public yr_support()
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
    }
}
