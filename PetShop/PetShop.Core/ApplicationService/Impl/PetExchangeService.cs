﻿using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetExchangeService : IPetExchangeService
    {
        private IPetRepository PetRepository;

        public PetExchangeService(IPetRepository petRepository)
        {
            this.PetRepository = petRepository;
        }
        public bool RegisterPet(Pet pet, Owner owner)
        {
            pet.Owner = owner;
            pet.SoldDate = DateTime.Now;
            return PetRepository.UpdatePet(pet);
        }

        public bool UnregisterPet(Pet pet)
        {
            pet.Owner = null;
            return PetRepository.UpdatePet(pet);
        }

        public List<Pet> ListAllPetsRegisteredToOwner(int ID)
        {
            IEnumerable<Pet> pets = from x in PetRepository.ReadPets() where x.Owner != null select x;
            return (from x in pets where x.Owner.ID == ID select x).ToList();
        }

        public List<Pet> ListAllPetsWithOwner()
        {
            return (from x in PetRepository.ReadPets() where x.Owner != null select x).ToList();
        }
    }
}
