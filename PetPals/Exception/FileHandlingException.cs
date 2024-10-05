using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.IOException
{
    namespace PetAdoptionPlatform.Exceptions
    {
        public class FileHandlingException : System.IO.IOException
        {
            public FileHandlingException() : base("An error occurred while handling the file.") { }

            public FileHandlingException(string message) : base(message) { }

            public FileHandlingException(string message, System.IO.IOException inner) : base(message, inner) { }
        }
    }
}
