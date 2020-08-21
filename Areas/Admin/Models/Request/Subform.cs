using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    public class Subform
    {
        [Required(ErrorMessage = "Id有误")]
        public int id { get; set; }
        [Required(ErrorMessage = "请输入名称")]
        public string name { get; set; }
        [Required(ErrorMessage = "请输入标题")]
        public string title { get; set; }
        [Required(ErrorMessage = "邮箱号码不可为空")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$", ErrorMessage = "请输入正确的Email.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "请输入内容")]
        public string content { get; set; }
    }
}
