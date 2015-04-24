using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;

namespace PeteFest.Web.GData
{
    public class SettingsStream : ISettingsStream
    {
        public Stream Build(string clientSecret, string clientEmail, string clientId)
        {
            var json = BuildJson(
                BuildJsonItem("auth_uri", "https://accounts.google.com/o/oauth2/auth"),
                BuildJsonItem("client_secret", clientSecret),
                BuildJsonItem("token_uri", "https://accounts.google.com/o/oauth2/token"),
                BuildJsonItem("client_email", clientEmail),
                BuildJsonArray("redirect_uris",
                    BuildJsonArrayItem("urn:ietf:wg:oauth:2.0:oob"),
                    BuildJsonArrayItem("oob")),
                BuildJsonItem("client_x509_cert_url", string.Empty),
                BuildJsonItem("client_id", clientId),
                BuildJsonItem("auth_provider_x509_cert_url", "https://www.googleapis.com/oauth2/v1/certs"));

            json = string.Format("\"installed\": {0}", json);
            json = "{" + json + "}";

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private string BuildJson(params string[] jsonItems)
        {
            var json = "{";
            json += jsonItems.Aggregate((prev, curr) => prev + ", " + curr);
            json += "}";

            return json;
        }

        private string BuildJsonItem(string propertyName, string propertyValue)
        {
            return string.Format("\"{0}\": \"{1}\"", propertyName, propertyValue);
        }

        private string BuildJsonArray(string arrayName, params string[] jsonArrayItems)
        {
            var json = string.Format("\"{0}\": [", arrayName);
            json += jsonArrayItems.Aggregate((prev, curr) => prev + ", " + curr);
            json += "]";

            return json;
        }

        private string BuildJsonArrayItem(string propertyValue)
        {
            return "\"" + propertyValue + "\"";
        }
    }
}