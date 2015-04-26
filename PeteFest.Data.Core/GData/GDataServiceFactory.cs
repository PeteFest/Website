using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;

namespace PeteFest.Data.Core.GData
{
    public class GDataServiceFactory : IGDataServiceFactory
    {
        private readonly string _clientSecret;
        private readonly string _clientEmail;
        private readonly string _clientId;
        private readonly string _refreshToken;

        public GDataServiceFactory(string clientSecret, string clientEmail, string clientId, string refreshToken)
        {
            _clientSecret = clientSecret;
            _clientEmail = clientEmail;
            _clientId = clientId;
            _refreshToken = refreshToken;
        }

        public GmailService BuildGmailService()
        {
            UserCredential credential;

            //using (var destinationStream = new MemoryStream())
            //{
            //    using (var streamWriter = new StreamWriter(destinationStream))
            //    {
            //        streamWriter.Write(BuildSettingsJson());
            //        streamWriter.Flush();
            //        destinationStream.Position = 0;

            //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(destinationStream).Secrets,
            //        new[] { GmailService.Scope.MailGoogleCom },
            //        _clientEmail, CancellationToken.None).Result;
            //    }
            //}

            var token = new TokenResponse() { RefreshToken = _refreshToken };
            credential = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = _clientId,
                        ClientSecret = _clientSecret
                    },
                    Scopes = new List<string> { GmailService.Scope.MailGoogleCom }
                }),
                _clientEmail,
                token);

            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Gmail Test"
            });
        }

        private string BuildSettingsJson()
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
            return "{" + json + "}";
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