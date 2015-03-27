using PeteFest.Web.Models.Base;
using PeteFest.Web.Models.Festival;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeteFest.Web.Controllers.Base
{
    public class FestivalController : Controller
    {
        [HttpGet]
        public ActionResult Tickets()
        {
            return View(new TicketsModel
                {
                    HeaderText = "Tickets",
                    Name = "Tickets",
                    ParagraphText = "Ticket information goes here..."
                });
        }

        [HttpGet]
        public ActionResult Map()
        {
            return View(new MapModel
                {
                    Name = "How to get here",
                    MapHeaderText = "Map",
                    MapParagraphText = "Map description text...",
                    DirectionsHeaderText = "Directions",
                    DirectionsParagraphText = "Directions description text...",
                    AddressLine1 = "Village Hall",
                    TownOrCity = "Bodle Street Green",
                    County = "East Sussex",
                    Postcode = "BN27",
                    Latitude = 50.9057999, //50.9057494
                    Longitude = 0.3461567, //0.3464475
                    Zoom = 15,
                    LinkText = "View on Google Maps",
                });
        }
    }
}
