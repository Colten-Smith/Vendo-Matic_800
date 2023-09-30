using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class PaymentManager
    {   
        public  Purchasable ItemToBuy { get; private set; }
        public Bank InternalBank { get; private set; } = new Bank(0);
        public string FullFilePath { get; private set; }
        public LogManager LogManager
        {
            get
            {
                return new LogManager(FullFilePath);
            }
        }
        public PaymentManager(Purchasable itemToBuy, string fullFilePath)
        {
            ItemToBuy = itemToBuy;
            FullFilePath = fullFilePath;
        }



        public bool IsPaymentValid()
        {
            if (ItemToBuy.Price <= InternalBank.Money)
            {
                InternalBank.Withdraw(ItemToBuy.Price);
                LogManager.LogTransaction(ItemToBuy.Name + " " + ItemToBuy.Coordinates, ItemToBuy.Price, InternalBank.Money);
                return true;
            }
            else
            {
                return false;
            }
        }
         public decimal AddMoney(int moneyFed)
         {
            InternalBank.Deposit(moneyFed);
            LogManager.LogTransaction("FEED MONEY", moneyFed, InternalBank.Money);
            return InternalBank.Money;
         }
       
       
        public List <Coin> GetChange()
        {
            Coin quarter = new Coin("Quarter", .25M);
            Coin dime = new Coin("Dime", .10M);
            Coin nickle = new Coin("Nickle", .05M);
            Coin penny = new Coin("Penny", .01M);
            Coin[] coins = { quarter, dime, nickle, penny };
            List<Coin> output = new List<Coin>();
            decimal change = InternalBank.Money;
            decimal initialChange = change;
            foreach(Coin coin in coins)
            {
                while(change >= coin.Value)
                {
                    change -= coin.Value;
                    output.Add(coin);
                }
                InternalBank.Withdraw(InternalBank.Money);
            }
            LogManager.LogTransaction("GIVE CHANGE", initialChange, 0);
            return output;
        }
        //private void LogTransaction(string type, decimal difference, decimal balance)
        //{
        //    try
        //    {
        //        using(StreamWriter sw = new StreamWriter(FullFilePath, true))
        //        {
        //            sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {type} ${difference} ${balance}");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }      
        //}
        public void ChangeItem(Purchasable item)
        {
            ItemToBuy = item;
        }
    }    
}
