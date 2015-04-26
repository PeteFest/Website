using System.Web.Mvc;
using PeteFest.Web.Data;
using PeteFest.Web.Mapping;
using PeteFest.Web.Models;

namespace PeteFest.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly IData _data;

        public AboutController(IData data)
        {
            _data = data;
        }

        public ActionResult Index()
        {
            return View(_data.GetAboutModel());

            //return View(new AboutModel
            //{
            //    Name = "About",
            //    HeaderText = "What is PeteFest?",
            //    Paragraph1Text = "PeteFest is...",
            //    PictureUrl = "Assets/images/about.jpg"
            //});
        }
    }
}
