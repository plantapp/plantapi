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
using Unsch.Web.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Unsch.Web.Api.Helper;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Unsch.Web.Api
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
            var connection = Configuration["Production:PlantaConnection"];
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connection));
            services.AddMvc(config => { config.Filters.Add(typeof(CustomExceptionFilter)); });
            services.AddScoped<IPlantaRepository, PlantaRepository>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();      
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }           
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
