using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace systemApp.Controllers
{
    public class ConnectionController : Controller
    {
        // GET: Connection
        public async Task<ActionResult> Index()
        {
            await ConnectionManager.GetAllUri();
            return View("ConnectionList");
        }        
    }
}