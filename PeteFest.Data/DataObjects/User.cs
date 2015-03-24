using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBreeze.Utils;

namespace PeteFest.Data.DataObjects
{
    public class User
    {
        public string EmailAddress { get; set; }

        public byte[] Salt { get; set; }

        public byte[] HashedPassword { get; set; }
    }
}
