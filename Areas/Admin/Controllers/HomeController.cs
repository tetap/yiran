using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Service;
using yiran.Areas.Admin.Common;
using yiran.Areas.Admin.Models.Entity;
using yiran.Areas.Admin.Models.Request;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly sys_loginService loginService;

        public HomeController(sys_loginService loginService)
        {
            this.loginService = loginService;
        }
        [Sign]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.Get<sys_user>("yr_user") != default)
            {
                var login = new LoginRequest { username = HttpContext.Session.Get<sys_user>("yr_user").username, password = HttpContext.Session.Get<sys_user>("yr_user").password };
                var res = await loginService.Login(login, HttpContext);
                if (res.code == 200)
                {
                    ViewData["name"] = res.data.name;
                    ViewData["menu"] = res.data.sys_menu;
                }
                else
                {
                    HttpContext.Session.Clear();
                    throw new Exception("用户状态有误");
                }
            }
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [Sign]
        public IActionResult Repwd() {
            return View();
        }
        [SignApi]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<JsonResult> Repwd(UpdatePwd updatepwd) {
            var res = await loginService.Repwd(updatepwd, HttpContext);
            return Json(res);
        }
    }
}