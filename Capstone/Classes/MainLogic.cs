using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    public class MainLogic
    {  
        private string PathToReadFrom { get; set; }
        private string PathToWriteTo { get; set; }
        //Create the UI
        private UI UI { get; set; } = new UI();
        //Create the Grid
        private Grid Grid { get; set; } = new Grid(new Dictionary<string, Slot>());
        private FileReader FileReader
        {
            get
            {
                return new FileReader(PathToReadFrom);
            }
        }


        public MainLogic(string pathToReadFrom, string pathToWriteTo)
        {
            PathToReadFrom = pathToReadFrom;
            PathToWriteTo = pathToWriteTo;
        }

        public void StartUp()
        {
            //Get the items from the file
            List<string[]> items = FileReader.GetItemsFromFile();
            //Create Slots
            Grid.MakeSlots(items);

            UI.Reset();
            bool run = true;
            while (run)
            {
                run = MainMenu();
                if (run)
                {
                    PaymentMenu();
                }
            }
            UI.Reset();
            UI.Display("Thank you for your patronage.");
            UI.Blank();
        }
        //public List<string[]> GetItemsFromFile()
        //{
        //    List<string[]> output = new List<string[]>();
        //    try
        //    {
        //        using(StreamReader sr = new StreamReader(PathToReadFrom))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string line = sr.ReadLine();
        //                string[] item = line.Split('|');
        //                output.Add(item);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return output;
        //}
        public Slot CreateSlot(string[] input)
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
            Slot output = new Slot(item);
            return output;
        }
        public bool MainMenu()
        {
            bool proceedToPayment = false;
            bool runMain = true;
            while (runMain)
            {
                UI.Reset();
                UI.MainMenu();
                char input = UI.GetButtonPress("Enter Your Selection:");
                char[] options = { '1', '2', '3' };
                while (!options.Contains(input))
                {
                    UI.Reset();
                    UI.MainMenu();
                    input = UI.GetButtonPress("Invalid Selection, Please try again.:");
                }
                
                if (input == '1')
                {
                    UI.Reset();
                    UI.ShowItems(Grid);
                    UI.Blank();
                }
                else if (input == '2')
                {
                    proceedToPayment = true;
                    runMain = false;
                }
                else
                {
                    runMain = false;
                }
            }
            return proceedToPayment;
        }
        public void PaymentMenu()
        {
            PaymentManager pm = new PaymentManager(null, PathToWriteTo);
            bool runMain = true;
            while (runMain)
            {
                UI.Reset();
                UI.PurchaseMenu();
                UI.Display($"Current Money Provided: {pm.InternalBank.Money:C2}");
                char input = UI.GetButtonPress("Enter Your Selection:");
                char[] options = { '1', '2', '3' };
                while (!options.Contains(input))
                {
                    UI.Reset();
                    UI.PurchaseMenu();
                    input = UI.GetButtonPress("Invalid Selection, Please try again.:");
                }

                if (input == '1')
                {
                    UI.Reset();
                    string feed = UI.GetUserInput("Enter Amount to Deposit in Whole Dollar Amounts: ");
                    int result;
                    while (!int.TryParse(feed.Trim(), out result) || result < 0)
                    {
                        UI.Reset();
                        UI.Display("Invalid Entry! Please Try Again.");
                        feed = UI.GetUserInput("Enter Amount to Deposit in Whole Dollar Amounts: ");
                    }
                    pm.AddMoney(result);

                }
                else if (input == '2')
                {
                    UI.Reset();
                    UI.Display("Items:");
                    UI.ShowItems(Grid);
                    UI.Display($"Current Money Provided: {pm.InternalBank.Money:C2}");
                    UI.Display("Enter the Slot Code of the item you wish to buy. Enter 0 to cancel.");
                    string itemCoords = UI.GetUserInput("").Trim();
                    bool Cancel = false;
                    if (itemCoords == "0" || itemCoords == "")
                    {
                        Cancel = true;
                    }
                    while (!Grid.FindItem(itemCoords) && !Cancel)
                    {
                        UI.Reset();
                        UI.Display("Items:");
                        UI.ShowItems(Grid);
                        UI.Display("Invalid Entry, Please Try Again!");
                        UI.Display("Enter the Slot Code of the item you wish to buy. Enter 0 to cancel.");
                        itemCoords = UI.GetUserInput("");
                        if (itemCoords == "0" || itemCoords == "")
                        {
                            Cancel = true;
                        }
                    }
                    if (!Cancel)
                    {
                        if (Grid.GetItem(itemCoords.Trim().ToUpper()) != null)
                        {
                            pm.ChangeItem(Grid.GetItem(itemCoords.ToUpper().Trim()));
                            if (!pm.IsPaymentValid())
                            {
                                UI.Display("Not Enough Funds.");
                            }
                            else
                            {
                                UI.Reset();
                                Grid.RemoveItem(itemCoords);
                                UI.Display($"Here is your {pm.ItemToBuy.Name}.");
                                UI.Display($"You have {pm.InternalBank.Money:C2} left.");
                                UI.Display(pm.ItemToBuy.Message);
                            }
                        }
                        UI.Blank();
                    }
                }
                else
                {
                    //Get the change
                    //Print the change
                    UI.Reset();
                    UI.DisplayChange(pm.GetChange());
                    UI.Blank();
                    runMain = false;
                }
            }
        }
    }
}
