using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Entity;
using yiran.Areas.Admin.Models.Response;

namespace yiran.Areas.Admin.Common
{
    public class CommonAttr
    {
        #region 验证是否登录但又不验证权限
        /// <summary>
        /// 需要登录的地方添加 [SignAttribute]
        /// </summary>
        public class SignAttribute : ActionFilterAttribute
        {

            /// <summary>
            /// 当动作执行中 
            /// </summary>
            /// https://blog.csdn.net/qq_43116611/article/details/100110705?utm_medium=distribute.pc_relevant.none-task-blog-BlogCommendFromMachineLearnPai2-1.nonecase&depth_1-utm_source=distribute.pc_relevant.none-task-blog-BlogCommendFromMachineLearnPai2-1.nonecase
            /// <param name="context"></param>
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                // 检查登陆 - 在SignIn中判断用户合法性，将登陆信息保存在Session中，在SignOut中移除登陆信息
                // 获取登陆信息 - 这里采用Session来保存登陆信息 -- Constants是字符串常量池
                var admin = context.HttpContext.Session.Get<sys_user>("yr_user");
                // 检查登陆信息
                if (admin == default)
                {
                    // 用户未登陆 - 跳转到登陆界面
                    context.Result = new RedirectResult("/Admin/Login");
                }
                base.OnActionExecuting(context);
            }
        }
        #endregion

        #region 验证是否登录但又不验证权限
        /// <summary>
        /// 需要登录的地方添加 [SignAttribute]
        /// </summary>
        public class SignApiAttribute : ActionFilterAttribute
        {
            /// <summary>
            /// 当动作执行中 
            /// </summary>
            /// https://blog.csdn.net/qq_43116611/article/details/100110705?utm_medium=distribute.pc_relevant.none-task-blog-BlogCommendFromMachineLearnPai2-1.nonecase&depth_1-utm_source=distribute.pc_relevant.none-task-blog-BlogCommendFromMachineLearnPai2-1.nonecase
            /// <param name="context"></param>
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                // 检查登陆 - 在SignIn中判断用户合法性，将登陆信息保存在Session中，在SignOut中移除登陆信息
                // 获取登陆信息 - 这里采用Session来保存登陆信息 -- Constants是字符串常量池
                var admin = context.HttpContext.Session.Get<sys_user>("yr_user");
                // 检查登陆信息
                if (admin == default)
                {
                    var res = new ResponseModel();
                    res.code = 0;
                    res.result = "请先登录！";
                    context.Result = new JsonResult(res);
                }
                base.OnActionExecuting(context);
            }
        }
        #endregion
        
        #region 检查视图是否有权限
        public class RoleAttribute : ActionFilterAttribute
        {
            private readonly string path;

            public RoleAttribute(string path)
            {
                this.path = path;
            }
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var role = context.HttpContext.Session.Get<sys_user>("yr_user");
                //var pageData = context.RouteData.Values.ToList();
                //var area = pageData.Where(c => c.Key == "area").First().Value;
                //var controller = pageData.Where(c => c.Key == "controller").First().Value;
                //var action = pageData.Where(c => c.Key == "action").First().Value;
                if (role != default)
                {
                    if (!role.sys_role.Where(c => c.entity == "SuperAdmin").Any())
                    {
                        var flag = role.sys_menu.Where(c => SqlFunc.ToLower(c.path) == SqlFunc.ToLower(path)).Any();
                        if (!flag)
                        {
                            context.Result = new RedirectResult("/Admin/Error");
                        }
                    }
                }
                else {
                    // 用户未登陆 - 跳转到登陆界面
                    context.Result = new RedirectResult("/Admin/Login");
                }
                base.OnActionExecuting(context);
            }
        }
        #endregion

        #region 检查Api是否有权限
        public class RoleApiAttribute : ActionFilterAttribute
        {
            private readonly string path;
            private readonly bool ismodel;

            public RoleApiAttribute(string path,bool ismodel = false)
            {
                this.path = path;
                this.ismodel = ismodel;
            }
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var role = context.HttpContext.Session.Get<sys_user>("yr_user");
                if (ismodel)
                {
                    if (!context.ModelState.IsValid)
                    {
                        foreach (var key in context.ModelState.Keys)
                        {
                            var modelstate = context.ModelState[key];
                            if (modelstate.Errors.Any())
                            {
                                var res = new ResponseModel();
                                res.code = 0;
                                res.result = modelstate.Errors.FirstOrDefault().ErrorMessage;
                                context.Result = new JsonResult(res);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (role != default)
                    {
                        if (!role.sys_role.Where(c => c.entity == "SuperAdmin").Any())
                        {
                            var flag = role.sys_menu.Where(c => SqlFunc.ToLower(c.path) == SqlFunc.ToLower(path)).Any();
                            if (!flag)
                            {
                                var res = new ResponseModel();
                                res.code = 0;
                                res.result = "暂无权限~";
                                context.Result = new JsonResult(res);
                            }
                        }
                    }
                    else
                    {
                        var res = new ResponseModel();
                        res.code = 0;
                        res.result = "请先登录！";
                        context.Result = new JsonResult(res);
                    }
                }
                base.OnActionExecuting(context);
            }
        }
        #endregion

        #region Model验证
        public class IsModelAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    foreach (var key in context.ModelState.Keys)
                    {
                        var modelstate = context.ModelState[key];
                        if (modelstate.Errors.Any())
                        {
                            var res = new ResponseModel();
                            res.code = 0;
                            res.result = modelstate.Errors.FirstOrDefault().ErrorMessage;
                            context.Result = new JsonResult(res);
                            break;
                        }
                    }
                }
                base.OnActionExecuting(context);
            }
            
        }
        #endregion

        /// <summary>
        /// 分页算法＜一＞共20页 首页 上一页  1  2  3  4  5  6  7  8  9  10  下一页  末页 
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="query_string">Url参数</param>
        /// <returns></returns>
        public static string ToPageString(int total, int pageSize, int pageIndex, string query_string)
        {

            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            StringBuilder pagestr = new StringBuilder();
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pagestr.AppendFormat("<div class=\"{0}\" >", "pagination");
            if (pageIndex < 1) { pageIndex = 1; }
            //计算总页数
            if (pageSize != 0)
            {
                allpage = (total / pageSize);
                allpage = ((total % pageSize) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = pageIndex + 1;
            pre = pageIndex - 1;
            startcount = (pageIndex + 5) > allpage ? allpage - 9 : pageIndex - 4;//中间页起始序号
                                                                                 //中间页终止序号
            endcount = pageIndex < 5 ? 10 : pageIndex + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内

            bool isFirst = pageIndex == 1;
            bool isLast = pageIndex == allpage;

            if (isFirst)
            {
                pagestr.Append("<span>首页</span> <span>上一页</span>");
            }
            else
            {
                pagestr.AppendFormat("<a href=\"{0}&pageIndex=1\">首页</a>  <a href=\"{0}&pageIndex={1}\">上一页</a>", query_string, pre);
            }
            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                bool isCurent = pageIndex == i;
                if (isCurent)
                {
                    pagestr.Append("  <a class=\"page_current\">" + i + "</a>");
                }
                else
                {
                    pagestr.Append("   <a href=\"" + query_string + "&pageIndex=" + i + "\">" + i + "</a>");
                }

            }
            if (isLast)
            {
                pagestr.Append("<span>下一页</span> <span>末页</span>");
            }
            else
            {
                pagestr.Append("  <a  href=\"" + query_string + "&pageIndex=" + next + "\">下一页</a>  <a href=\"" + query_string + "&pageIndex=" + allpage + "\">末页</a>");
            }
            pagestr.AppendFormat("</div>");
            return pagestr.ToString();
        }

    }

}
