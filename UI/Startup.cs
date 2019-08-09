using Applicationcore.Entities;
using Applicationcore.Services.IService;
using Applicationcore.Services.Service;
using FluentValidation.AspNetCore;
using Infra.Data;
using Infra.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<ContextDB>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //acrescentado o FluentiValidation
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(
                 fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            //acrescentado o FluentiValidation

            //pwa
            //pwa
             services.AddProgressiveWebApp();
            //pwa

            services.AddTransient(typeof(IRepository<Adress>), typeof(Repository<Adress>));
            services.AddTransient(typeof(IServices<Adress>), typeof(ServiceAdress));
            services.AddTransient(typeof(IRepository<Client>), typeof(Repository<Client>));
            services.AddTransient(typeof(IServices<Client>), typeof(ServiceClient));
            services.AddTransient(typeof(IRepository<Phone>), typeof(Repository<Phone>));
            services.AddTransient(typeof(IServices<Phone>), typeof(ServicePhone));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
