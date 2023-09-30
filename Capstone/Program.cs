using System;
using System.IO;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create MainLogic Class
            MainLogic logic = new MainLogic(Directory.GetCurrentDirectory() + $"../../../../../vendingmachine.csv",
            Directory.GetCurrentDirectory() + "/Log.txt");
            //Start the program
            logic.StartUp();
        }
    }
}
