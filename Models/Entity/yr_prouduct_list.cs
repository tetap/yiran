using SqlSugar;
using System.Collections.Generic;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 产品列表
    /// </summary>
    public class yr_prouduct_list
    {
        /// <summary>
        /// 产品列表
        /// </summary>
        public yr_prouduct_list()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 图片多张
        /// </summary>
        public System.String images { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public System.String title { get; set; }

        /// <summary>
        /// 访问人数
        /// </summary>
        public System.Int32? people_number { get; set; }

        /// <summary>
        /// 联系号码
        /// </summary>
        public System.String qq { get; set; }

        /// <summary>
        /// 富文本
        /// </summary>
        public System.String content { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime addtime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 是否上架
        /// </summary>
        public System.Int32? Static { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32? sork { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<string> image { get; set; }
    }
}
