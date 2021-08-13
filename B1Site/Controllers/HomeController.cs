﻿using B1Site.Connection;
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
        #region Global Varraible
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        private readonly IHttpContextAccessor httpContextAccessor;
        #endregion
        #region Init Constructor of HomeController
        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            this.homeService = homeService;
            this.httpContextAccessor = httpContextAccessor;
        }
        #endregion
        #region View
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> LoginAsync()
        {
            return View(new MasterViewHome
            {
                CompanyDatabases = await homeService.GetCompanyDatabasesAsync()
            }); ;
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
        public IActionResult Administrator()
        {
            return View();
        }
        #endregion
        #region Ajax Post and Get
        public async Task<IActionResult> GetLoginAdminAsync(string userName, string passWord, string databaseSAP)
        {
            ConnectionString.constr = $"Data Source={ConnectionString.DataSource};Initial Catalog={databaseSAP};User Id={ConnectionString.UserName};Password={ConnectionString.PassWord}";
            return Ok(await homeService.GetLoginsAsync(userName, passWord));
        }
        #endregion
        #region Add Language
        public IActionResult CultureManagment(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,culture.ToString(),//CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            var cookieSetHeader = httpContextAccessor.HttpContext.Response.GetTypedHeaders().SetCookie;
            var setCookie = Uri.UnescapeDataString(cookieSetHeader.FirstOrDefault(x => x.Name == ".AspNetCore.Culture").Value.ToString());
            return LocalRedirect(returnUrl);
        }
        #endregion
        #region When Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
