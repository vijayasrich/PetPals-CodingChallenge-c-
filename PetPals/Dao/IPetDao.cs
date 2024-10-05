using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Dao
{
    public interface IPetDao
    {
        List<Pet> GetAllPets();
        void AddPet(Pet pet);
       
        Pet GetPetByID(int petID);
       
        void UpdatePet(Pet petToUpdate);
        void DeletePet(int deletePetId);
    }
}
