using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Response;
using yiran.Models.Entity;
using yiran.Models.Request;

namespace yiran.Services
{
    public class HomeService : DataContext
    {
        /// <summary>
        /// 网站公共信息
        /// </summary>
        /// <returns></returns>
        public async Task<yr_common> GetCommon() {
            var query = await Db.Queryable<yr_common>().In(1).SingleAsync();
            return query;
        }
        /// <summary>
        /// 获取所有banner
        /// </summary>
        /// <returns></returns>
        public async Task<List<yr_banner>> GetAllBanner() {
            var query = await Db.Queryable<yr_banner>().Where(c => c.Static == 1).OrderBy(c=>c.sork,SqlSugar.OrderByType.Desc).ToListAsync();
            return query;
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public async Task<yr_about> GetAbout() {
            var query = await Db.Queryable<yr_about>().In(1).SingleAsync();
            return query;
        }
        /// <summary>
        /// 应用领域
        /// </summary>
        /// <returns></returns>
        public async Task<yr_field> GetField() {
            var query = await Db.Queryable<yr_field>().In(1).SingleAsync();
            return query;
        }
        /// <summary>
        /// 应用领域列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<yr_field_li>> GetFieldList() {
            var query = await Db.Queryable<yr_field_li>().Where(c => c.Static == 1).OrderBy(c=>c.sork,SqlSugar.OrderByType.Desc).ToListAsync();
            return query;
        }
        /// <summary>
        /// 技术支持
        /// </summary>
        public async Task<yr_support> GetSupport()
        {
            var query = await Db.Queryable<yr_support>().In(1).SingleAsync();
            return query;
        }
        /// <summary>
        /// 技术支持列表
        /// </summary>
        public async Task<List<yr_support_list>> GetSupportList()
        {
            var query = await Db.Queryable<yr_support_list>().Where(c=>c.Static == 1).OrderBy(c => c.sork, SqlSugar.OrderByType.Desc).ToListAsync();
            return query;
        }
        /// <summary>
        /// 产品中心
        /// </summary>
        /// <returns></returns>
        public async Task<yr_prouduct> GetProduct() {
            var query = await Db.Queryable<yr_prouduct>().In(1).SingleAsync();
            return query;
        }
        public async Task<List<yr_prouduct_list>> GetProductList() {
            var query = await Db.Queryable<yr_prouduct_list>().Where(c => c.Static == 1).OrderBy(c => c.sork, SqlSugar.OrderByType.Desc).ToListAsync();
            foreach (var q in query)
            {
                if (!string.IsNullOrEmpty(q.images))
                {
                    q.image = q.images.Split(",").ToList();
                }
            }
            return query;
        }
        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="addform"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AddJoin(addform addform) {
            var query = await Db.Insertable(addform).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "留言成功~" };
            }
            else {
                return new ResponseModel { code = 0, result = "留言失败~" };
            }
        }
        /// <summary>
        /// 获取一条产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_prouduct_list> GetOneProduct(int id) {
            var query = await Db.Queryable<yr_prouduct_list>().In(id).Where(c => c.Static == 1).SingleAsync();
            query.image = query.images.Split(",").ToList();
            return query;
        }
        /// <summary>
        /// 获取上一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_prouduct_list> GetPrevProduct(int id)
        {
            var sql = await Db.Queryable<yr_prouduct_list>().Where(c => c.id < id).OrderBy(c => c.id, SqlSugar.OrderByType.Desc).Take(1).ToListAsync();
            if (sql.Count() > 0)
            {
                return sql[0];
            }
            return new yr_prouduct_list { };
        }
        /// <summary>
        /// 获取下一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_prouduct_list> GetNextProduct(int id)
        {
            var sql = await Db.Queryable<yr_prouduct_list>().Where(c => c.id > id).OrderBy(c => c.id, SqlSugar.OrderByType.Asc).Take(1).ToListAsync();
            if (sql.Count() > 0)
            {
                return sql[0];
            }
            return new yr_prouduct_list { };
        }
        public async Task<ResponseModel> AddNumber(int id) { 
            var query = await Db.Updateable<yr_prouduct_list>().Where(c=>c.id == id).UpdateColumns(it => new { it.people_number }).ReSetValue(it => it.people_number == (it.people_number + 1)).ExecuteCommandAsync();
            return new ResponseModel { code = 200, result = "ok~" };
        }
    }
}
