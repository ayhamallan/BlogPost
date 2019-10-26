using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataModel.DataModels;
using Blog.DomainModel.IServices;
using Blog.DomainModel.Services;
using Blog.Repository.GenericRepository;
using Blog.Repository.UnitOfWork;
using Blog.Web.SignalRHub;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Blog.Web
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
            services.AddAuthentication("Bearer")
          .AddIdentityServerAuthentication(options =>
          {
              options.Authority = Configuration.GetValue<string>("Authority");
              options.RequireHttpsMetadata = false;
              options.ApiName = "resourceapi";
          });
            var connection = Configuration.GetConnectionString("Default");
            services.AddDbContext<BlogDbContext>
                (options => options.UseSqlServer(connection));
            services.AddTransient<UserManager<dynamic>>();
            services.AddTransient<BlogDbContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Blog Api ", Version = "0.1" });
            });
            services.AddSignalR();
            services
           .AddMvcCore()
           .AddAuthorization()
           .AddJsonFormatters();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, BlogDbContext>();
            services.AddTransient<IBlogPostServie, BlogPostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseAuthentication();
            app.UseSignalR(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/NotificationHub");
            });
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
