using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeteFest.Web.Alerts
{
    public interface IAlert
    {
        void Set(Controller controller, AlertType alertType, string message);
    }
}