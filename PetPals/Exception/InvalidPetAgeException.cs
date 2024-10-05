using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.IOException
{
    namespace PetAdoptionPlatform.Exception
    {
        public class InvalidPetAgeException : System.IO.IOException
        {
            public InvalidPetAgeException() : base("Invalid pet age. Age must be a positive integer.") { }

            public InvalidPetAgeException(string message) : base(message) { }

            public InvalidPetAgeException(string message, System.IO.IOException inner) : base(message, inner) { }
        }
    }
}
