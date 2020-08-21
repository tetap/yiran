using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Models.Request
{
    /// <summary>
    /// 提交加盟表单
    /// </summary>
    [SugarTable("yr_form")]
    public class addform
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public System.String name { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Required(ErrorMessage = "请输入手机")]
        public System.String phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "请输入地址")]
        public System.String ress { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "请输入邮箱")]
        public System.String email { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public System.String msg { get; set; }

        /// <summary>
        /// 状态0、未查看.1、已查看，未回复.2、已经完成和回复
        /// </summary>
        public System.Int32? Static { get; set; } = 0;

    }
}
