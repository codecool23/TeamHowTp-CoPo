using PcInfoModels;
using PcInfoSenderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfDiscoveryClient;

namespace systemApp.Controllers
{
    public class InfoController : Controller
    {
        // GET: InfoList
        public ActionResult Index(string IP)
        {
            IPcInfoSender channel = WcfClient.WcfClient_SetupChannel(IP);

            ViewData["runtimeInfos"] = channel.GetRuntimeInformation();
            ViewData["diskSpaceInfo"] = channel.GetDeviceInformation();
            ViewData["processes"] = channel.GetAllProcess();
            ViewData["services"] = channel.GetAllServices();
            return View("InfoList");
        }
    }
}