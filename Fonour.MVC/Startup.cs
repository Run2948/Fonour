using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fonour.Application.AutoMapper;
using Fonour.Application.DepartmentApp;
using Fonour.Application.MenuApp;
using Fonour.Application.RoleApp;
using Fonour.Application.UserApp;
using Fonour.Domain.IRepositories;
using Fonour.EntityFrameworkCore;
using Fonour.EntityFrameworkCore.Repositories;
using Fonour.MVC.Common.Extensions;
using Fonour.MVC.Common.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fonour.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加数据上下文
            services.AddDbContext<FonourDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MsSql"));
                });

            //依赖注入
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleAppService, RoleAppService>();

            services.AddControllersWithViews(options => options.Filters.Add<GlobalExceptionFilter>()).AddNewtonsoftJson();

            //Session服务
            services.AddSession();

            //AutoMapper
            services.AddAutoMapper(typeof(FonourMappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //添加 log4net 日志
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                //开发环境异常处理
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //生产环境异常处理
                app.UseExceptionHandler("/Shared/Error");
            }

            //使用静态文件
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });

            app.UseRouting();

            //使用Session
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });

            //初始化数据
            await SeedData.Initialize(app.ApplicationServices);
        }
    }
}