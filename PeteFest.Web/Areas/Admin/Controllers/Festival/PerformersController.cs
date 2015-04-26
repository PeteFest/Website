using System;
using System.Web.Mvc;
using PeteFest.Web.Alerts;
using PeteFest.Web.Areas.Admin.AdminData;
using PeteFest.Web.Data;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Areas.Admin.Controllers.Festival
{
    public class PerformersController : Controller
    {
        private readonly IAdminData _adminData;
        private readonly IData _data;
        private readonly IAlert _alert;

        public PerformersController(IAdminData adminData,
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
                    return RedirectToAction("Index", "Performers");
                }
                catch (Exception)
                {
                    _alert.Set(this, AlertType.Error, "Unable to save changes");
                }         
                
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(_data.GetAct(id));
        }

        public ActionResult Edit(Guid id, ActModel model)
        {
            model.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _adminData.UpdateAct(model);
                    _alert.Set(this, AlertType.Success, "Changes have been saved");                 
                }
                catch (Exception)
                {
                    _alert.Set(this, AlertType.Error, "Unable to save changes");
                }
            }

            return RedirectToAction("Index", "Performers");
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

            return RedirectToAction("Index", "Performers");
        }
    }
}