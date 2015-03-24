using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeteFest.Data.DBreeze
{
    public class DBreezeTransactionException : Exception
    {
        public DBreezeTransactionException()
        {         
        }

        public DBreezeTransactionException(string message) : base(message)
        {          
        }

        public DBreezeTransactionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
