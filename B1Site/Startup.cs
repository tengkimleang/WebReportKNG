using B1Site.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site
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
            #region Language
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCulture = new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("km"),
                    new CultureInfo("zh-TW")
                };
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCulture;
                options.SupportedUICultures = supportedCulture;

            });
            #endregion
            #region Add Compilation With Out Restart Debug
            services.AddRazorPages().AddRazorRuntimeCompilation();
            #endregion
            #region Init
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            #endregion
            #region Add Session
            services.AddSession(option =>
                option.IdleTimeout = TimeSpan.FromMinutes(30)
            );
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            #region Add Scope
            services.AddScoped<ISaleDailyReportService, SaleDailyReportService>();
<<<<<<< HEAD
            services.AddScoped<ISaleDailyReportService, SaleDailyReportService>();
            services.AddScoped<IARAgedOutstandingService, DailyCashCollectionService>();
            services.AddScoped<IARAgedOutstandingService, ARAgedOutstandingService>();
=======
            services.AddScoped<IDailyCashCollectionService, DailyCashCollectionService>();
            services.AddScoped<IApcashoutService, ApcasoutreportService>();
            services.AddScoped<IPSIReportService, PSIReportService>();
            services.AddScoped<ISaleReportbySerialService, SaleReportBySerailService>();
            services.AddScoped<IInventoryReportBySerialService, InventoryReportBySerialService>();
            services.AddScoped<IPurchaseReportService, PurchaseReportService>();
<<<<<<< HEAD
            services.AddScoped<IHomeService, HomeService>();
>>>>>>> 58a55fb7e8c8d589bd0ecb1632900c7926e284f9
=======
>>>>>>> parent of 58a55fb (Add Login)
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            #region Language
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            #endregion
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            Connection.ConnectionString.constr = Configuration.GetSection("ConnectionStrings").Value.ToString();
            Connection.ConnectionString.constrWeb = Configuration.GetSection("ConnectionStringsDbWeb").Value.ToString();
        }
    }
}
