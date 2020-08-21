using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Service;
using yiran.Services;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WebController : Controller
    {
        private readonly HomeService _homeService;
        private readonly sys_WebService _webService;

        public WebController(HomeService homeService, sys_WebService webService)
        {
            _homeService = homeService;
            _webService = webService;
        }
        [Role("/admin/web/index")]
        public async Task<IActionResult> Index()
        {
            var res = await _homeService.GetCommon();
            return View(res);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/web/index",true)]
        public async Task<JsonResult> Index(EditWeb web)
        {
            var res = await _webService.UpdateWeb(web);
            return Json(res);
        }
        [Role("/admin/web/setemail")]
        public async Task<IActionResult> Setemail()
        {
            var res = await _webService.GetSetemail();
            return View(res);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/web/setemail", true)]
        public async Task<JsonResult> Setemail(EditSetemail setemail)
        {
            var res = await _webService.UpdateSetemail(setemail);
            return Json(res);
        }
    }
}