using System;

namespace PeteFest.Data.Core.DBreeze
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
