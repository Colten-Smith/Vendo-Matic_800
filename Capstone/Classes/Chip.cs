using Capstone.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Purchasable
    {
        public Chip(string name, decimal price, string coordinates, string message = "Crunch Crunch, Yum!") : base(name, price, coordinates, message)
        {
        }
    }
}
