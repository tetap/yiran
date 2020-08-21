using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("sys_email")]
    public class EditSetemail
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; } = 1;

        /// <summary>
        /// 发件人邮箱号
        /// </summary>
        [Required(ErrorMessage = "发件邮箱不可为空")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$", ErrorMessage = "请输入正确的发件邮箱.")]
        public System.String email { get; set; }

        /// <summary>
        /// 邮箱授权码
        /// </summary>
        [Required(ErrorMessage = "授权码不可为空")]
        public System.String password { get; set; }

        /// <summary>
        /// 是否启用ssl
        /// </summary>
        public System.Int32? isssl { get; set; }

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        [Required(ErrorMessage = "邮件服务器不可为空")]
        public System.String host { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        [Required(ErrorMessage = "端口号不可为空")]
        public System.Int32 prot { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        [Required(ErrorMessage = "发件者名称不可为空")]
        public System.String name { get; set; }
    }
}
