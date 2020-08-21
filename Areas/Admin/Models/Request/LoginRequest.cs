using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    public class LoginRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        public System.String username { get; set; }

        /// <summary>
        /// 密码 加密格式MD5
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public System.String password { get; set; }
    }
}
