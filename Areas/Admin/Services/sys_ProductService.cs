using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Models.Entity;

namespace yiran.Areas.Admin.Service
{
    public class sys_ProductService : DataContext
    {
        public async Task<yr_prouduct> GetProuductInfo() {
            var query = await Db.Queryable<yr_prouduct>().In(1).SingleAsync();
            return query;
        
        }
        /// <summary>
        /// 分页获取产品列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public async Task<PageRequestModel> GetProductPage(int pageIndex, int pageSize, string wheres)
        {
            var query = await Db.Ado.SqlQueryAsync<yr_prouduct_list>($"SELECT * FROM yr_prouduct_list {wheres} order by sork DESC limit {(pageIndex - 1) * pageSize},{pageSize}");
            var total = await Db.Ado.GetIntAsync($"SELECT count(id) FROM yr_prouduct_list {wheres}");
            foreach (var q in query)
            {
                if (!string.IsNullOrEmpty(q.images)) {
                    q.image = q.images.Split(",").ToList();
                }
            }
            var PageModel = new PageRequestModel
            {
                code = 200,
                result = "分页获取成功",
                active = pageIndex,
                data = query,
                total = total
            };
            return PageModel;
        }
        public async Task<yr_prouduct_list> GetProductById(int id)
        {
            var query = await Db.Queryable<yr_prouduct_list>().In(id).SingleAsync();
            if (!string.IsNullOrEmpty(query.images)) {
                query.image = query.images.Split(",").ToList();
            }
            return query;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        public async Task<ResponseModel> SetSork(int id, int sork)
        {
            var query = await Db.Updateable<yr_prouduct_list>().Where(c => c.id == id).UpdateColumns(c => new yr_prouduct_list { sork = sork }).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            return new ResponseModel { code = 200, result = "修改失败~" };
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Delproduct(int[] id)
        {
            var query = await Db.Deleteable<yr_prouduct_list>().In(id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "删除成功~" };
            }
            return new ResponseModel { code = 200, result = "删除失败~" };
        }
        /// <summary>
        /// 状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        public async Task<ResponseModel> StaticProduct(int id, int Static)
        {
            var query = await Db.Updateable<yr_prouduct_list>().Where(c=>c.id == id).UpdateColumns(c=>new yr_prouduct_list { Static = Static}).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            return new ResponseModel { code = 200, result = "修改失败~" };
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AddProduct(AddProduct product)
        {
            var query = await Db.Insertable(product).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "添加成功~" };
            }
            return new ResponseModel { code = 200, result = "添加失败~" };
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Editproduct(AddProduct product)
        {
            var query = await Db.Updateable(product).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            return new ResponseModel { code = 200, result = "修改失败~" };
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="prouduct"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Updata(yr_prouduct prouduct)
        {
            prouduct.id = 1;
            var query = await Db.Updateable(prouduct).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            return new ResponseModel { code = 0, result = "修改失败~" };
        }
    }
}
