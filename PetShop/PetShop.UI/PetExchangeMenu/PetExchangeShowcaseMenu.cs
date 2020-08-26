using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI.PetExchangeMenu
{
    public class PetExchangeShowcaseMenu: Menu
    {
        private IPetService PetService;
        private IOwnerService OwnerService;
        private IPetExchangeService PetExchangeService;
        public PetExchangeShowcaseMenu(IPetService petService, IOwnerService ownerService, IPetExchangeService petExchangeService) : base("Showcase Menu", "Display by ID", "Display by Selection")
        {
            this.PetService = petService;
            this.OwnerService = ownerService;
            this.PetExchangeService = petExchangeService;
            ShouldCloseOnFinish = true;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    DisplayPetsByID();
                    break;
                case 2:
                    //DisplayPetsBySelection();
                    break;
                default:
                    break;
            }
        }

        private void DisplayPetsByID()
        {
            Console.WriteLine("\nPlease enter owner ID:");

            int ID;
            while (!int.TryParse(Console.ReadLine(), out ID) || ID <= 0)
            {
                Console.WriteLine("\nPlease only enter a valid ID");
            }

            Owner foundOwner = OwnerService.GetOwnerByID(ID);

            if (foundOwner == null)
            {
                Console.WriteLine("\nNo owner found with that ID");
                return;
            }

            List<Pet> foundPets = PetExchangeService.ListAllPetsRegisteredToOwner(ID);

            Console.Clear();
            Console.WriteLine($"\nAll pets registered to {foundOwner.FirstName} {foundOwner.LastName}:");
            foreach (Pet pet in foundPets)
            {
                Console.WriteLine(pet);
            }
        }

        private void ShowAllPetsByPrice()
        {
            Console.Clear();
            Console.WriteLine("\nAll registered pets by price are:");
            foreach (Pet pet in PetService.GetAllPetsByPrice())
            {
                Console.WriteLine(pet);
            }
        }

        private void ShowAllAvailablePetsByPrice()
        {
            Console.Clear();
            Console.WriteLine("\nAll available pets by price are:");
            foreach (Pet pet in PetService.GetAllAvailablePetsByPrice())
            {
                Console.WriteLine(pet);
            }
        }

        private void DisplayTopFive()
        {
            Console.Clear();
            List<Pet> sortedList = PetService.GetAllAvailablePetsByPrice();
            int availableSize = sortedList.Count;

            if (availableSize == 0)
            {
                Console.WriteLine("\nSorry, there are no available pets at the moment...");
            }
            else
            {
                Console.WriteLine((availableSize < 5) ? $"\nThere are only {availableSize} pets available:" : "\nTop five cheapest available pets are:");

                for (int i = 0; i < availableSize; i++)
                {
                    Console.WriteLine(sortedList[i]);
                }
            }
        }
    }
}
