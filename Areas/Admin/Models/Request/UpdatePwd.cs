using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("sys_user")]
    public class UpdatePwd
    {
        /// <summary>
        /// 密码 加密格式MD5
        /// </summary>
        [Required(ErrorMessage = "请输入旧密码")]
        public System.String oldpwd { get; set; }

        [Required(ErrorMessage = "请输入新密码")]
        public System.String newpwd { get; set; }

        [Required(ErrorMessage = "请输入再次密码")]
        [Compare("newpwd", ErrorMessage = "两次密码输入不一致")]
        public System.String repwd { get; set; }
    }
}
