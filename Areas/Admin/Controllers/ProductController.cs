using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Service;
using yiran.Models.Entity;
using yiran.Services;
using yiran.Tools;
using static yiran.Areas.Admin.Common.CommonAttr;

namespace yiran.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly sys_ProductService _productService;
        private readonly sys_RoleService roleService;
        private readonly HomeService homeService;

        public ProductController(sys_ProductService productService, sys_RoleService roleService, HomeService homeService)
        {
            _productService = productService;
            this.roleService = roleService;
            this.homeService = homeService;
        }
        /// <summary>
        /// 产品列表
        /// </summary>
        [Role("/admin/product/index")]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 6, string start = "", string end = "", string keywork = "")
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
            ViewData["info"] = await _productService.GetProuductInfo();
            var res = await _productService.GetProductPage(pageIndex, pageSize, wheres);
            ViewData["page"] = ToPageString(res.total, pageSize, pageIndex, "/Admin/Product/Index?start=" + start + "&end=" + end + "&keywork=" + keywork);
            ViewData["product"] = await homeService.GetProduct();
            return View(res);
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sork"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/product/editproduct")]
        public async Task<JsonResult> SetSork(int id, int sork)
        {
            var res = await _productService.SetSork(id, sork);
            return Json(res);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/product/delproduct")]
        public async Task<JsonResult> Delproduct(int[] id)
        {
            var res = await _productService.Delproduct(id);
            return Json(res);
        }
        /// <summary>
        /// 状态设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Static"></param>
        /// <returns></returns>
        [HttpPost]
        [RoleApi("/admin/product/editproduct")]
        public async Task<JsonResult> StaticProduct(int id, int Static)
        {
            var res = await _productService.StaticProduct(id, Static);
            return Json(res);
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <returns></returns>
        [Role("/admin/product/addproduct")]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/product/addproduct",true)]
        public async Task<JsonResult> AddProduct(AddProduct product)
        {
            var res = await _productService.AddProduct(product);
            return Json(res);
        }
        /// <summary>
        /// 编辑产品
        /// </summary>
        /// <returns></returns>
        [Role("/admin/product/editproduct")]
        public async Task<IActionResult> Editproduct(int id)
        {
            var res = await _productService.GetProductById(id);
            return View(res);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/product/editproduct", true)]
        public async Task<JsonResult> Editproduct(AddProduct product)
        {
            var res = await _productService.Editproduct(product);
            return Json(res);
        }
        /// <summary>
        /// 更新标题和内容
        /// </summary>
        /// <param name="prouduct"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [RoleApi("/admin/product/editproduct", true)]
        public async Task<JsonResult> Updata(yr_prouduct prouduct) {
            var res = await _productService.Updata(prouduct);
            return Json(res);
        }
    }
}