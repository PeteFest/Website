using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeteFest.Web.Models;

namespace PeteFest.Web.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View(new AboutModel
            {
                Name = "About",
                HeaderText = "What is PeteFest?",
                ParagraphText = "PeteFest is...",
                PictureUrl = "Assets/images/about.jpg"
            });
        }
    }
}
