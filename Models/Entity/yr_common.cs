using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 网站设置公共信息
    /// </summary>
    public class yr_common
    {
        /// <summary>
        /// 网站设置公共信息
        /// </summary>
        public yr_common()
        {
        }

        /// <summary>
        /// 唯一id就一条
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// logo图片地址
        /// </summary>
        public System.String logo { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public System.String phone { get; set; }

        /// <summary>
        /// qq号码
        /// </summary>
        public System.String qq { get; set; }

        /// <summary>
        /// 微信二维码图片地址
        /// </summary>
        public System.String wechat { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        public System.String copy { get; set; }

        /// <summary>
        /// 备案号
        /// </summary>
        public System.String beian { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime update_time { get; set; }

        /// <summary>
        /// SEO
        /// </summary>
        public System.String description { get; set; }

        /// <summary>
        /// SEO
        /// </summary>
        public System.String keywords { get; set; }
        /// <summary>
        /// biaoti
        /// </summary>
        public System.String title { get; set; }
    }
}
