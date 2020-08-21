using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Entity
{
    /// <summary>
    /// 邮箱配置信息
    /// </summary>
    public class sys_email
    {
        /// <summary>
        /// 邮箱配置信息
        /// </summary>
        public sys_email()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 id { get; set; }

        /// <summary>
        /// 发件人邮箱号
        /// </summary>
        public System.String email { get; set; }

        /// <summary>
        /// 邮箱授权码
        /// </summary>
        public System.String password { get; set; }

        /// <summary>
        /// 是否启用ssl
        /// </summary>
        public System.Int32? isssl { get; set; }

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public System.String host { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public System.Int32 prot { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public System.String name { get; set; }
    }
}
