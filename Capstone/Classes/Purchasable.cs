using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Purchasable
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Coordinates { get; private set; }
        public string Message { get; private set; }
        public Purchasable(string name, decimal price, string coordinates, string message)
        {
            Name = name;
            Price = price;
            Coordinates = coordinates;
            Message = message;
        }
    }

}
