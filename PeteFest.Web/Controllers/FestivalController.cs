using System;
using System.Web.Mvc;
using PeteFest.Web.Alerts;
using PeteFest.Web.Data;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Controllers
{
    public class FestivalController : Controller
    {
        private readonly IData _data; 
        private readonly IAlert _alert;

        public FestivalController(IData data, IAlert alert)
        {
            _data = data;
            _alert = alert;
        }

        [HttpGet]
        public ActionResult Tickets()
        {
            return View(new TicketsModel
                {
                    HeaderText = "Tickets",
                    Name = "Tickets",
                    Paragraph1Text = "Tickets are not currently on sale.",
                    Paragraph2Text = "However if you tell us your name and email address, we can update you when tickets are available"
                });
        }

        [HttpPost]
        public ActionResult Tickets(TicketsModel ticketsModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ticketsModel);
            }

            try
            {
                _data.SaveTicketInfoContact(ticketsModel);
                _alert.Set(this, AlertType.Success, "You have been added to the mailing list");                
            }
            catch (Exception)
            {
                _alert.Set(this, AlertType.Error, "We were unable to add you to the mailing list. Please try again");
            }

            return RedirectToAction("Tickets", "Festival");
        }

        [HttpGet]
        public ActionResult Programme()
        {
            return View(new ProgrammeModel
            {
                Name = "Programme",
                SaturdayProgrammeHeaderText = "Saturday",
                SaturdayProgrammeParagraphText = "The lineup for Saturday is yet to be confirmed",
                SundayProgrammeHeaderText = "Sunday",
                SundayProgrammeParagraphText = "The lineup for Sunday is yet to be confirmed"
            });
        }

        [HttpGet]
        public ActionResult Map()
        {
            return View(_data.GetMapModel());
        }

        [HttpGet]
        public ActionResult Performers()
        {
            return View(_data.GetAllActs());
        }

        [HttpGet]
        public ActionResult GetImage(Guid id)
        {
            var photoModel = _data.GetPhotoModel(id);
            return new FileContentResult(Convert.FromBase64String(photoModel.Data), @"image/png");
        }
    }
}
