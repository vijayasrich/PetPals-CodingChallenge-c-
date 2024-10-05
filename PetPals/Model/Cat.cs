using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    public class Cat : Pet
    {
        public string CatColor { get; set; }

        public Cat(string name, int age, string breed, string type,string catColor) : base(name, age, breed,type)
        {
            CatColor = catColor;
        }

        public override string ToString()
        {
            return $"Cat: {Name}, Age: {Age}, Breed: {Breed}, Color: {CatColor}";
        }
    }
}
