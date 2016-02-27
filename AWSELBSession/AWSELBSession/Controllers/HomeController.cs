using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AWSELBSession.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			HttpClient httpClient = new HttpClient();
			string hostName = httpClient.GetStringAsync("http://169.254.169.254/latest/meta-data/public-hostname").Result;
			string ipv4 = httpClient.GetStringAsync("http://169.254.169.254/latest/meta-data/public-ipv4").Result;

			ControllerContext.HttpContext.Session["HostName"] = hostName;
			ControllerContext.HttpContext.Session["IPV4"] = ipv4;

			ViewBag.HostName = hostName;
			ViewBag.IP = ipv4;

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
	}
}