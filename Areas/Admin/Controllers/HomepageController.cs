using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Common;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Areas.Admin.Service;
using yiran.Models.Entity;
using yiran.Services;
using yiran.Tools;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomepageController : Controller
    {
        private readonly sys_HomePageService _syshomeService;
        private readonly sys_RoleService roleService;
        private readonly HomeService _homeService;
        private readonly IWebHostEnvironment _env;
        public HomepageController(IWebHostEnvironment env, sys_HomePageService syshomeService, sys_RoleService roleService, HomeService homeService)
        {
            _env = env;
            _syshomeService = syshomeService;
            this.roleService = roleService;
            this._homeService = homeService;
        }
        /// <summary>
        /// banner列表
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/banner")]
        public async Task<IActionResult> Banner()
        {
            var pagemenu = await roleService.getPageMenu(HttpContext);
            if (pagemenu != null)
            {
                ViewData["menu"] = pagemenu;
            }
            var res = await _syshomeService.GetAllBanner();
            return View(res);
        }
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SignApi]
        public async Task<JsonResult> UploadFile(IFormFile file) {
            if (file != null)
            {
                var webRootPath = _env.WebRootPath;
                string relativeDirPath = "/upload";
                string absolutePath = webRootPath + relativeDirPath;
                string[] fileTypes = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(file.FileName);
                if (fileTypes.Contains(extension.ToLower()))
                {
                    if (file.Length / 1024 <= long.Parse(ToolBase.GetSectionValue("UploadMax")))
                    {
                        if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                        string fileName = DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString("N") + extension;
                        var filePath = absolutePath + "/" + fileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        string image = "/upload/" + fileName;
                        return Json(new ResponseModel { code = 200, result = "上传成功", data = image });
                    }
                    else
                    {
                        return Json(new ResponseModel { code = 0, result = "文件大小超出" + (int.Parse(ToolBase.GetSectionValue("UploadMax")) / 1024).ToString() + "Mb" });
                    }
                }
                else
                {
                    return Json(new ResponseModel { code = 0, result = "文件格式有误" });
                }
            }
            return Json(new ResponseModel { code = 0, result = "上传失败了" });
        }
        /// <summary>
        /// 添加banner
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/addbanner")]
        public IActionResult Addbanner() {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/addbanner", true)]
        public async Task<JsonResult> AddBanner(AddBanner addBanner) {
            var res = await _syshomeService.AddBanner(addBanner);
            return Json(res);
        }
        /// <summary>
        /// 编辑banner
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/editbanner")]
        public async Task<IActionResult> Editbanner(int id)
        {
            var res = await _syshomeService.GetBannerByid(id);
            return View(res);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/editbanner", true)]
        public async Task<JsonResult> Editbanner(AddBanner addBanner)
        {
            var res = await _syshomeService.Editbanner(addBanner);
            return Json(res);
        }
        /// <summary>
        /// 删除banner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResult> Delbanner(int[] id) {
            var res = await _syshomeService.Delbanner(id);
            return Json(res);
        }
        /// <summary>
        /// 更改banner状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/editbanner")]
        public async Task<JsonResult> Staticbanner(int id, int Static) {
            var res = await _syshomeService.Staticbanner(id,Static);
            return Json(res);
        }
        /// <summary>
        /// 更改banner排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/editbanner")]
        public async Task<JsonResult> SetSork(int id, int sork)
        {
            var res = await _syshomeService.SetSork(id, sork);
            return Json(res);
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/about")]
        public async Task<IActionResult> About()
        {
            var res = await _syshomeService.GetAbout();
            return View(res);
        }
        /// <summary>
        /// 关于我们编辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/editabout",true)]
        public async Task<JsonResult> EditAbout(EditAbout editAbout)
        {
            var res = await _syshomeService.EditAbout(editAbout);
            return Json(res);
        }
        /// <summary>
        /// 技术支持
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="keywork"></param>
        /// <returns></returns>
        [Role("/admin/homepage/support")]
        public async Task<IActionResult> Support(int pageIndex = 1, int pageSize = 6, string start = "", string end = "", string keywork = "")
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
                    wheres += $" where (title like '%{keywork}%')";
                }
                else
                {
                    wheres += $" and (title like '%{keywork}%')";
                }
            }
            var res = await _syshomeService.GetSupportPage(pageIndex, pageSize, wheres);
            ViewData["page"] = ToPageString(res.total, pageSize, pageIndex, "/admin/homepage/support?start=" + start + "&end=" + end + "&keywork=" + keywork);
            ViewData["support"] = await _homeService.GetSupport();
            return View(res);
        }
        /// <summary>
        /// 添加技术支持页面
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/addsupport")]
        public IActionResult Addsupport()
        {
            return View();
        }
        /// <summary>
        /// 添加技术支持
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/addsupport", true)]
        public async Task<JsonResult> Addsupport(Addsupport_list addsupport)
        {
            var res = await _syshomeService.Addsupport(addsupport);
            return Json(res);
        }
        /// <summary>
        /// 编辑技术支持页面
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/editsupport")]
        public async Task<IActionResult> Editsupport(int id)
        {
            var res = await _syshomeService.GetSupporyByid(id);
            return View(res);
        }
        /// <summary>
        /// 编辑技术支持
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/editsupport", true)]
        public async Task<JsonResult> Editsupport(Addsupport_list addsupport)
        {
            var res = await _syshomeService.Editsupport(addsupport);
            return Json(res);
        }
        /// <summary>
        /// 删除技术支持
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/homepage/delsupport")]
        public async Task<JsonResult> Delsupport(int[] id)
        {
            var res = await _syshomeService.Delsupport(id);
            return Json(res);
        }
        /// <summary>
        /// 更改技术支持排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/homepage/editsupport")]
        public async Task<JsonResult> Sorksupport(int id, int sork)
        {
            var res = await _syshomeService.Sorksupport(id, sork);
            return Json(res);
        }
        /// <summary>
        /// 更改技术支持状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/homepage/editsupport")]
        public async Task<JsonResult> StaticSupport(int id, int Static)
        {
            var res = await _syshomeService.StaticSupport(id, Static);
            return Json(res);
        }
        /// <summary>
        /// 更改技术支持标题
        /// </summary>
        /// <param name="support"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/homepage/editsupport")]
        public async Task<JsonResult> UpdateSupport(yr_support suppory)
        {
            var res = await _syshomeService.UpdateSupport(suppory);
            return Json(res);
        }
        /// <summary>
        /// 应用领域
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="keywork"></param>
        /// <returns></returns>
        [Role("/admin/homepage/field")]
        public async Task<IActionResult> Field(int pageIndex = 1, int pageSize = 4, string start = "", string end = "", string keywork = "")
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
                    wheres += $" where (title like '%{keywork}%')";
                }
                else
                {
                    wheres += $" and (title like '%{keywork}%')";
                }
            }
            var res = await _syshomeService.GetFieldPage(pageIndex, pageSize, wheres);
            ViewData["page"] = ToPageString(res.total, pageSize, pageIndex, "/admin/homepage/field?start=" + start + "&end=" + end + "&keywork=" + keywork);
            ViewData["field"] = await _homeService.GetField();
            return View(res);
        }
        /// <summary>
        /// 应用领域更新内容
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("//admin/homepage/editfield")]
        public async Task<JsonResult> UpdateField(yr_field field) {
            var res = await _syshomeService.UpdateField(field);
            return Json(res);
        }
        /// <summary>
        /// 更改应用领域排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/homepage/editfield")]
        public async Task<JsonResult> Sorkfield(int id, int sork)
        {
            var res = await _syshomeService.Sorkfield(id, sork);
            return Json(res);
        }
        /// <summary>
        /// 更改应用领域状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/homepage/editfield")]
        public async Task<JsonResult> Staticfield(int id, int Static)
        {
            var res = await _syshomeService.Staticfield(id, Static);
            return Json(res);
        }
        /// <summary>
        /// 删除应用领域
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        [RoleApi("/admin/homepage/delfield")]
        public async Task<JsonResult> Delfield(int[] id) {
            var res = await _syshomeService.Delfield(id);
            return Json(res);
        }
        /// <summary>
        /// 添加应用领域
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/addfield")]
        public IActionResult Addfield() {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/addfield",true)]
        public async Task<JsonResult> Addfield(AddField field)
        {
            var res = await _syshomeService.Addfield(field);
            return Json(res);
        }
        /// <summary>
        /// 编辑应用领域
        /// </summary>
        /// <returns></returns>
        [Role("/admin/homepage/editfield")]
        public async Task<IActionResult> Editfield(int id)
        {
            var res = await _syshomeService.GetFieldById(id);
            return View(res);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/homepage/editfield", true)]
        public async Task<JsonResult> Editfield(AddField field)
        {
            var res = await _syshomeService.Editfield(field);
            return Json(res);
        }
    }
}