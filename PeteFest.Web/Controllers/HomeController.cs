using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeteFest.Web.Models;

namespace PeteFest.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new HomeModel
            {
                Name = "Home",
                PreHeaderText = "Welcome to",
                HeaderText = "PeteFest UK",
                SummaryText = string.Empty,
                TwitterWidgetId = "580681576792608768"
            });
        }
    }
}
