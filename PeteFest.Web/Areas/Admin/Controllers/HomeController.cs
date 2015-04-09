using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeteFest.Web.Alerts;
using PeteFest.Web.Areas.Admin.AdminData;
using PeteFest.Web.Data;
using PeteFest.Web.Models;

namespace PeteFest.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IData _data;
        private readonly IAdminData _adminData;
        private readonly IAlert _alert;

        public HomeController(IData data, IAdminData adminData, IAlert alert)
        {
            _data = data;
            _adminData = adminData;
            _alert = alert;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_data.GetHomeModel());
        }

        [HttpPost]
        public ActionResult Index(HomeModel homeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(homeModel);
            }

            try
            {
                _adminData.SaveHomePageMetadata(homeModel);
                _alert.Set(this, AlertType.Success, "Changes have been saved");
            }
            catch (Exception)
            {
                _alert.Set(this, AlertType.Error, "Unable to save changes");
            }

            return Index();
        }
    }
}