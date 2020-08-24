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

        public Pet GetPetByID(int ID)
        {
            return GetAllPets().Where((x) => { return x.ID == ID; }).FirstOrDefault();
        }

        public List<Pet> GetPetByType(petType type)
        {
            return (from x in GetAllPets() where x.Type.Equals(type) select x).ToList();
        }

        public List<Pet> GetPetByName(string searchTitle)
        {
            string[] searchTerms = searchTitle.ToLower().Split('%');
            List<Pet> matches = new List<Pet>();

            foreach (Pet pet in GetAllPets())
            {
                int size = 0;
                if (!searchTitle.StartsWith('%'))
                {
                    if (!pet.Name.ToLower().StartsWith(searchTerms[0]))
                    {
                        continue;
                    }
                }
                else
                {
                    size++;
                }

                String petTitle = pet.Name.ToLower();

                for (int i = size; i < searchTerms.Length; i++)
                {

                    if (petTitle.Contains(searchTerms[i]))
                    {
                        int index = petTitle.IndexOf(searchTerms[i]);
                        petTitle = petTitle.Substring(index + searchTerms[i].Length);
                    }
                    else
                    {
                        break;
                    }

                    if (searchTitle.EndsWith("%"))
                    {
                        if (petTitle.Length > 0)
                        {
                            matches.Add(pet);
                            break;
                        }
                    }
                    else
                    {
                        if (petTitle.Length == 0)
                        {
                            matches.Add(pet);
                            break;
                        }
                    }
                }
            }
            return matches;
        }

        public List<Pet> GetPetByBirthdate(DateTime date)
        {
            return (from x in GetAllPets() where x.Birthdate.Equals(date) select x).ToList();
        }

        public bool UpdatePet(Pet pet, int ID)
        {
            pet.ID = ID;
            return petRepository.UpdatePet(pet);
        }

        public bool DeletePet(int ID)
        {
            return petRepository.DeletePet(ID);
        }
    }
}
