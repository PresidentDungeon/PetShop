using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        private int ID;
        private List<Owner> Owners;

        public OwnerRepository()
        {
            this.ID = 0;
            this.Owners = new List<Owner>();
        }

        public bool AddOwner(Owner owner)
        {
            ID++;
            owner.ID = ID;
            Owners.Add(owner);
            return true;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return Owners;
        }

        public bool UpdateOwner(Owner owner)
        {
            int index = Owners.FindIndex((x) => { return x.ID == owner.ID; });
            if (index != -1)
            {
                Owners[index].FirstName = owner.FirstName;
                Owners[index].LastName = owner.LastName;
                Owners[index].Address = owner.Address;
                Owners[index].PhoneNumber = owner.PhoneNumber;
                Owners[index].Email = owner.Email;
                return true;
            }
            return false;
        }

        public bool DeleteOwner(int ID)
        {
            Owner owner = Owners.Where((x) => { return x.ID == ID; }).FirstOrDefault();
            if (owner != null)
            {
                Owners.Remove(owner);
                return true;
            }
            return false;
        }
    }
}
