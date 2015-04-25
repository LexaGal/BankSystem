using System;
using System.ComponentModel;

namespace MvcMovie.Models
{
    public class AccountState
    {
        [DisplayName("BankID  ")]
        public string BankID { get; set; }

        [DisplayName("CardID  ")]
        public string CreditCardID { get; set; }

        [DisplayName("Pin  ")]
        public string PinCode { get; set; }

        [DisplayName("Card[rub.]  ")]
        public int CardMoney { get; set; }

        [DisplayName("Bank[rub.]  ")]
        public int BankMoney { get; set; }

        [DisplayName("Credit[rub.]  ")]
        public int CreditMoney { get; set; }

        [DisplayName("Bank[%]  ")]
        public int BankProcents { get; set; }

        [DisplayName("Credit[%]  ")]
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