using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace systemApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Connections()
        {
            ViewBag.Message = "List of the available connections";


            return View();
        }

        //[Route("infos/{userName}")]
        public ActionResult Info(string userName)
        {
            ViewData["Name"] = Server.UrlEncode(userName);
            return View();
        }
    }
}