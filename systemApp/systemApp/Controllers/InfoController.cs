using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace systemApp.Controllers
{
    public class InfoController : Controller
    {
        // GET: InfoList
        public ActionResult Index(string IP)
        {
            ViewData["IP"] = Server.UrlEncode(IP);
            return View("InfoList");
        }
    }
}