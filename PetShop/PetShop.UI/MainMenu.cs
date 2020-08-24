using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI
{
    public class MainMenu: Menu
    {
        IPetService petService;
        public MainMenu(IPetService petService) : base("Main Menu", "Show All Pets", "XXX Menu")
        {
            this.petService = petService;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAllPets();
                    Pause();
                    break;
                case 2:

                    break;
                default:
                    break;
            }
        }

        private void ShowAllPets()
        {
            Console.WriteLine("All registered pets are: \n");
            foreach (Pet pet in petService.GetAllPets())
            {
                Console.WriteLine(pet + "\n");
            }
        }




    }
}
