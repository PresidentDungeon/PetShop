using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public abstract class Menu
    {
        private int EXIT_OPTION = 0;
        protected bool shouldCloseOnFinish = false;
        private string inputText = "Please select an option:";

        private string[] menuItems;
        private string menuTitle;

        public Menu(string menuTitle, params string[] menuItems)
        {
            this.menuTitle = menuTitle;
            this.menuItems = menuItems;
        }

        private int GetOption()
        {
            int option = -1;

            while (option < 0)
            {
                Console.WriteLine("\n" + inputText);
                string nrAsText = Console.ReadLine();

                try
                {
                    option = int.Parse(nrAsText);

                    if (option < 0 || option > menuItems.Length)
                    {
                        Console.WriteLine("Invalid options. Please choose an option in range (0 - " + menuItems.Length + " )");
                        option = -1;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Make sure that the entered value is a number");
                }
            }

            return option;
        }

        protected abstract void DoAction(int option);

        public void Run()
        {
            do
            {
                PrintMenu();
                int option = GetOption();

                if (option != 0)
                {
                    DoAction(option);
                }
                else
                {
                    Console.WriteLine("\nClosing " + menuTitle);
                    break;
                }
            } while (!shouldCloseOnFinish);
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(menuTitle + "\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(i + 1 + ": " + menuItems[i]);
            }
            Console.WriteLine("0: Exit");
        }

        protected void Print(string stringToPrint)
        {
            Console.WriteLine(stringToPrint);
        }

        protected void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
