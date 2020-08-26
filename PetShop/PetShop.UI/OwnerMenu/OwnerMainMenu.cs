using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace PetShop.UI
{
    public class OwnerMainMenu : Menu
    {
        private IOwnerService OwnerService;
        private IServiceProvider ServiceProvider;

        public OwnerMainMenu(IOwnerService ownerService, IServiceProvider serviceProvider) : base("Owner Menu", "Add Owner", "View Owners", "Delete Owner", "Update Owner")
        {
            this.OwnerService = ownerService;
            this.ServiceProvider = serviceProvider;
        }

        protected override void DoAction(int option)
        {
            switch (option)
            {
                case 1:
                    AddOwner(CreateOwner());
                    Pause();
                    break;
                case 2:
                    ServiceProvider.GetRequiredService<OwnerShowcaseMenu>().Run();
                    Pause();
                    break;
                case 3:
                    ServiceProvider.GetRequiredService<OwnerDeleteMenu>().Run();
                    Pause();
                    break;
                case 4:
                    UpdateOwner();
                    Pause();
                    break;
                default:
                    break;
            }
        }

        private Owner CreateOwner()
        {
            int minAddressLenght = 5;
            int minPhoneNumberLenght = 8;

            Console.WriteLine("\nEnter first name:");
            string firstName = Console.ReadLine();

            while (firstName.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid first name");
                firstName = Console.ReadLine();
            }

            Console.WriteLine("\nEnter last name:");
            string lastName = Console.ReadLine();

            while (lastName.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid first name");
                lastName = Console.ReadLine();
            }

            Console.WriteLine("\nEnter adress:");
            string address = Console.ReadLine();

            while (address.Length < minAddressLenght)
            {
                Console.WriteLine("\nPlease enter a valid address");
                address = Console.ReadLine();
            }

            Console.WriteLine("\nEnter phone number:");
            string phoneNumber = Console.ReadLine();

            while (phoneNumber.Length < minPhoneNumberLenght)
            {
                Console.WriteLine("\nPlease enter a valid phone number");
                phoneNumber = Console.ReadLine();
            }

            Console.WriteLine("\nPlease enter an Email if you with to recieve offers and discounts:");
            string email = Console.ReadLine();
            try
            {
                return OwnerService.CreateOwner(firstName, lastName, address, phoneNumber, email);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n{ex.Message}");
                return null;
            }
        }

        private void AddOwner(Owner owner)
        {
            if (OwnerService.AddOwner(owner))
            {
                Console.WriteLine("\nOwner was successfully added!");
            }
        }

        private void UpdateOwner()
        {
            List<Owner> allOwners = OwnerService.GetAllOwners();

            Console.WriteLine("\nPlease select which owner to update:\n");
            int selection = GetOption<Owner>(allOwners, true);

            if (selection > 0)
            {
                Console.WriteLine((OwnerService.UpdateOwner(CreateOwner(), allOwners[selection - 1].ID)) ? "Owner was successfully updated!" : "Error updating owner. Please try again.");
            }
        }
    }
}
