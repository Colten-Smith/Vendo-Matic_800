using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Slot
    {
        public Purchasable ItemStored { get; private set; }
        public int Quantity { get; private set; }
        public int Max { get; private set; }
        public Slot(Purchasable itemStored, int quantity = 5, int max = 5)
        {
            ItemStored = itemStored;
            Quantity = quantity;
            Max = max;
        }
        public bool Remove()
        {
            if (Quantity > 0)
            {
                Quantity--;
                return true;
            }
            return false;
        }
        public bool Add(int amountToAdd)
        {
            if(Quantity + amountToAdd < Max && amountToAdd > 0)
            {
                Quantity += amountToAdd;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
