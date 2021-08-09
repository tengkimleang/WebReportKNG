using B1Site.Connection;
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
            services.AddScoped<ISaleDailyReportService, SaleDailyReportService>();
            services.AddScoped<IARAgedOutstandingService, ARAgedOutstandingService>();
            services.AddScoped<IDailyCashCollectionService, DailyCashCollectionService>();
            services.AddScoped<IApcashoutService, ApcasoutreportService>();
            services.AddScoped<IPSIReportService, PSIReportService>();
            services.AddScoped<ISaleReportbySerialService, SaleReportBySerailService>();
            services.AddScoped<IInventoryReportBySerialService, InventoryReportBySerialService>();
<<<<<<< HEAD
            services.AddScoped<IInventoryReportService, InventoryReportService>();
=======
            services.AddScoped<IPurchaseReportService, PurchaseReportService>();
            services.AddScoped<IHomeService, HomeService>();
>>>>>>> e7061912e1fe41c4195b6b4c3440bad9e9702b71
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
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
            #region Init Constructor Of Connection String
            _ = new ConnectionString(Configuration.GetSection("ConnectionStringsDbWeb").Value.ToString()
                               , Configuration.GetSection("ConnectionStringsDbSAP").Value.ToString()
                               , Configuration.GetSection("ConnectionStrings:DataSource").Value.ToString()
                               , Configuration.GetSection("ConnectionStrings:UserName").Value.ToString()
                               , Configuration.GetSection("ConnectionStrings:Password").Value.ToString());
            #endregion
        }
    }
}
