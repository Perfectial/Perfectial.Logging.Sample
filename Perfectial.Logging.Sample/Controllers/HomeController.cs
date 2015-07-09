using Perfectial.Logging.Sample.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Perfectial.Logging.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Logger.Information("Index Visited");
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