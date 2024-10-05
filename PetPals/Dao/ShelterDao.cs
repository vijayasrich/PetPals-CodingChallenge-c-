using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    public class ShelterDao : IShelterDao
    {
        private List<PetShelter> shelters = new List<PetShelter>();

        public void AddShelter(PetShelter petshelter)
        {
            shelters.Add(petshelter);
        }

        public void RemoveShelter(int shelterID)
        {
            var shelter = shelters.FirstOrDefault(s => s.PetShelterID == shelterID);
            if (shelter != null)
            {
                shelters.Remove(shelter);
            }
        }

        public PetShelter GetShelterByID(int shelterID)
        {
            return shelters.FirstOrDefault(s => s.PetShelterID == shelterID);
        }

        public List<PetShelter> GetAllShelters()
        {
            return shelters;
        }
    }
}

