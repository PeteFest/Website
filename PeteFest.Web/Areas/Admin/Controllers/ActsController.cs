using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeteFest.Web.Alerts;
using PeteFest.Web.Areas.Admin.AdminData;
using PeteFest.Web.Data;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Areas.Admin.Controllers
{
    public class ActsController : Controller
    {
        private readonly IAdminData _adminData;
        private readonly IData _data;
        private readonly IAlert _alert;

        public ActsController(IAdminData adminData,
            IData data,
            IAlert alert)
        {
            _adminData = adminData;
            _data = data;
            _alert = alert;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_data.GetAllActs());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ActModel());
        }

        [HttpPost]
        public ActionResult Create(ActModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _adminData.CreateAct(model);
                    _alert.Set(this, AlertType.Success, "Changes have been saved");
                    return RedirectToAction("Index", "Acts");
                }
                catch (Exception)
                {
                    _alert.Set(this, AlertType.Error, "Unable to save changes");
                }         
                
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _adminData.DeleteAct(id);
                _alert.Set(this, AlertType.Success, "Changes have been saved");
            }
            catch (Exception)
            {
                _alert.Set(this, AlertType.Error, "Unable to save changes");
            }

            return RedirectToAction("Index", "Acts");
        }
    }
}