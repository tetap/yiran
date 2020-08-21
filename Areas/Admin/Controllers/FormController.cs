using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Service;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FormController : Controller
    {
        private readonly sys_RoleService roleService;
        private readonly sys_FormService _formService;

        public FormController(sys_RoleService roleService,sys_FormService formService)
        {
            this.roleService = roleService;
            this._formService = formService;
        }
        //Static 0全部 1未查看 2已查看 3已回复
        [Role("/admin/form/index")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 12, string start = "", string end = "", string keywork = "",int Static = 0)
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
                    wheres += $" where (f.addtime >= '{Convert.ToDateTime(start).ToString("yyyy/MM/dd")}')";
                }
                else
                {
                    wheres += $" and (f.addtime >= '{Convert.ToDateTime(start).ToString("yyyy/MM/dd")}')";
                }
            }
            if (!string.IsNullOrEmpty(end))
            {
                var t2 = Convert.ToDateTime(end + " 23:59:59");
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (f.addtime <= '{Convert.ToDateTime(t2).ToString("yyyy/MM/dd HH:mm:ss")}')";
                }
                else
                {
                    wheres += $" and (f.addtime <= '{Convert.ToDateTime(t2).ToString("yyyy/MM/dd HH:mm:ss")}')";
                }
            }
            if (!string.IsNullOrEmpty(keywork))
            {
                if (string.IsNullOrEmpty(wheres))
                {
                    wheres += $" where (f.name like '%{keywork}%' or f.phone like '%{keywork}%' or f.email like '%{keywork}%')";
                }
                else
                {
                    wheres += $" and (f.name like '%{keywork}%' or f.phone like '%{keywork}%' or f.email like '%{keywork}%')";
                }
            }
            switch (Static)
            {
                case 1:
                    if (string.IsNullOrEmpty(wheres)) {
                        wheres += " where (f.Static = '0')";
                    }
                    else
                    {
                        wheres += " and (f.Static = '0')";
                    }
                    break;
                case 2:
                    if (string.IsNullOrEmpty(wheres))
                    {
                        wheres += " where (f.Static = '1')";
                    }
                    else
                    {
                        wheres += " and (f.Static = '1')";
                    }
                    break;
                case 3:
                    if (string.IsNullOrEmpty(wheres))
                    {
                        wheres += " where (f.Static = '2')";
                    }
                    else
                    {
                        wheres += " and (f.Static = '2')";
                    }
                    break;
                default:
                    break;
            }
            var res = await _formService.GetFormPage(pageIndex, pageSize, wheres);
            ViewData["page"] = ToPageString(res.total, pageSize, pageIndex, "/admin/form/Index?start=" + start + "&end=" + end + "&keywork=" + keywork + "&Static=" + Static.ToString());
            return View(res);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/form/delform")]
        public async Task<JsonResult> Delform(int[] id)
        {
            var res = await _formService.Delform(id);
            return Json(res);
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/form/eaitform")]
        public async Task<JsonResult> ShowForm(int[] id)
        {
            var res = await _formService.ShowForm(id, HttpContext);
            return Json(res);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Role("/admin/form/subform")]
        public async Task<IActionResult> Subform(int id)
        {
            var res = await _formService.GetFormByid(id);
            return View(res);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/form/subform",true)]
        public async Task<JsonResult> Subform(Subform form)
        {
            var res = await _formService.Subform(form,HttpContext);
            return Json(res);
        }
    }
}