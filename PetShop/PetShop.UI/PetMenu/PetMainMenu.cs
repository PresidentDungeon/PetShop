using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.UI.PetMenu
{
    public class PetMainMenu: Menu
    {
        private IPetService petService;
        private IServiceProvider serviceProvider;

        public PetMainMenu(IPetService petService, IServiceProvider serviceProvider) : base("Pet Menu", "View Pets", "Search Pet", "Add Pet", "Remove Pet", "Update Pet")
        {
            this.petService = petService;
            this.serviceProvider = serviceProvider;
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
                    serviceProvider.GetRequiredService<PetSearchMenu>().Run();
                    Pause();
                    break;
                case 3:
                    AddPet(CreatePet());
                    Pause();
                    break;
                case 4:
                    //new VideoDeleteMenu(videoService).Run();
                    serviceProvider.GetRequiredService<PetDeleteMenu>().Run();
                    Pause();
                    break;
                case 5:
                    UpdatePet();
                    Pause();
                    break;
                default:
                    break;
            }
        }

        private Pet CreatePet()
        {
            Array petTypes = Enum.GetValues(typeof(petType));

            Console.WriteLine("\nEnter pet name:");
            string petName = Console.ReadLine();

            while (petName.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid name");
                petName = Console.ReadLine();
            }

            Console.WriteLine("\nSelect a pet type");

            for (int i = 0; i < petTypes.Length; i++)
            {
                Console.WriteLine(i + 1 + ": " + petTypes.GetValue(i));
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > petTypes.Length)
            {
                Console.WriteLine($"Invalid input. Please choose an option in range (0-{petTypes.Length})");
            }

            petType petType = (petType)petTypes.GetValue(selection - 1);

            Console.WriteLine("\nEnter birthdate:");
            DateTime birthDate;

            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.WriteLine("Please enter a valid release date (dd/mm/yyyy)");
            }

            Console.WriteLine("\nEnter pet color:");
            string petColor = Console.ReadLine();

            while (petColor.Length <= 0)
            {
                Console.WriteLine("\nPlease enter a valid color");
                petColor = Console.ReadLine();
            }

            Console.WriteLine("\nEnter pet price:");
            double petPrice;

            while (!double.TryParse(Console.ReadLine(), out petPrice) || petPrice < 0)
            {
                Console.WriteLine("\nPlease enter a valid price");
            }

            return petService.CreatePet(petName, petType, birthDate, petColor, petPrice);
        }

        private void AddPet(Pet pet)
        {
            petService.AddPet(pet);
            Console.WriteLine("\nPet was successfully added!");
        }

        private void ShowAllPets()
        {
            Console.WriteLine("All registered pets are: \n");
            foreach (Pet pet in petService.GetAllPets())
            {
                Console.WriteLine(pet + "\n");
            }
        }

        private void UpdatePet()
        {
            List<Pet> allPets = petService.GetAllPets();

            Console.WriteLine("\nPlease select which pet to update:");

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
                Console.WriteLine((petService.UpdatePet(CreatePet(), allPets[selection - 1].ID)) ? "Pet was successfully updated!" : "Error updating pet. Please try again.");

            }
        }
    }
}
