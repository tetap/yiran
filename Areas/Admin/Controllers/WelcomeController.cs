using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Common;
using yiran.Areas.Admin.Models.Entity;
using yiran.Tools;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Sign]
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["service"] = RuntimeInformation.OSDescription; //获取服务器信息
            ViewData["sdk"] = RuntimeInformation.FrameworkDescription; //获取sdk版本
            ViewData["UploadMax"] = (int.Parse(ToolBase.GetSectionValue("UploadMax")) / 1024).ToString();

            if (HttpContext.Session.Get<sys_user>("yr_user") != default)
            {
                ViewBag.UserName = HttpContext.Session.Get<sys_user>("yr_user").name;
            }

            return View();
        }
    }
}