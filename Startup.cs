using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UEditorNetCore;
using yiran.Areas.Admin.Service;
using yiran.Log;
using yiran.Services;

namespace yiran
{
    public class Startup
    {
        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
            });
            services.AddUEditorService();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            services.AddControllersWithViews(c=> {
                c.Filters.Add(typeof(GlobalExceptionFilter));
            }).AddRazorRuntimeCompilation();

            //log4net
            repository = LogManager.CreateRepository("yiran");//需要获取日志的仓库名，也就是你的当然项目名
            //指定配置文件，如果这里你遇到问题，应该是使用了InProcess模式，请查看Blog.Core.csproj,并删之 
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));//配置文件

            services.AddSingleton<ILoggerHelper, LogHelper>();


            #region 网站前台服务
            services.AddScoped<HomeService>();
            #endregion

            #region 网站后台服务
            services.AddScoped<sys_loginService>(); //登录
            services.AddScoped<sys_RoleService>(); //权限
            services.AddScoped<sys_HomePageService>(); //首页管理
            services.AddScoped<sys_FormService>(); //表单管理
            services.AddScoped<sys_WebService>(); //网站相关设置
            services.AddScoped<sys_ProductService>(); //产品管理
            #endregion
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }
            app.UseResponseCompression();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
