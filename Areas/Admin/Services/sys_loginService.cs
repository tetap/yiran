using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Entity;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Areas.Admin.Common;
using yiran.Tools;
using Microsoft.AspNetCore.Http;

namespace yiran.Areas.Admin.Service
{
    public class sys_loginService : DataContext
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Login(LoginRequest login, HttpContext context)
        {
            var query = await Db.Queryable<sys_user>().Where(c => c.username == login.username).SingleAsync();
            if (query == null)
            {
                return new ResponseModel { code = 0, result = "用户不存在！", data = "" };
            }
            if (login.password != query.password)
            {
                return new ResponseModel { code = 0, result = "密码错误！", data = "" };
            }
            if (query.Static != 1)
            {
                return new ResponseModel { code = 0, result = "用户状态异常，已被禁用请联系管理员！", data = "" };
            }
            var role = await Db.Queryable<sys_role>().In(query.role_id.Split(",")).ToListAsync();
            string menu_id = "";
            foreach (var m in role)
            {
                if (!string.IsNullOrEmpty(m.menu_id))
                {
                    menu_id += "," + m.menu_id;
                }
            }
            var menu_idArray = menu_id.Split(",", StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
            var menu = new List<sys_menu>();
            if (!role.Where(c => c.entity == "SuperAdmin").Any())
            {
                menu = await Db.Queryable<sys_menu>().Where(c => c.Static == 1).In(menu_idArray).OrderBy(c => c.sork, SqlSugar.OrderByType.Desc).ToListAsync();
            }
            else
            {
                menu = await Db.Queryable<sys_menu>().Where(c => c.Static == 1).OrderBy(c => c.sork, SqlSugar.OrderByType.Desc).ToListAsync();
            }
            query.role_id = string.Join(",", menu_idArray);
            query.sys_menu = menu;
            query.sys_role = role;
            context.Session.Set<sys_user>("yr_user", query);
            return new ResponseModel { code = 200, result = "登录成功~", data = query };
        }

        public async Task<ResponseModel> Repwd(UpdatePwd updatepwd, HttpContext context)
        {
            var id = context.Session.Get<sys_user>("yr_user").id;
            var user = await Db.Queryable<sys_user>().Where(c => c.id == id).SingleAsync();
            if (user.password == ToolBase.EncryptByMd5(updatepwd.oldpwd)) {
                var query = await Db.Updateable<sys_user>().Where(c => c.id == id).UpdateColumns(c => new sys_user { password = ToolBase.EncryptByMd5(updatepwd.newpwd) }).ExecuteCommandAsync();
                if (query >= 1)
                {
                    return new ResponseModel { code = 200, result = "修改成功~" };
                }
                else
                {
                    return new ResponseModel { code = 0, result = "修改失败~" };
                }
            }
            else {
                return new ResponseModel { code = 0, result = "旧密码有误~" };
            }
        }
    }
}
