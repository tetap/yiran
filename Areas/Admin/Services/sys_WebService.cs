using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Entity;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Models.Entity;

namespace yiran.Areas.Admin.Service
{
    public class sys_WebService : DataContext
    {
        public async Task<ResponseModel> UpdateWeb(EditWeb web)
        {
            var query = await Db.Updateable(web).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "更新成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "更新失败~" };
            }
        }
        public async Task<sys_email> GetSetemail()
        {
            var query = await Db.Queryable<sys_email>().In(1).SingleAsync();
            return query;
        }
        public async Task<ResponseModel> UpdateSetemail(EditSetemail setemail)
        {
            var query = await Db.Updateable(setemail).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "更新成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "更新失败~" };
            }
        }
    }
}
