using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 应用领域
    /// </summary>
    public class yr_field
    {
        /// <summary>
        /// 应用领域
        /// </summary>
        public yr_field()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String cn_title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String en_title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public System.String content { get; set; }
    }
}
