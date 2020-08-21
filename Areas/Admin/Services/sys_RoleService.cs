using Microsoft.AspNetCore.Http;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using yiran.Areas.Admin.Common;
using yiran.Areas.Admin.Models.Entity;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Tools;

namespace yiran.Areas.Admin.Service
{
    public class sys_RoleService : DataContext
    {
        /// <summary>
        /// 获取的所有操作和页面
        /// </summary>
        /// <param name="path"></param> 父节点
        /// <returns></returns>
        public async Task<List<sys_menu>> getPageMenu(HttpContext context)
        {
            try
            {
                var session = context.Session.Get<sys_user>("yr_user");
                if (!session.sys_role.Where(c => c.entity == "SuperAdmin").Any())
                {
                    var page = await Db.Queryable<sys_menu>().In(session.role_id.Split(",", StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray()).Where(c => c.action != "").ToListAsync();
                    return page;
                }
                else
                {
                    var page = await Db.Queryable<sys_menu>().Where(c => c.action != "").ToListAsync();
                    return page;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取所有权限分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<sys_menu>> GetCategory()
        {
            var query = await Db.Queryable<sys_menu>().Where(c => c.parent_id == 0).OrderBy(c => c.sork, SqlSugar.OrderByType.Desc).ToListAsync();
            return query;
        }
        /// <summary>
        /// 添加权限分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<ResponseModel> AddCategrory(Addcategory category)
        {
            category.path = category.path.Trim();
            var isAny = Db.Queryable<sys_menu>().Where(c => SqlFunc.ToLower(c.path) == SqlFunc.ToLower(category.path)).Any();
            if (isAny)
            {
                return new ResponseModel { code = 0, result = "已存在该规则分类,规则不能相同~" };
            }
            var query = await Db.Insertable(category).ExecuteCommandAsync();
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
        /// 编辑权限分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<ResponseModel> EditCategrory(Addcategory category)
        {
            category.path = category.path.Trim();
            var isAny = Db.Queryable<sys_menu>().Where(c => c.id == category.id).Any();
            if (!isAny)
            {
                return new ResponseModel { code = 0, result = "不存在此数据~" };
            }
            var query = await Db.Updateable(category).ExecuteCommandAsync();
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
        /// 删除权限分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> RemoveCategrory(int[] id)
        {
            if (id.Count() < 1)
            {
                return new ResponseModel { code = 0, result = "没有要删除的~" };
            }
            var query = await Db.Deleteable<sys_menu>().In(id).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "成功删除 " + query + " 项~" };
            }
            return new ResponseModel { code = 0, result = "删除失败~" };
        }
        /// <summary>
        /// 更改权限分类排序
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> RemoveCategrory(string id, string sork)
        {
            if (!CheckNumber(id) || !CheckNumber(sork))
            {
                return new ResponseModel { code = 0, result = "参数有误" };
            }
            var query = await Db.Updateable<sys_menu>().Where(c => c.id == int.Parse(id)).UpdateColumns(it => new { it.sork }).ReSetValue(it => it.sork == int.Parse(sork)).ExecuteCommandAsync();
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
        /// 获取单个分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> GetOntCategrory(string id)
        {
            if (!CheckNumber(id))
            {
                return new ResponseModel { code = 0, result = "参数有误~" };
            }
            var query = await Db.Queryable<sys_menu>().Where(c => c.id == int.Parse(id)).SingleAsync();
            if (query == null)
            {
                return new ResponseModel { code = 0, result = "没有找到~" };
            }
            return new ResponseModel { code = 200, result = "OK~", data = query };
        }
        /// <summary>
        /// 验证数字
        /// </summary>
        /// <param name="number">数字内容</param>
        /// <returns>true 验证成功 false 验证失败</returns>
        public bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            Regex regex = new Regex(@"^(-)?\d+(\.\d+)?$");
            if (regex.IsMatch(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取所有菜单项
        /// </summary>
        /// <returns></returns>
        public async Task<List<sys_menu>> GetAllMenu()
        {
            var query = await Db.Queryable<sys_menu>().OrderBy(c => c.sork, OrderByType.Desc).ToListAsync();
            return query;
        }
        /// <summary>
        /// 分页获取用户
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task<PageRequestModel> GetPageUser(int pageIndex, int pageSize, string where)
        {
            var query = await Db.Ado.SqlQueryAsync<sys_user>($"SELECT id,addtime,name,remark,role_id,Static FROM sys_user {where} limit {(pageIndex - 1) * pageSize},{pageSize}");
            var total = await Db.Ado.GetIntAsync($"SELECT count(id) FROM sys_user {where}");
            var role = await Db.Ado.SqlQueryAsync<sys_role>("SELECT id,name,entity FROM sys_role");
            foreach (var q in query)
            {
                var role_id = q.role_id.Split(",", StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                var roleList = new List<sys_role>();
                foreach (var r in role_id)
                {
                    roleList.Add(role.SingleOrDefault(c => c.id == int.Parse(r)));
                }
                q.sys_role = roleList;
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
        public async Task<List<sys_role>> GetAllRole()
        {
            return await Db.Queryable<sys_role>().ToListAsync();
        }
        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UserDel(int[] id)
        {
            var isRoot = Array.IndexOf(id, 1); //是否选择了root
            if (isRoot == -1)
            {
                var query = await Db.Deleteable<sys_user>().In(id).ExecuteCommandAsync();
                if (query >= 1)
                {
                    return new ResponseModel { code = 200, result = "删除成功~" };
                }
                else
                {
                    return new ResponseModel { code = 0, result = "删除失败~" };
                }
            }
            else
            {
                return new ResponseModel { code = 0, result = "不可以删除超级管理员~" };
            }
        }
        /// <summary>
        /// 获取一个用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<sys_user> GetOneUser(int id)
        {
            var query = await Db.Queryable<sys_user>().Where(c => c.id == id).SingleAsync();
            return query;
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Useredit(EditUser user)
        {
            if (user.id == 1)
            {
                return new ResponseModel { code = 0, result = "不可以更改超级管理员~" };
            }
            var query = await Db.Updateable<sys_user>(user).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "更改成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "更改失败~" };
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UserAdd(AddUser user)
        {
            var isusername = await Db.Queryable<sys_user>().AnyAsync(c => c.username == user.username);
            if (isusername)
            {
                return new ResponseModel { code = 0, result = "已存在该用户~" };
            }
            user.password = ToolBase.EncryptByMd5(user.password);
            var query = await Db.Insertable(user).ExecuteCommandAsync();
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
        /// 分页获取角色
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public async Task<PageRequestModel> GetPageRole(int pageIndex, int pageSize, string wheres)
        {
            int total = await Db.Ado.GetIntAsync("SELECT count(id) FROM sys_role ");
            var query = await Db.Ado.SqlQueryAsync<sys_role>($"SELECT * FROM sys_role {wheres} limit {(pageIndex - 1) * pageSize},{pageSize}");
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
        /// 角色删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> rolesdel(int[] id)
        {

            if (Array.IndexOf(id, 1) != -1)
            {
                return new ResponseModel { code = 0, result = "不可以删除超级管理员~" };
            }
            else
            {
                var query = await Db.Deleteable<sys_role>().In(id).ExecuteCommandAsync();
                if (query >= 1)
                {
                    return new ResponseModel { code = 200, result = "删除成功~" };
                }
                else
                {
                    return new ResponseModel { code = 0, result = "删除失败~" };
                }
            }
        }
        /// <summary>
        /// 获取一个角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> GetOneRole(int id)
        {
            if (id == 1)
            {
                return new ResponseModel { code = 0, result = "禁止更改超级管理员信息" };
            }
            else
            {
                var query = await Db.Queryable<sys_role>().Where(c => c.id == id).SingleAsync();
                return new ResponseModel { code = 200, result = "获取成功", data = query };
            }
        }
        /// <summary>
        /// 角色编辑
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<ResponseModel> rolesedit(RolesEdit roles)
        {
            if (roles.id != 1)
            {
                var query = await Db.Updateable(roles).ExecuteCommandAsync();
                if (query >= 1)
                {
                    return new ResponseModel { code = 200, result = "修改成功~" };
                }
                else
                {
                    return new ResponseModel { code = 0, result = "修改失败~" };
                }
            }
            else
            {
                return new ResponseModel { code = 0, result = "禁止更改超级管理员信息" };
            }
        }
        /// <summary>
        /// 角色添加
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> rolesadd(RolesEdit roles)
        {
            var query = await Db.Insertable(roles).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "添加成功~" };
            }
            else
            {
                return new ResponseModel { code = 0, result = "添加失败~" };
            }
        }
    }
}
