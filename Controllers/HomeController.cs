using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yiran.Models.Entity;
using yiran.Models.Request;
using yiran.Services;
using yiran.ViewModels;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService homeService)
        {
            this._homeService = homeService;
        }
        public async Task<IActionResult> Index()
        {
            Task<yr_common> common = _homeService.GetCommon();
            Task<List<yr_banner>> banner = _homeService.GetAllBanner();
            Task<yr_about> about = _homeService.GetAbout();
            Task<yr_support> support = _homeService.GetSupport();
            Task<List<yr_support_list>> support_list = _homeService.GetSupportList();
            Task<yr_field> field = _homeService.GetField();
            Task<List<yr_field_li>> field_list = _homeService.GetFieldList();
            Task<yr_prouduct> product = _homeService.GetProduct();
            Task<List<yr_prouduct_list>> prouduct_list = _homeService.GetProductList();
            var ViewModel = new HomeViewModel {
                common = await common,
                banner = await banner,
                about = await about,
                support = await support,
                support_list = await support_list,
                field = await field,
                field_list = await field_list,
                product = await product,
                prouduct_list = await prouduct_list
            };
            ViewData["description"] = RemoveHTML(ViewModel.common.description);
            ViewData["keywords"] = RemoveHTML(ViewModel.common.keywords);
            ViewData["title"] = RemoveHTML(ViewModel.common.title);
            return View(ViewModel);
        }
        /// <summary>
        /// 产品详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id) {
            if (id == 0)
            {
                return View("Error");
            }
            else {
                
                if (string.IsNullOrEmpty(GetCookies("number")))
                {
                    SetCookies("number", id.ToString());
                    var numberadd = _homeService.AddNumber(id);
                }
                else {
                    var ids = GetCookies("number").Split(",");
                    if (Array.IndexOf(ids, id.ToString()) == -1)
                    {
                        SetCookies("number", GetCookies("number") + "," + id.ToString());
                        var numberadd = _homeService.AddNumber(id);
                    }
                }
                var product = await _homeService.GetOneProduct(id);
                var ViewModel = new DetailsViewModel
                {
                    common = await _homeService.GetCommon(),
                    product = product,
                    prevproduct = await _homeService.GetPrevProduct(id),
                    nextproduct = await _homeService.GetNextProduct(id)
                };
                ViewData["description"] = RemoveHTML(product.content);
                ViewData["keywords"] = RemoveHTML(product.content);
                return View(ViewModel);
            }
        }
        /// <summary>
        /// 留言
        /// </summary>
        /// <param name="addform"></param>
        /// <returns></returns>
        [HttpPost]
        [IsModel]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddJoin(addform addform) {
            var res = await _homeService.AddJoin(addform);
            return Json(res);
        }

        /// <summary>
        /// 错误页
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// 设置本地cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>  
        /// <param name="minutes">过期时长，单位：分钟</param>      
        protected void SetCookies(string key, string value, int minutes = 30)
        {
            HttpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes)
            });
        }
        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        protected void DeleteCookies(string key)
        {
            HttpContext.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        protected string GetCookies(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }
        protected string RemoveHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring)) { return ""; }
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            return Htmlstring;
        }
    }
}