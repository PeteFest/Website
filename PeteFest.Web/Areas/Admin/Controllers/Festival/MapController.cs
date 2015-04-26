using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeteFest.Web.Alerts;
using PeteFest.Web.Areas.Admin.AdminData;
using PeteFest.Web.Data;
using PeteFest.Web.Models;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Areas.Admin.Controllers.Festival
{
    public class MapController : Controller
    {
        private readonly IData _data;
        private readonly IAdminData _adminData;
        private readonly IAlert _alert;

        public MapController(IData data, IAdminData adminData, IAlert alert)
        {
            _data = data;
            _adminData = adminData;
            _alert = alert;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_data.GetMapModel());
        }

        [HttpPost]
        public ActionResult Index(MapModel mapModel)
        {
            if (!ModelState.IsValid)
            {
                return View(mapModel);
            }

            try
            {
                _adminData.SaveMapPageMetadata(mapModel);
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