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
        public ActionResult Index(string IP)
        {
            try
            {
                IPcInfoSender channel = WcfClient.WcfClient_SetupChannel(IP);
                ViewData["runtimeInfos"] = channel.GetRuntimeInformation();
                ViewData["diskSpaceInfo"] = channel.GetDeviceInformation();
                ViewData["processes"] = channel.GetAllProcess();
                ViewData["services"] = channel.GetAllServices();
                ViewData["ip"] = IP;
                return View("InfoList");
            }
            catch(Exception e)
            {
                ViewData["errorMessage"] = "The requested IP address cannot be reached.";
                return View("~/Views/Connection/ConnectionList.cshtml");
            }
        }

        public ActionResult KillProcess(int pid, string IP)
        {
            IPcInfoSender channel = WcfClient.WcfClient_SetupChannel(IP);
            channel.KillProcess(pid);
            return RedirectToAction("Index", "Info", new { IP = IP });
        }
    }
}