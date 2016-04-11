using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Dota 2 Build Comparison (name pending)";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How to contact me:";

            return View();
        }
    }
}