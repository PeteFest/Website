using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeteFest.Web.Alerts
{
    public class Alert : IAlert
    {
        public void Set(Controller controller, AlertType alertType, string message)
        {
            controller.TempData[AlertKeys.AlertType] = alertType;
            controller.TempData[AlertKeys.AlertMessage] = message;
        }
    }
}