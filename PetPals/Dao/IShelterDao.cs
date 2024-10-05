using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    public interface IShelterDao
    {
        void AddShelter(PetShelter petshelter);
        PetShelter GetShelterByID(int petshelterID);
        List<PetShelter> GetAllShelters();
    }
}
