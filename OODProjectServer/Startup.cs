using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Okta.AspNetCore;

using Microsoft.EntityFrameworkCore;
using OODProjectServer.Entities;

namespace OODProjectServer
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddJsonFile("oktasettings.json", false, true)
                .AddJsonFile("sqlsettings.json", false, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<CoffeeContext>(opt =>
            //                                  opt.UseInMemoryDatabase("CoffeeList"));

                                              opt.UseSqlServer("Server = tcp:oodproject.database.windows.net, 1433; " +
                                              	"Initial Catalog = Coffee; " +
                                              	"Persist Security Info = False; " +
                                              	$"User ID = {Configuration["SqlSettings:your_username"]}; " +
                                              	$"Password = {Configuration["SqlSettings:your_password"]}; " +
                                                "MultipleActiveResultSets = False; " +
                                              	"Encrypt = True; " +
                                              	"TrustServerCertificate = False; " +
                                              	"Connection Timeout = 30;"));
                                              	                                              
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            }).AddOktaWebApi(new OktaWebApiOptions(){
                OktaDomain = Configuration["OktaSettings:OktaDomain"],
                ClientId = Configuration["OktaSettings:ClientId"]
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                    app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors(builder =>
                builder.WithOrigins("http://54.183.81.119:4200", "http://localhost:4200", "https://54.183.81.119:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            app.UseMvc();
        }
    }
}
