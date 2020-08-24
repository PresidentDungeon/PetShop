using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet CreatePet(string petName, petType type, DateTime birthDate, string color, double price);
        public void AddPet(Pet pet);
        List<Pet> GetAllPets();



    }
}
