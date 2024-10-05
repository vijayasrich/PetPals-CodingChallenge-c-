using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.IOException
{
    namespace PetAdoptionPlatform.Exceptions
    {
        public class AdoptionException : System.IO.IOException
        {
            public AdoptionException() : base("An error occurred during the adoption process.") { }

            public AdoptionException(string message) : base(message) { }

            public AdoptionException(string message, System.IO.IOException inner) : base(message, inner) { }
        }
    }
}
