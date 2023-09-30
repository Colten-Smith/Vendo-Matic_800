using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Bank
    {
        /// <summary>
        /// The amount of money in the bank.
        /// </summary>
        public decimal Money { get; private set; }
        /// <summary>
        /// A storage system for money.
        /// </summary>
        /// <param name="money">The initial balance of the bank.</param>
        public Bank(decimal money)
        {
            Money = money;
        }
        /// <summary>
        /// Withdraws money from the bank.
        /// </summary>
        /// <param name="amountToWithdraw">The amount to be withdrawn from the bank.</param>
        /// <returns>The money withdrawn. Returns zero if the withdraw amount is too high.</returns>
        public decimal Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw <= Money && amountToWithdraw > 0)
            {
                Money -= amountToWithdraw;
                return amountToWithdraw;
            }
            return 0;
        }
        /// <summary>
        /// Adds money too the bank.
        /// </summary>
        /// <param name="amountToDeposit">The amount of money to add to the bank.</param>
        /// <returns>Returns true if the deposit is valid, false if it is not.</returns>
        public bool Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit > 0)
            {
                Money += amountToDeposit;
                return true;
            }
            return false;
            
        }
    }
}
