using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class PaymentManagerTests
    {
        [DataTestMethod]
        [DataRow(50, 100, true, 50)] // enough money in bank
        [DataRow(100, 50, false, 50)] // not enough money in bank
        [DataRow(0, 0, true, 0)] // zero price and money
        public void IsPaymentValid_Validations(int itemPrice, int bankMoney, bool expectedIsValid, int expectedMoneyAfterTransaction)
        {
            Candy itemToBuy = new Candy("", itemPrice, "");
            PaymentManager paymentManager = new PaymentManager(itemToBuy, @"C:\Users\Student\workspace\pairs\c-sharp-minicapstonemodule1-team1\Capstone\bin\Debug\netcoreapp3.1\Log.txt");
            paymentManager.InternalBank.Deposit(bankMoney);
            bool result = paymentManager.IsPaymentValid();
            Assert.AreEqual(expectedIsValid, result);
            Assert.AreEqual(expectedMoneyAfterTransaction, paymentManager.InternalBank.Money);
        }

        [TestMethod]
        public void AddMoney_IncreasesBankBalance()
        {
            PaymentManager paymentManager = new PaymentManager(null, @"C:\Users\Student\workspace\pairs\c-sharp-minicapstonemodule1-team1\Capstone\bin\Debug\netcoreapp3.1\Log.txt");
            decimal initialBalance = paymentManager.InternalBank.Money;
            decimal moneyFed = 20;
            decimal result = paymentManager.AddMoney((int)moneyFed);
            Assert.AreEqual(initialBalance + moneyFed, result);
        }
        [TestMethod]
        public void ChangeItem_ChangesItemToBuy()
        {
            PaymentManager paymentManager = new PaymentManager(null, @"C:\Users\Student\workspace\pairs\c-sharp-minicapstonemodule1-team1\Capstone\bin\Debug\netcoreapp3.1\Log.txt");
            Candy item = new Candy("", 10, "");
            paymentManager.ChangeItem(item);
            Assert.AreEqual(item, paymentManager.ItemToBuy);
        }
    }
}
