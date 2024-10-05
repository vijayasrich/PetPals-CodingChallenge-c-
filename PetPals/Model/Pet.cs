using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public int PetID{ get;  set; }
        public string Type { get; set; }

        public Pet(string name, int age, string breed,string type)
        {
            Name = name;
            Age = age;
            Breed = breed;
            Type = type;
        }
        public Pet()
        {
        }

        public override string ToString()
        {
            return $"Pet: {Name}, Age: {Age}, Breed: {Breed},Type: { Type}";
        }

        internal void DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
