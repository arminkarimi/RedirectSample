using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RedirectSample.Models;

namespace RedirectSample.Controllers
{
    public class HomeController : Controller
    {
        private const string LanguageCookieName = "Language";
        public ActionResult Index()
        {
            HttpCookie languageCookie = GetCurrentLanguage();

            // add the language cookie value to view bag to display the current language.
            ViewBag.LanguageValue = languageCookie.Value;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SwitchLanguage()
        {
            string redirectUrl = string.Empty;
            redirectUrl = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : "~/";

            HttpCookie languageCookie = GetCurrentLanguage();

            languageCookie.Value = languageCookie.Value == Language.English.ToString("G")
                ? Language.French.ToString("G")
                : Language.English.ToString("G");

            HttpContext.Response.Cookies.Set(languageCookie);

            return Redirect(redirectUrl);
        }


        private HttpCookie GetCurrentLanguage()
        {
            HttpCookie currentLanguageCookie = Request.Cookies.Get(LanguageCookieName);
            if (currentLanguageCookie == null)
            {
                HttpCookie languageCookie = new HttpCookie(LanguageCookieName, Language.English.ToString("G"));
                HttpContext.Response.Cookies.Add(languageCookie);
                currentLanguageCookie = languageCookie;

            }

            return currentLanguageCookie;
        }
    }
}