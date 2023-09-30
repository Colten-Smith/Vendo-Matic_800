using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    public class Grid
    {
        /// <summary>
        /// Dictionary containing every item in the vending machine and the quantity of each item.
        /// </summary>
        public Dictionary<string, Slot> ItemDict { get; private set; }
        /// <summary>
        /// Manages items in the vending machine.
        /// </summary>
        /// <param name="itemDict">Initial dictionary of items in the vending machine.</param>
        public Grid(Dictionary<string, Slot> itemDict)
        {
            ItemDict = itemDict;
        }
        /// <summary>
        /// Adds a new item to the vending machine.
        /// </summary>
        /// <param name="itemToAdd">The item to be added.</param>
        /// <param name="quantity">The quantity of items to add.</param>
        public void AddItem(Purchasable itemToAdd, int quantity = 5)
        {
            if (ItemDict.ContainsKey(itemToAdd.Coordinates))
            {
                ItemDict[itemToAdd.Coordinates].Add(quantity);
            }
            else
            {
                ItemDict[itemToAdd.Coordinates] = new Slot(itemToAdd);
            }
        }
        /// <summary>
        /// Removes a valid item from the vending machine. Returns null if no items are left.
        /// </summary>
        /// <param name="coordinates">The coordinates of the item to remove.</param>
        /// <returns>The item removed. Null if no items are left to remove.</returns>
        public Purchasable RemoveItem(string coordinates)
        {
            if (ItemDict[coordinates.ToUpper()].Remove())
            {
                return ItemDict[coordinates.ToUpper()].ItemStored;
            }
            return null;
        }
        /// <summary>
        /// Checks to see if an item exists in the vending machine.
        /// </summary>
        /// <param name="coordinates">The coordinates to check.</param>
        /// <returns>Returns true if the item coordinates are valid, returns false if they are not.</returns>
        public bool FindItem(string coordinates)
        {
            if (ItemDict.ContainsKey(coordinates.Trim().ToUpper()))
            {
                return true;
            }
            return false;
        }
        public void MakeSlots(List<string[]> inputs)
        {
            foreach (string[] input in inputs)
            {
                string coordinates = input[0];
                string name = input[1];
                decimal price = decimal.Parse(input[2]);
                string type = input[3];
                Purchasable item;

                if (type == "Chip")
                {
                    item = new Chip(name, price, coordinates);
                }
                else if (type == "Candy")
                {
                    item = new Candy(name, price, coordinates);
                }
                else if (type == "Drink")
                {
                    item = new Drink(name, price, coordinates);
                }
                else
                {
                    item = new Gum(name, price, coordinates);
                }
                Slot newSlot = new Slot(item);
                ItemDict[newSlot.ItemStored.Coordinates] = newSlot;
            }
        }
        public Purchasable GetItem(string coordinates)
        {
            if (ItemDict.ContainsKey(coordinates))
            {
                return ItemDict[coordinates].ItemStored;
            }
            return null;
        }
    }
}
