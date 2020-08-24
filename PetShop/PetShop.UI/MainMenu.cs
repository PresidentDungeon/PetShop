using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PetShop.UI
{
    public class MainMenu: Menu
    {
        IPetService petService;
        public MainMenu(IPetService petService) : base("Main Menu", "Show All Pets", "Search Pet", "Add Pet")
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
                    //search
                    break;
                case 3:
                    //AddPet(CreatePet());
                    CreatePet();
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

            Pet pet = new Pet {Name = petName, Type = petType, Birthdate = birthDate, Color = petColor, Price = petPrice};
            Console.WriteLine(pet);
            return pet;
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
