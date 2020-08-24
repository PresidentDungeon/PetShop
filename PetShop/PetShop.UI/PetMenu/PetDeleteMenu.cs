using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI.PetMenu
{
    public class PetDeleteMenu: Menu
    {
        private IPetService petService;
        public PetDeleteMenu(IPetService petService) : base("Delete Menu", "Delete by ID", "Delete by selection")
        {
            this.petService = petService;
            shouldCloseOnFinish = true;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    DeleteByID();
                    break;
                case 2:
                    DeleteBySelection();
                    break;
                default:
                    break;
            }
        }
        private void DeleteByID()
        {
            Console.WriteLine("\nPlease enter ID:");

            int ID;
            while (!int.TryParse(Console.ReadLine(), out ID) || ID <= 0)
            {
                Console.WriteLine("Please only enter a valid ID");
            }
            Console.WriteLine((petService.DeletePet(ID) ? "Video was successfully deleted!" : "Error - no such ID found"));
        }

        private void DeleteBySelection()
        {
            List<Pet> allPets = petService.GetAllPets();

            Console.WriteLine("\nPlease select which pet to delete:");

            for (int i = 0; i < allPets.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + allPets[i].ToString());
            }

            Console.WriteLine("\n0: Back");

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > allPets.Count)
            {
                Console.WriteLine($"Invalid input. Please choose an option in range (0-{allPets.Count})");
            }

            if (selection > 0)
            {
                Console.WriteLine((petService.DeletePet(allPets[selection - 1].ID) ? "Pet was successfully deleted!" : "Error - no such ID found"));
            }
        }
    }
}
