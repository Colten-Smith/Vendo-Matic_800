using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Purchasable
    {
        public Gum(string name, decimal price, string coordinates, string message = "Chew Chew, Yum!") : base(name, price, coordinates, message)
        {
        }
    }
}
