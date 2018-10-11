using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheetahShoes.Core;
using CheetahShoes.Core.ApplicationService;
using CheetahShoes.Core.DomainService;
using CheetahShoes.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CheetahShoes.RestAPI
{
    public class Startup
    {
        private IConfiguration _cfg { get; }
        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            //?????
            this._env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _cfg = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add CORS to our Rest API.
            // This ensures that we only allow specific servers to use the API.
            services.AddCors();

            // If developing tell Context that we use local SQLite
            if (_env.IsDevelopment()) 
            {
                services.AddDbContext<CShoesContext>(
                    opt => opt.UseSqlite("Data Source=CheetahShoes.db"));
            }
            // Else if in production, tell Context we use an SQL server.
            else if (_env.IsProduction())
            {
                services.AddDbContext<CShoesContext>(
                    opt => opt.UseSqlServer(_cfg.GetConnectionString("DefaultConnection")));
            }

            //Dependency injection
            services.AddScoped<IShoeRepository, ShoeRepository>(); 
            services.AddScoped<IShoeService, ShoeService>();

            // Ensures that we don't loop data. E.g. "Shoe has a size, which has a shoe, which has a size, which has a shoe..." (CURRENTLY NOT RELEVANT)
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader()
                        .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // If in Development, Get Context from scope, and seed the SQLite DB. 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope()) // When done, dispose. Get accesspoint to stuff in the services
                {
                    var ctx = scope.ServiceProvider.GetService<CShoesContext>(); 
                    DBSeed.SeedDB(ctx);
                }
            }
            // Else, get Context and ensure that the database actually exists, or create it.
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<CShoesContext>(); // 
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            // Setup CORS to only allow requests from featured URL's. Allow any method/header, cause lazy
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }
    }
}
