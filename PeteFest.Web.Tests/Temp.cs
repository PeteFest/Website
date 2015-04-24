using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeteFest.Data.Core.GData;
using PeteFest.Data.DataObjects;
using PeteFest.Data.WebsiteMetadata;
using PeteFest.Data.WebsiteMetadata.Pages;
using PeteFest.Web.GData;

namespace PeteFest.Web.Tests
{
    [TestClass]
    public class Temp
    {
        [TestMethod]
        public void Temp1()
        {
            UserCredential credential;

            using (var stream = new SettingsStream().Build("g6TZ20QyAn6YXFo8Pd0pGbsH",
                "iron.man1899@gmail.com",
                "676426696659-rl1nmttrjdrifcdjtt8cgo8b7t8e7i4v.apps.googleusercontent.com"))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                    new[] { GmailService.Scope.GmailModify },
                    "user", CancellationToken.None).Result;
            }

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Gmail Test"
            });

            var repo = new GDataRepository<TicketInfoContact>(service);
            var data = repo.Create(new TicketInfoContact
            {
                EmailAddress = "mytestemailaddress@mailinator.com",
                ContactName = "Rick"
            });
            var moreData = repo.Retrieve(data.Id);
        }
    }
}
