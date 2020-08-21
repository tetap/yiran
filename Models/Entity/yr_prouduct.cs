using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 产品介绍
    /// </summary>
    public class yr_prouduct
    {
        /// <summary>
        /// 产品介绍
        /// </summary>
        public yr_prouduct()
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
        /// 
        /// </summary>
        public System.String content { get; set; }
    }
}
