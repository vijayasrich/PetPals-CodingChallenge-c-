using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.IOException
{
    namespace PetAdoptionPlatform.Exception
    {
        public class InsufficientFundsException : System.IO.IOException
        {
            public InsufficientFundsException() : base("Insufficient funds. The minimum donation amount is $10.") { }

            public InsufficientFundsException(string message) : base(message) { }

            public InsufficientFundsException(string message, System.IO.IOException inner) : base(message, inner) { }
        }
    }
}
