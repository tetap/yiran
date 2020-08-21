using SqlSugar;

namespace yiran.Models.Entity
{
    /// <summary>
    /// 加盟表单
    /// </summary>
    public class yr_form
    {
        /// <summary>
        /// 加盟表单
        /// </summary>
        public yr_form()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public System.String name { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public System.String phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public System.String ress { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public System.String email { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public System.String msg { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime? addtime { get; set; }

        /// <summary>
        /// 状态0、未查看.1、已查看，未回复.2、已经完成和回复
        /// </summary>
        public System.Int32? Static { get; set; }

        /// <summary>
        /// 那个管理员进行的操作
        /// </summary>
        public System.String remark { get; set; }

        /// <summary>
        /// 操作者的用户id
        /// </summary>
        public System.Int32? remark_user { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public System.String uname { get; set; }
    }
}
