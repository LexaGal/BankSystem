using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ValidationContext = System.Activities.Validation.ValidationContext;

namespace MvcMovie.Models
{
    public class AccountState
    {
        public string CardID { get; set; }

        public string PinCode { get; set; }

        public int CardMoney { get; set; }

        public int BankMoney { get; set; }

        public int CreditMoney { get; set; }

        public int BankProcents { get; set; }

        public int CreditProcents { get; set; }

    }
}