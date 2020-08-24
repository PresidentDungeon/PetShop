using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private IPetRepository petRepository;

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }


        public Pet CreatePet(string petName, petType type, DateTime birthDate, string color, double price)
        {
            return new Pet { Name = petName, Type = type, Birthdate = birthDate, Color = color, Price = price };
        }

        public void AddPet(Pet pet)
        {
            petRepository.AddPet(pet);
        }

        public List<Pet> GetAllPets()
        {
            return petRepository.ReadPets().ToList();
        }
    }
}
