using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;

namespace PeteFest.Data.Core.GData
{
    public interface IGDataServiceFactory
    {
        GmailService BuildGmailService();
    }
}
