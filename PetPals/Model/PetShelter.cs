using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class PetShelter
    {
        private List<Pet> availablePets = new List<Pet>();

        public int PetShelterID { get;  set; }

        public void AddPet(Pet pet)
        {
            availablePets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            availablePets.Remove(pet);
        }

        public List<Pet> ListAvailablePets()
        {
            return availablePets;
        }
    }
}
