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
        private IPetRepository PetRepository;

        public PetService(IPetRepository PetRepository)
        {
            this.PetRepository = PetRepository;
        }

        public List<Pet> GetAllPets()
        {
            return PetRepository.ReadPets().ToList();
        }
    }
}
