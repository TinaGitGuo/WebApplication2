using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using System.IO;
 
using Serilog;

namespace WebApplication51
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var build = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json");
            a = build.Build();
            Log.Logger=new LoggerConfiguration().WriteTo.File( Path.Combine(env.ContentRootPath, "TextFile.txt"))
                .CreateLogger();
        }
        public IConfigurationRoot a { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(a.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(a.GetSection("Logging"));
            //loggerFactory.AddConsole(LogLevel.Error);
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            var log = loggerFactory.CreateLogger<Startup>();
            log.LogError("a error");
            log.LogInformation("a information");
            log.LogWarning("a warn");
            
             
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
