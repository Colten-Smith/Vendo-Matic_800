using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {
        public string[] HUD = { "=====================================================================================================================================",
        "    __________________",
        "   /                 /|",
        "  /_________________/ |",
        " |  ____________   |  |",
        " |$|[][][][][][]|  |  |  _   _                _            ___  ___      _   _        _____ _____  _____ ",
        " |%|[][][][][][]|  |  | | | | |              | |           |  \\/  |     | | (_)      |  _  |  _  ||  _  |",
        " |&|[][][][][][]|  |  | | | | | ___ _ __   __| | ___ ______| .  . | __ _| |_ _  ___   \\ V /| |/' || |/' |",
        " |*|[][][][][][]|##|  | | | | |/ _ \\ '_ \\ / _` |/ _ \\______| |\\/| |/ _` | __| |/ __|  / _ \\|  /| ||  /| |",
        " |~|[][][][][][]|##|  | \\ \\_/ /  __/ | | | (_| | (_) |     | |  | | (_| | |_| | (__  | |_| \\ |_/ /\\ |_/ /",
        " |  ___________    |  |  \\___/ \\___|_| |_|\\__,_|\\___/      \\_|  |_/\\__,_|\\__|_|\\___| \\_____/\\___/  \\___/ ",
        " | /___________\\   | / ",
        " |_________________|/",
        "====================================================================================================================================="};

        private string[] _MainMenu = { "(1) Display Vending Machine Items", "(2) Purchase", "(3) Exit" };
        private string[] _PurchaseMenu = { "(1) Feed Money", "(2) Select Product", "(3) Finish Transaction" };
        private string _Border = "=====================================================================================================================================";
        public void Reset()
        {
            Console.Clear();
            foreach(string line in HUD)
            {
                Console.WriteLine(line);
            }
        }
        public void Blank()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue");
            Console.ReadKey(true);
        }
        public void Border()
        {
            Console.WriteLine(_Border);
        }
        public void MainMenu()
        {
            foreach(string line in _MainMenu)
            {
                Console.WriteLine(line);
            }
            Border();
        }
        public void PurchaseMenu()
        {
            foreach(string line in _PurchaseMenu)
            {
                Console.WriteLine(line);
            }
            Border();
        }
        public void ShowItems(Grid grid)
        {
            foreach (Slot item in grid.ItemDict.Values)
            {
                Console.Write(item.ItemStored.Coordinates + " ");
                Console.Write(item.ItemStored.Name + " ");
                if(item.Quantity > 0)
                {
                    Console.WriteLine(item.ItemStored.Price);
                }
                else
                {
                    Console.WriteLine("SOLD OUT");
                }
            }
            Border();
        }
        public string GetUserInput(string display)
        {
            Console.Write(display + " > ");
            string userInput = Console.ReadLine();
            return userInput;
        }
        public char GetButtonPress(string display)
        {
            Console.Write(display + " > ");
            char userInput = Console.ReadKey().KeyChar;
            return userInput;
        }
        public void Display(string toDisplay)
        {
            Console.WriteLine(toDisplay);
        }
        public void DisplayChange(List<Coin> coins)
        {
            string coinName = "Quarter";
            int count = 0;
            Display("Change:");
            foreach(Coin coin in coins)
            {
                if(coin.Name == coinName)
                {
                    count++;
                }
                else
                {
                    if (count == 1) 
                    {
                        Console.WriteLine($"{count} {coinName}");
                    }
                    else
                    {
                        Console.WriteLine($"{count} {coinName}s");
                    }
                    coinName = coin.Name;
                    count = 1;
                }
            }
            if (count != 0)
            {

                if (count == 1)
                {
                    Console.WriteLine($"{count} {coinName}");
                }
                else if (coinName == "Penny")
                {
                    Console.WriteLine($"{count} Pennies");
                }
                else
                {
                    Console.WriteLine($"{count} {coinName}s");
                }
            }
        }
    }
}
