using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yiran.Areas.Admin.Models.Request
{
    [SugarTable("yr_form")]
    public class ShowFormModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public int Static { get; set; }
        public string remark { get; set; }
        public int remark_user { get; set; }
    }
}
