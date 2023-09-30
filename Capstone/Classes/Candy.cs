using Capstone.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : Purchasable
    {
        public Candy(string name, decimal price, string coordinates, string message = "Munch Munch, Yum!") : base(name, price, coordinates, message)
        {
        }
    }
}
