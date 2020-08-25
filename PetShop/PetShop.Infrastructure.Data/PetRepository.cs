using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        private int ID;
        private List<Pet> Pets;

        public PetRepository()
        {
            this.ID = 0;
            this.Pets = new List<Pet>();
        }

        public bool AddPet(Pet pet)
        {
            ID++;
            pet.ID = ID;
            Pets.Add(pet);
            return true;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return Pets;
        }

        public bool UpdatePet(Pet pet)
        {
            int index = Pets.FindIndex((x) => { return x.ID == pet.ID; });
            if (index != -1)
            {
                Pets[index] = pet;
                return true;
            }
            return false;
        }

        public bool DeletePet(int ID)
        {
            Pet pet = Pets.Where((x) => { return x.ID == ID; }).FirstOrDefault();
            if (pet != null)
            {
                Pets.Remove(pet);
                return true;
            }
            return false;
        }

        public void CreateInitialData()
        {
            AddPet(new Pet 
            { 
                Name = "Hr. Dingles",
                Type = petType.Cat,
                Birthdate = DateTime.Parse("29-03-2012"),
                Color = "White with black stripes",
                Price = 750.0
            });
            AddPet(new Pet
            {
                Name = "SlowPoke",
                Type = petType.Turtle,
                Birthdate = DateTime.Parse("15-01-1982"),
                Color = "Dark green",
                Price = 365.25
            });
            AddPet(new Pet
            {
                Name = "Leggy",
                Type = petType.Tarantula,
                Birthdate = DateTime.Parse("05-08-2019"),
                Color = "Brown with orange dots",
                Price = 650.0
            });
        }
    }
}
