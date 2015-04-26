using System.IO;
using System.Linq;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;

namespace PeteFest.Data.Core.GData
{
    public class GDataServiceFactory : IGDataServiceFactory
    {
        private readonly string _clientSecret;
        private readonly string _clientEmail;
        private readonly string _clientId;

        public GDataServiceFactory(string clientSecret, string clientEmail, string clientId)
        {
            _clientSecret = clientSecret;
            _clientEmail = clientEmail;
            _clientId = clientId;
        }

        public GmailService BuildGmailService()
        {
            UserCredential credential;
            using (var stream = BuildSettingsStream())
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                    new[] { GmailService.Scope.MailGoogleCom },
                    "user", CancellationToken.None).Result;
            }

            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Gmail Test"
            });
        }

        private Stream BuildSettingsStream()
        {
            var json = BuildJson(
                BuildJsonItem("auth_uri", "https://accounts.google.com/o/oauth2/auth"),
                BuildJsonItem("client_secret", _clientSecret),
                BuildJsonItem("token_uri", "https://accounts.google.com/o/oauth2/token"),
                BuildJsonItem("client_email", _clientEmail),
                BuildJsonArray("redirect_uris",
                    BuildJsonArrayItem("urn:ietf:wg:oauth:2.0:oob"),
                    BuildJsonArrayItem("oob")),
                BuildJsonItem("client_x509_cert_url", string.Empty),
                BuildJsonItem("client_id", _clientId),
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

        private static string BuildJsonArray(string arrayName, params string[] jsonArrayItems)
        {
            var json = string.Format("\"{0}\": [", arrayName);
            json += jsonArrayItems.Aggregate((prev, curr) => prev + ", " + curr);
            json += "]";

            return json;
        }

        private static string BuildJsonArrayItem(string propertyValue)
        {
            return "\"" + propertyValue + "\"";
        }
    }
}