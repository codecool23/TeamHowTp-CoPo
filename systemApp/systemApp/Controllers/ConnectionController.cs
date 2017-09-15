using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace systemApp.Controllers
{
    public class ConnectionController : Controller
    {
        // GET: Connection
        public ActionResult Index()
        {
            ViewBag.Message = "List of the available connections";
            return View("ConnectionList");
        }        
    }
}