﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Owner
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (ID: {ID})";
        }
    }
}