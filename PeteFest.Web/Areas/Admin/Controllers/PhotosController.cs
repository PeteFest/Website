using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeteFest.Web.Areas.Admin.Models;

namespace PeteFest.Web.Areas.Admin.Controllers
{
    public class PhotosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Browse()
        {
            return View();
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
                //string filePath = Path.Combine(TempPath, file.FileName);
                //System.IO.File.WriteAllBytes(filePath, ReadData(file.InputStream));
            }

            return Json("All files have been successfully stored.");
        }
    }
}