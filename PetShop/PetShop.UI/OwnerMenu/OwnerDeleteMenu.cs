using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI.OwnerMenu
{
    public class OwnerDeleteMenu: Menu
    {
        private IOwnerService OwnerService;
        public OwnerDeleteMenu(IOwnerService ownerService) : base("Delete Menu", "Delete by ID", "Delete by Selection")
        {
            this.OwnerService = ownerService;
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
            Console.WriteLine((OwnerService.DeleteOwner(ID) ? "Owner was successfully deleted!" : "Error - no such ID found"));
        }

        private void DeleteBySelection()
        {
            List<Owner> allOwners = OwnerService.GetAllOwners();

            Console.WriteLine("\nPlease select which pet to delete:\n");
            int selection = GetOption<Owner>(allOwners, true);

            if (selection > 0)
            {
                Console.WriteLine((OwnerService.DeleteOwner(allOwners[selection - 1].ID) ? "Owner was successfully deleted!" : "Error - no such ID found"));
            }
        }
    }
}
