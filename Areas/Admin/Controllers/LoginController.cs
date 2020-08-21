using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Common;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Areas.Admin.Service;
using yiran.Tools;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly sys_loginService loginService;

        public LoginController(sys_loginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [IsModel]
        public async Task<JsonResult> Index(LoginRequest login)
        {
            //登录接口限制
            if (!string.IsNullOrEmpty(HttpContext.Session.Get<string>("old_time")))
            {
                DateTime old_time = Convert.ToDateTime(HttpContext.Session.Get<string>("old_time"));
                DateTime new_time = DateTime.Now;
                TimeSpan ts = new_time - old_time;
                double time = ts.TotalMilliseconds;
                if (time <= 1000)
                {
                    return Json(new ResponseModel { code = 0, result = "稍后再试" }); ;
                }
            }
            HttpContext.Session.Set<string>("old_time", DateTime.Now.ToString());
            login.password = ToolBase.EncryptByMd5(login.password);
            var res = await loginService.Login(login, HttpContext);
            res.data = "";
            return Json(res);
        }
        public JsonResult Logout()
        {
            HttpContext.Session.Clear();
            return Json(new ResponseModel { code = 200, result = "退出登录~" });
        }
    }
}