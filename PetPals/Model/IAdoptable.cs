using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public interface IAdoptable
    {
        int ParticipantID { get; }

        void Adopt();
    }
}
