using System;

namespace MvcMovie.Models
{
    public class AccountState
    {
        public string BankID { get; set; }

        public string CreditCardID { get; private set; }

        public string PinCode { get; private set; }

        public int CardMoney { get; set; }

        public int BankMoney { get; set; }

        public int CreditMoney { get; set; }

        public int BankProcents { get; set; }

        public int CreditProcents { get; set; }

        public AccountState()
        {
            BankID = Guid.NewGuid().ToString().Substring(0, 8);

            PinCode = (((Guid.NewGuid().ToString())[0]) % 10).ToString() + ((Guid.NewGuid().ToString())[0]) % 10 
                + ((Guid.NewGuid().ToString())[0]) % 10 + ((Guid.NewGuid().ToString())[0]) % 10;

            CreditCardID = Guid.NewGuid().ToString().Substring(0, 8);
        }
        
        public AccountState(AccountState accountState)
        {
            BankID = accountState.BankID;
            CreditCardID = accountState.CreditCardID;
            PinCode = accountState.PinCode;
            CardMoney = accountState.CardMoney;
            BankMoney = accountState.BankMoney;
            CreditMoney = accountState.CreditMoney;
            BankProcents = accountState.BankProcents;
            CreditProcents = accountState.CreditProcents;
        }
    }
}