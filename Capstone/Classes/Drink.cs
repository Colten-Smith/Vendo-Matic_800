using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Purchasable
    {
        public Drink(string name, decimal price, string coordinates, string message = "Glug Glug, Yum!") : base(name, price, coordinates, message)
        {
        }
    }
}
