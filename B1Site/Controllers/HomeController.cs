using B1Site.Connection;
using B1Site.Models;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserID") != "")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult GetLoginAdmin(string userName, string passWord)
        {
            //EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
            ClsCRUD clscrud = new ClsCRUD();
            DataTable dt = new DataTable();
            //var claims = new List<Claim>();
            dt = clscrud.Getdata("SELECT * FROM Tb_User WHERE UserName=N'" + userName + "' AND Password=N'"+ passWord + "'");
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    HttpContext.Session.SetString("UserID", dr[0].ToString());
                    HttpContext.Session.SetString("UserName", dr[1].ToString());
                }
                return Ok(1);
            }
            else
            {
                return Ok("404");
            }

        }
        public IActionResult Login()
        {
            return View();
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
