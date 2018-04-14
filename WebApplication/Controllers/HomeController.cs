using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewBag.Ip = GetExternalIPAddress();
            return View();
        }
        public static string GetExternalIPAddress()
        {
            string externalip = new WebClient().DownloadString("http://checkip.dyndns.org/");
            return externalip;
        }
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No network adapters with an IPv4 address in the system!";
        }
    }
}
