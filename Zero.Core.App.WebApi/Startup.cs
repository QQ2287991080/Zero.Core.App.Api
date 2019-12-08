using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Zero.Core.App.WebApi.Interceptor;

namespace Zero.Core.App.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //配置Swagger
            services.AddSwaggerGen(i =>
            {
                i.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Zero的应用 WebApi接口文档",
                    Description = "WebApi",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Zero", Email = "2287991080@qq.com", Url = "http://www.baidu.com" }
                });
                i.OperationFilter<SwaggerFileUploadFilter>();//swagger上传文件配置

                //设置swagger备注
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Zero.Core.App.WebApi.xml");
                i.IncludeXmlComments(xmlPath);//文档中文提示
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();

            app.UseSwagger();
            // 使用swagger.json
            app.UseSwaggerUI(i =>
            {
                i.SwaggerEndpoint("/swagger/v1/swagger.json", "Zero API V1");
                i.ShowExtensions();
            });
        }
    }
}
