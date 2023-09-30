using Capstone.Classes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class GridTests
    {
        private Grid GridToTest { get; set; }
        private Grid FullGrid { get; set; }
        [TestInitialize]
        public void StartTests()
        {
            FullGrid = new Grid(new Dictionary<string, Slot>());
            FileReader fileReader = new FileReader(@"C:\Users\Student\workspace\pairs\c-sharp-minicapstonemodule1-team1\vendingmachine.csv");
            GridToTest = new Grid(new Dictionary<string, Slot>());
            FullGrid.MakeSlots(fileReader.GetItemsFromFile());
        }
        [DataTestMethod]
        [DataRow("Chip", "Dorito", 3, "A1")]
        [DataRow("Chip", "Lays", 1, "B7")]
        [DataRow("Chip", "Fritos", .75, "E2")]
        [DataRow("Chip", "Tostitos", 3.75, "A1")]
        [DataRow("Candy", "M&M's", 1.99, "A4")]
        [DataRow("Candy", "Snickers", .5, "A6")]
        [DataRow("Drink", "Brisk", 2.85, "G2")]
        [DataRow("Gum", "Major League Chew", .99, "E9")]
        public void AddItemTests_HappyPath(string type, string name, double price, string coordinates)
        {
            if (type == "Chip")
            {
                Chip item = new Chip(name, (decimal)price, coordinates);
                GridToTest.AddItem(item);
                Assert.IsTrue(GridToTest.ItemDict[coordinates].ItemStored == item);
            }
            else if (type == "Candy")
            {
                Candy item = new Candy(name, (decimal)price, coordinates);
                GridToTest.AddItem(item);
                Assert.IsTrue(GridToTest.ItemDict[coordinates].ItemStored == item);
            }
            else if (type == "Drink")
            {
                Drink item = new Drink(name, (decimal)price, coordinates);
                GridToTest.AddItem(item);
                Assert.IsTrue(GridToTest.ItemDict[coordinates].ItemStored == item);
            }
            else
            {
                Gum item = new Gum(name, (decimal)price, coordinates);
                GridToTest.AddItem(item);
                Assert.IsTrue(GridToTest.ItemDict[coordinates].ItemStored == item);
            }

        }
        [DataTestMethod]
        [DataRow("A1", true)]
        [DataRow("B2", true)]
        [DataRow("A5", false)]
        [DataRow("C2", true)]
        [DataRow("D5", false)]
        [DataRow("E1", false)]
        [DataRow("A2", true)]
        [DataRow("D4", true)]
        [DataRow("IDK", false)]
        public void FindItemTests_HappyPath(string coordinate, bool expected)
        {
            Assert.AreEqual(expected, FullGrid.FindItem(coordinate));
        }

        [DataTestMethod]
        //A1|Potato Crisps|3.05|Chip
        [DataRow("A1", "Potato Crisps", 3.05, "Chip")]
        //A2|Stackers|1.45|Chip
        [DataRow("A2", "Stackers", 1.45, "Chip")]
        //A3|Grain Waves|2.75|Chip
        [DataRow("A3", "Grain Waves", 2.75, "Chip")]

        //A4|Cloud Popcorn|3.65|Chip
        //B1|Moonpie|1.80|Candy
        //B2|Cowtales|1.50|Candy
        //B3|Wonka Bar|1.50|Candy
        [DataRow("B3", "Wonka Bar", 1.50, "Candy")]

        //B4|Crunchie|1.75|Candy
        //C1|Cola|1.25|Drink
        //C2|Dr.Salt|1.50|Drink
        [DataRow("C2", "Dr. Salt", 1.50, "Drink")]

        //C3|Mountain Melter|1.50|Drink
        //C4|Heavy|1.50|Drink
        //D1|U-Chews|0.85|Gum
        //D2|Little League Chew|0.95|Gum
        //D3|Chiclets|0.75|Gum
        [DataRow("D3", "Chiclets", 0.75, "Gum")]

        //D4|Triplemint|0.75|Gum


        public void RemoveItemTests_HappyPath(string coordinates, string name, double price, string type)
        {
            Purchasable expected;
            Purchasable actual;
            if (type == "Chip")
            {
                expected = new Chip(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);

            }
            else if (type == "Candy")
            {
                expected = new Candy(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);
            }
            else if (type == "Drink")
            {
                expected = new Drink(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);
            }
            else
            {
                expected = new Gum(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);
            }
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Coordinates, actual.Coordinates);
            Assert.AreEqual(expected.Message, actual.Message);


        }

        [DataTestMethod]
        [DataRow("D2", "Little League Chew", .95, "Gum")]
        [DataRow("B2", "Cowtales", 1.5, "Candy")]
        public void GetItemTests_HappyPath(string coordinates, string name, double price, string type)
        {
            Purchasable expected;
            Purchasable actual;
            if (type == "Chip")
            {
                expected = new Chip(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);

            }
            else if (type == "Candy")
            {
                expected = new Candy(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);
            }
            else if (type == "Drink")
            {
                expected = new Drink(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);
            }
            else
            {
                expected = new Gum(name, (decimal)price, coordinates);
                actual = FullGrid.RemoveItem(coordinates);
            }
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.Coordinates, actual.Coordinates);
            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}