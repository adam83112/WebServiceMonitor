using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace WebServiceMonitor.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewData["WebServices"] = Checker.WebServiceList;

            return View();
		}
	}
}

