using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PeteFest.Data.Repositories;
using PeteFest.Web.Areas.Admin.AdminData;
using PeteFest.Web.Areas.Admin.Models;
using PeteFest.Web.Data;

namespace PeteFest.Web.Areas.Admin.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IAdminData _adminData;
        private readonly IData _data;

        public PhotosController(IAdminData adminData,
            IData data)
        {
            _adminData = adminData;
            _data = data;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Browse()
        {
            return View(_adminData.GetAllPhotos());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(PhotoModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View(new PhotoModel());
        }

        [HttpPost]
        public ActionResult Files(IEnumerable<HttpPostedFileBase> files)
        {
            // TODO:
            foreach (var file in files)
            {
                using (var stream = file.InputStream)
                {
                    using (var destination = new MemoryStream())
                    {
                        stream.CopyTo(destination);
                        var bytes = destination.ToArray();

                        var model = new PhotoModel
                        {
                            Name = file.FileName,
                            Data = Convert.ToBase64String(bytes),
                            Id = Guid.NewGuid()
                        };

                        _adminData.SavePhoto(model);
                    }
                }
            }

            return Json("All files have been successfully stored.");
        }

        [HttpGet]
        public ActionResult GetImage(Guid id)
        {
            var photoModel = _data.GetPhotoModel(id);

            return new FileContentResult(Convert.FromBase64String(photoModel.Data), @"image/png");
        }
    }
}