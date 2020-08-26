using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI.PetExchangeMenu
{
    public class PetExchangeUnregisterMenu: Menu
    {
        private IPetService PetService;
        private IPetExchangeService PetExchangeService;

        public PetExchangeUnregisterMenu(IPetService petService, IPetExchangeService petExchangeService) : base("Unregister Menu", "Unregister by ID", "Unregister by Selection")
        {
            this.PetService = petService;
            this.PetExchangeService = petExchangeService;
            ShouldCloseOnFinish = true;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    UnregisterByID();
                    break;
                case 2:
                    UnregisterBySelection();
                    break;
                default:
                    break;
            }
        }

        private void UnregisterByID()
        {
            Console.WriteLine("\nPlease enter Pet ID:");

            int petID;
            while (!int.TryParse(Console.ReadLine(), out petID) || petID <= 0)
            {
                Console.WriteLine("\nPlease only enter a valid ID");
            }

            Console.Clear();

            Pet pet = PetService.GetPetByID(petID);

            if (pet.Owner == null || pet == null)
            {
                Console.WriteLine("No pet or registered owner found with that ID");
                return;
            }

            Console.WriteLine($"\nDo you want to remove\n{pet.Owner}\nas a owner to\n{pet}");
            Console.WriteLine("(y/n)");

            string choise = Console.ReadLine();

            while (choise.ToLower() != "y" && choise.ToLower() != "n")
            {
                Console.WriteLine("Please type 'y' to accept or 'n' to cancel");
                choise = Console.ReadLine();
            }

            if (choise.Equals("y"))
            {
                Console.WriteLine((PetExchangeService.UnregisterPet(pet)) ? "Owner successfully removed as owner to pet" : "Error unregistering owner to pet. Please try again");
            }
        }

        private void UnregisterBySelection()
        {
            List<Pet> allOwnedPets = PetExchangeService.ListAllPetsWithOwner();
            Pet selectedPet;

            Console.Clear();
            Console.WriteLine("\nPlease select which pet to unregister owner:\n");
            int petSelection = GetOption<Pet>(allOwnedPets, true);

            if (petSelection == 0)
            {
                return;
            }

            selectedPet = allOwnedPets[petSelection - 1];

            Console.Clear();
            Console.WriteLine($"\nDo you want to unregister\n{selectedPet.Owner}\nas a owner to\n{selectedPet}");
            Console.WriteLine("(y/n)");

            string choise = Console.ReadLine();

            while (choise.ToLower() != "y" && choise.ToLower() != "n")
            {
                Console.WriteLine("Please type 'y' to accept or 'n' to cancel");
                choise = Console.ReadLine();
            }

            if (choise.Equals("y"))
            {
                Console.WriteLine((PetExchangeService.UnregisterPet(selectedPet)) ? "Owner successfully removed as owner to pet" : "Error unregistering owner to pet. Please try again");
            }
        }
    }
}
