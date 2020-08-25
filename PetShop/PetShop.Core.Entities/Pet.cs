using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public petType Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner? Owner { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} (ID {ID})\nAnimal Type: {Type}\nColor: {Color}\nBirthDate: {Birthdate.ToString("dd/MM/yyyy")}" +
                $"\nPrice: {Price.ToString("n2")} DKK\nStatus: {((Owner == null) ? "NOT SOLD" : $"SOLD TO {Owner} ({SoldDate})")}\n";
        }
    }

    public enum petType
    {
        Cat,
        Dog,
        Goat,
        Lizard,
        Turtle,
        Tarantula
    }
}
