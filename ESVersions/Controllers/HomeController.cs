using ESVersions.Models;
using ESVersions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESVersions.Controllers
{
    public class HomeController : Controller
    {
        private IDataService service;

        public HomeController(IDataService _service)
        {
            service = _service;
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index()
        {
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

        [OutputCache(Duration = 10, VaryByParam = "query")]
        public PartialViewResult SwList(string query)
        {
            var model = service.GetSoftwares(query);
            return PartialView("_SoftwareTableView", model);
        }
    }
}