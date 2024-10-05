using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class Dog:Pet
    {
        public string DogBreed { get; set; }

        public Dog(string name, int age, string breed,string type,string dogBreed) : base(name, age, breed,type)
        {
            DogBreed = dogBreed;
        }

        public override string ToString()
        {
            return $"Dog: {Name}, Age: {Age}, Breed: {DogBreed},Type:{Type}";
        }
    }
}
