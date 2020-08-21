using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Models.Entity;

namespace yiran.Areas.Admin.Service
{
    public class sys_HomePageService : DataContext
    {
        /// <summary>
        /// 获取所有banner集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<yr_banner>> GetAllBanner() {
            var query = await Db.Queryable<yr_banner>().OrderBy(c => c.sork, SqlSugar.OrderByType.Desc).ToListAsync();
            return query;
        }
        /// <summary>
        /// 根据id获取一个banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_banner> GetBannerByid(int id) {
            var query = await Db.Queryable<yr_banner>().In(id).SingleAsync();
            return query;
        }
        /// <summary>
        /// 添加banner
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> AddBanner(AddBanner addBanner) {
            var query = await Db.Insertable(addBanner).ExecuteCommandAsync();
            if (query >= 1) {
                return new ResponseModel { code = 200, result = "添加成功~" };
            }
            else {
                return new ResponseModel { code = 0, result = "添加失败~" };
            }
        }
        /// <summary>
        /// 编辑banner
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> Editbanner(AddBanner editbanner)
        {
            var query = await Db.Updateable(editbanner).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 删除banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Delbanner(int[] id)
        {
            var query = await Db.Deleteable<yr_banner>().In(id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "删除成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "删除失败~" };
            }
        }
        /// <summary>
        /// 编辑banner状态
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> Staticbanner(int id, int Static)
        {
            var query = await Db.Updateable<yr_banner>().UpdateColumns(it => new yr_banner() { Static = Static }).Where(it => it.id == id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 更改banner排序
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> SetSork(int id, int sork)
        {
            var query = await Db.Updateable<yr_banner>().UpdateColumns(it => new yr_banner() { sork = sork }).Where(it => it.id == id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 获取about信息
        /// </summary>
        /// <returns></returns>
        public async Task<yr_about> GetAbout() {
            var query = await Db.Queryable<yr_about>().In(1).SingleAsync();
            return query;
        }
        /// <summary>
        /// 编辑about信息
        /// </summary>
        /// <param name="editAbout"></param>
        /// <returns></returns>
        public async Task<ResponseModel> EditAbout(EditAbout editAbout)
        {
            var query = await Db.Updateable(editAbout).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 分页获取技术支持
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public async Task<PageRequestModel> GetSupportPage(int pageIndex, int pageSize, string wheres)
        {
            var query = await Db.Ado.SqlQueryAsync<yr_support_list>($"SELECT * FROM yr_support_list {wheres} order by sork DESC limit {(pageIndex - 1) * pageSize},{pageSize}");
            var total = await Db.Ado.GetIntAsync($"SELECT count(id) FROM yr_support_list {wheres}");
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
        /// <summary>
        /// 添加技术支持
        /// </summary>
        /// <param name="addsupport"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Addsupport(Addsupport_list addsupport) {
            var query = await Db.Insertable(addsupport).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "添加成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "添加失败~" };
            }
        }
        /// <summary>
        /// 获取单个技术支持
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_support_list> GetSupporyByid(int id) {
            var query = await Db.Queryable<yr_support_list>().In(id).SingleAsync();
            return query;
        }
        /// <summary>
        /// 技术支持编辑
        /// </summary>
        /// <param name="addsupport"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Editsupport(Addsupport_list addsupport)
        {
            var query = await Db.Updateable(addsupport).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 删除技术支持
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Delsupport(int[] id)
        {
            var query = await Db.Deleteable<yr_support_list>().In(id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "删除成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "删除失败~" };
            }
        }
        /// <summary>
        /// 更改技术支持排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Sorksupport(int id, int sork)
        {
            var query = await Db.Updateable<yr_support_list>().Where(c => c.id == id).UpdateColumns(c => new yr_support_list { sork = sork }).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 更改技术支持状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        public async Task<ResponseModel> StaticSupport(int id, int Static)
        {
            var query = await Db.Updateable<yr_support_list>().Where(c => c.id == id).UpdateColumns(c => new yr_support_list { Static = Static }).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 更改技术支持标题
        /// </summary>
        /// <param name="support"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdateSupport(yr_support support)
        {
            var query = await Db.Updateable(support).Where(c => c.id == 1).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 更改应用领域内容
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdateField(yr_field field) {
            var query = await Db.Updateable(field).Where(c => c.id == 1).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 分页获取应用领域
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public async Task<PageRequestModel> GetFieldPage(int pageIndex, int pageSize, string wheres)
        {
            var query = await Db.Ado.SqlQueryAsync<yr_field_li>($"SELECT * FROM yr_field_li {wheres} order by sork DESC limit {(pageIndex - 1) * pageSize},{pageSize}");
            var total = await Db.Ado.GetIntAsync($"SELECT count(id) FROM yr_field_li {wheres}");
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
        /// <summary>
        /// 更改应用领域排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Sorkfield(int id, int sork)
        {
            var query = await Db.Updateable<yr_field_li>().Where(c => c.id == id).UpdateColumns(c => new yr_field_li { sork = sork }).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 更改应用领域状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Staticfield(int id, int Static)
        {
            var query = await Db.Updateable<yr_field_li>().Where(c => c.id == id).UpdateColumns(c => new yr_field_li { Static = Static }).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
        /// <summary>
        /// 删除应用领域
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Delfield(int[] id)
        {
            var query = await Db.Deleteable<yr_field_li>().In(id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "删除成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "删除失败~" };
            }
        }
        public async Task<ResponseModel> Addfield(AddField field)
        {
            var query = await Db.Insertable(field).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "添加成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "添加失败~" };
            }
        }
        /// <summary>
        /// 根据ID获取应用领域
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_field_li> GetFieldById(int id)
        {
            var query = await Db.Queryable<yr_field_li>().In(id).SingleAsync();
            return query;
        }
        public async Task<ResponseModel> Editfield(AddField field)
        {
            var query = await Db.Updateable(field).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "修改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "修改失败~" };
            }
        }
    }
}
