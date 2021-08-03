using B1Site.Connection;
using B1Site.Models;
using B1Site.Models.Home;
using B1Site.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
            //if (HttpContext.Session.GetString("UserID") != "")
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Home");
            //}
        }

        public async Task<IActionResult> GetLoginAdminAsync(string userName, string passWord, string databaseSAP)
        {
            Connection.ConnectionString.constr = "Data Source=.;Initial Catalog=" + databaseSAP + ";User Id=sa;Password=SA@webBI$rv01";
            return Ok(await homeService.GetLoginsAsync(userName, passWord));

        }
        public async Task<IActionResult> LoginAsync()
        {
            return View(new MasterViewHome
            {
                CompanyDatabases = await homeService.GetCompanyDatabasesAsync()
            }); ;
        }
        public IActionResult CultureManagment(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
