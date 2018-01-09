using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Unsch.Web.Api.Helper;
using Unsch.Web.Api.Repository;

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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Plantas Procesor", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Api Procesador de Hojas de Plantas",
                    Description = "Es un aplicación para procesar las imagenes de las hojas de plantas y verificar si ya existe en en nuestra base de datos",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Unsch - Ingenieria de Sistemas", Email = "", Url = "http://www.unsch.edu.pe" },
                    License = new License { Name = "Apache License 2.0", Url = "http://www.apache.org/licenses" }
                });
            });
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
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plantas");
            });
            app.UseMvc();
        }
    }
}
