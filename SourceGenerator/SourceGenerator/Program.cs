using System;
using JavaProject;

namespace SourceGenerator
{

    class Program
    {
        public static void Main()
        {
            MyProject a = new MyProject();
            Pet pet = new Pet();
            pet.id = 6;
            pet.name = "pet6";
            pet.type = "type6";
            a.savePet(pet);
            
             
           Console.WriteLine(a.findPet(6).id);
           Console.WriteLine(a.findPet(6).name);

        }
    }
}