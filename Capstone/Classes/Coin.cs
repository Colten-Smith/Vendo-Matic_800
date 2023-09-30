using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Coin
    {
        public string Name { get; }
        public decimal Value { get; }
        public Coin (string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
