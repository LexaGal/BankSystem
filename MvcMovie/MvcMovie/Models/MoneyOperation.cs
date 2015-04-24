using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class MoneyOperation
    {
        private Client CurrentClient { get; set; }
        
        public MoneyOperation(Client client)
        {
            CurrentClient = client;
        }

        public void PutMoney(int money)
        {
            CurrentClient.State.BankMoney += money;
        }
        
        public void TrasferMoneyToCard(int money)
        {
            CurrentClient.State.CardMoney += money;
            CurrentClient.State.BankMoney -= money;
        }

        public void TrasferMoneyFromCard(int money)
        {
            CurrentClient.State.CardMoney -= money;
            CurrentClient.State.BankMoney += money;
        }

        public void TransferMoneyFromBankIDToBankID(int money, Client client)
        {
            CurrentClient.State.BankMoney -= money;
            client.State.BankMoney += money;
        }

        public void TakeCredit(int money)
        {
            CurrentClient.State.CreditMoney += money;
        }

        public void UpdateBankMoney(int money)
        {
            CurrentClient.State.BankMoney += CurrentClient.State.BankMoney * CurrentClient.State.BankProcents / 100;
        }

        public void UpdateCreditMoney(int money)
        {
            CurrentClient.State.CreditMoney += CurrentClient.State.CreditMoney * CurrentClient.State.CreditProcents / 100;
        }

        public bool PayCredit(int sum)
        {
            if (CurrentClient.State.BankMoney < sum)
            {
                return false;
            }

            CurrentClient.State.BankMoney -= sum;
            CurrentClient.State.CreditMoney -= sum;

            return true;
        }
    }
}