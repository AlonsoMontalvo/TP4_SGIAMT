using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BD_SGIAMTvsgenerarcomprobante.Models;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore; //AGREGARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR

namespace BD_SGIAMTvsgenerarcomprobante
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

            var connection = @"Server=DESKTOP-2E54QI4\ALONSO_PC;Database=BD_SGIAMTvsgenerarcomprobante;Trusted_Connection=True;";
            services.AddDbContext<BD_SGIAMTvsgenerarcomprobanteContext>(options => options.UseSqlServer(connection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=TComprobantePagoes}/{action=Comprobante}/{id?}");
            });
            RotativaConfiguration.Setup(env);//AGREGARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        }
    }
}
