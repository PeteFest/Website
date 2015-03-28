using PeteFest.Web.Models.Base;
using PeteFest.Web.Models.Festival;
using PeteFest.Web.Models.Festival.Performers;
using PeteFest.Web.Models.Festival.Performers.Acts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
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

        [HttpGet]
        public ActionResult Performers()
        {
            return View(new PerformersModel
                {
                    Name = "Performers",
                    Acts = new List<ActModel>
                    {
                        new ActModel
                        {
                            Name = "Joe Bloggs",
                            Biog = "This is performer Joe - he's done all this stuff",
                            PictureId = Guid.NewGuid(),
                            SoundCloudLink = "http://soundcloud.com",
                            WebsiteLink = "http://petefestdev.azurewebsites.net",
                            YouTubeLink = "http://youtube.com"                      
                        },
                        new ActModel
                        {
                            Name = "Rick Powell",
                            Biog = "This is Rick - he develops websites",
                            PictureId = Guid.NewGuid()
                        }
                    }
                });
        }

        [HttpGet]
        public ActionResult GetImage(Guid id)
        {
            var image = Image.FromFile(@"C:\Users\Rick\Documents\GitHub\Website\PeteFest.Web\Assets\images\header-bg.jpg");

            string encodedImage = string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);
                encodedImage = Convert.ToBase64String(memoryStream.ToArray());
            }

            return new FileContentResult(Convert.FromBase64String(encodedImage), @"image/jpg");
        }
    }
}
