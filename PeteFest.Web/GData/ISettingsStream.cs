using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PeteFest.Web.GData
{
    public interface ISettingsStream
    {
        Stream Build(string clientSecret, string clientEmail, string clientId);
    }
}