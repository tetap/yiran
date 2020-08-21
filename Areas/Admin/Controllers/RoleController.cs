using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Service;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly sys_RoleService roleService;

        public RoleController(sys_RoleService roleService)
        {
            this.roleService = roleService;
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [Role("/admin/role/index")]
        public async Task<IActionResult> Index()
        {
            var pagemenu = await roleService.getPageMenu(HttpContext);
            if (pagemenu != null)
            {
                ViewData["menu"] = pagemenu;
            }

            var res = await roleService.GetAllMenu();
            return View(res);
        }
        /// <summary>
        /// 菜单删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/role/delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> Delete(int[] id)
        {
            var res = await roleService.RemoveCategrory(id);
            return Json(res);
        }
        /// <summary>
        /// 菜单列表 添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Role("/admin/role/add")]
        public IActionResult Add(int id)
        {
            ViewData["parent_id"] = id;
            return View();
        }
        /// <summary>
        /// 菜单添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/role/add",true)]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> Add(Addcategory category)
        {
            var res = await roleService.AddCategrory(category);
            return Json(res);
        }
        /// <summary>
        /// 菜单列表 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Role("/admin/role/edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var res = await roleService.GetOntCategrory(id);
            return View(res);
        }
        /// <summary>
        /// 权限分类
        /// </summary>
        /// <returns></returns>
        [Role("/admin/role/category")]
        public async Task<IActionResult> category()
        {
            var res = await roleService.GetCategory();
            var pagemenu = await roleService.getPageMenu(HttpContext);
            if (pagemenu != null)
            {
                ViewData["menu"] = pagemenu;
            }
            return View(res);
        }
        /// <summary>
        /// 添加权限分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/role/addcategrory", true)]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> AddCategrory(Addcategory category)
        {
            var res = await roleService.AddCategrory(category);
            return Json(res);
        }
        /// <summary>
        /// 删除权限分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/role/removecategrory")]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> RemoveCategrory(int[] id)
        {
            var res = await roleService.RemoveCategrory(id);
            return Json(res);
        }
        /// <summary>
        /// 更改权限分类排序
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/role/setsork")]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> Setsork(string id, string sork)
        {
            var res = await roleService.RemoveCategrory(id, sork);
            return Json(res);
        }
        /// <summary>
        /// 获取单个分类并返回到视图 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Role("/admin/role/editcategrory")]
        public async Task<IActionResult> EditCategrory(string id)
        {
            var res = await roleService.GetOntCategrory(id);
            return View(res);
        }
        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/role/editcategrory", true)]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> EditCategrory(Addcategory category)
        {
            var res = await roleService.EditCategrory(category);
            return Json(res);
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        [Role("/admin/role/UserIndex")]
        public async Task<IActionResult> UserIndex(int pageIndex = 1, int pageSize = 15, string start = "", string end = "", string keywork = "")
        {
            var pagemenu = await roleService.getPageMenu(HttpContext);
            if (pagemenu != null)
            {
                ViewData["menu"] = pagemenu;
            }
            string wheres = "";
            if (!string.IsNullOrEmpty(start))
            {
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (addtime >= '{Convert.ToDateTime(start).ToString("yyyy/MM/dd")}')";
                }
                else
                {
                    wheres += $" and (addtime >= '{Convert.ToDateTime(start).ToString("yyyy/MM/dd")}')";
                }
            }
            if (!string.IsNullOrEmpty(end))
            {
                var t2 = Convert.ToDateTime(end + " 23:59:59");
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (addtime <= '{Convert.ToDateTime(t2).ToString("yyyy/MM/dd HH:mm:ss")}')";
                }
                else
                {
                    wheres += $" and (addtime <= '{Convert.ToDateTime(t2).ToString("yyyy/MM/dd HH:mm:ss")}')";
                }
            }
            if (!string.IsNullOrEmpty(keywork))
            {
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (name like '%{keywork}%')";
                }
                else
                {
                    wheres += $" and (name like '%{keywork}%')";
                }
            }
            var res = await roleService.GetPageUser(pageIndex, pageSize, wheres);
            ViewData["page"] = ToPageString(res.total, pageSize, pageIndex, "/admin/role/UserIndex?start=" + start + "&end=" + end + "&keywork=" + keywork);
            return View(res);
        }
        
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [RoleApi("/admin/role/userdel")]
        [HttpPost]
        public async Task<JsonResult> userdel(int[] id)
        {
            var res = await roleService.UserDel(id);
            return Json(res);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Role("/admin/role/Useredit")]
        public async Task<IActionResult> Useredit(int id)
        {
            var res = await roleService.GetOneUser(id);
            ViewData["role"] = await roleService.GetAllRole();
            return View(res);
        }
        [HttpPost]
        [RoleApi("/admin/role/Useredit", true)]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> Useredit(EditUser user)
        {
            var res = await roleService.Useredit(user);
            return Json(res);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        [Role("/admin/role/Useradd")]
        public async Task<IActionResult> Useradd()
        {
            ViewData["role"] = await roleService.GetAllRole();
            return View();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        [HttpPost]
        [RoleApi("/admin/role/Useradd", true)]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> Useradd(AddUser user)
        {
            var res = await roleService.UserAdd(user);
            return Json(res);
        }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        [Role("/admin/role/roleindex")]
        public async Task<IActionResult> roleindex(int pageIndex = 1, int pageSize = 15, string start = "", string end = "", string keywork = "")
        {
            string wheres = "";
            if (!string.IsNullOrEmpty(start))
            {
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (addtime >= '{Convert.ToDateTime(start).ToString("yyyy/MM/dd")}')";
                }
                else
                {
                    wheres += $" and (addtime >= '{Convert.ToDateTime(start).ToString("yyyy/MM/dd")}')";
                }
            }
            if (!string.IsNullOrEmpty(end))
            {
                var t2 = Convert.ToDateTime(end + " 23:59:59");
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (addtime <= '{Convert.ToDateTime(t2).ToString("yyyy/MM/dd HH:mm:ss")}')";
                }
                else
                {
                    wheres += $" and (addtime <= '{Convert.ToDateTime(t2).ToString("yyyy/MM/dd HH:mm:ss")}')";
                }
            }
            if (!string.IsNullOrEmpty(keywork))
            {
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (name like '%{keywork}%')";
                }
                else
                {
                    wheres += $" and (name like '%{keywork}%')";
                }
            }
            var pagemenu = await roleService.getPageMenu(HttpContext);
            if (pagemenu != null)
            {
                ViewData["menu"] = pagemenu;
            }
            var res = await roleService.GetPageRole(pageIndex, pageSize, wheres);
            ViewData["page"] = ToPageString(res.total, pageSize, pageIndex, "/admin/role/roleindex?start=" + start + "&end=" + end + "&keywork=" + keywork);
            return View(res);
        }
        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [RoleApi("/admin/role/rolesdel")]
        [HttpPost]
        public async Task<JsonResult> rolesdel(int[] id)
        {
            var res = await roleService.rolesdel(id);
            return Json(res);
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Role("/admin/role/rolesedit")]
        public async Task<IActionResult> rolesedit(int id)
        {
            var res = await roleService.GetOneRole(id);
            ViewData["menu"] = await roleService.GetAllMenu();
            return View(res);
        }
        [RoleApi("/admin/role/rolesedit", true)]
        [HttpPost]
        public async Task<JsonResult> rolesedit(RolesEdit roles)
        {
            var res = await roleService.rolesedit(roles);
            return Json(res);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [Role("/admin/role/rolesadd")]
        public async Task<IActionResult> rolesadd()
        {
            ViewData["menu"] = await roleService.GetAllMenu();
            return View();
        }
        [RoleApi("/admin/role/rolesadd", true)]
        [HttpPost]
        public async Task<JsonResult> rolesadd(RolesEdit roles)
        {
            var res = await roleService.rolesadd(roles);
            return Json(res);
        }
    }
}