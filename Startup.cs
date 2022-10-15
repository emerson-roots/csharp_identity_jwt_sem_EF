using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using project.Identity;
using project.Models;
using project.Repository;
using project.Repository.Interfaces;
using project.Services;
using System;
using System.IO;
using System.Reflection;

namespace project
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
            services.AddControllers();

            // identity
            services.AddTransient<IUserStore<ApplicationUser>, UserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, RoleStore>();
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddDefaultTokenProviders();

            services.AddScoped<DbSession>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddTransient<IEmailSender, EmailSender>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "project", Version = "v1" });

                // Config para mostrar os comentarios<sumary> contidos nos endpoints da camada CONTROLLER no SWAGGER
                // requer ajustas no arquivo .csproj
                // https://www.treinaweb.com.br/blog/documentando-uma-asp-net-core-web-api-com-o-swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "project v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
