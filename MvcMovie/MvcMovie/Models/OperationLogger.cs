using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class OperationLogger
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Type  ")]
        public string OperationType { get; set; }

        [Required]
        [DisplayName("Source BankID  ")]
        public string SourceBankID { get; set; }

        [Required]
        [DisplayName("Source CardID  ")]
        public string SourceCardID { get; set; }

        [Required]
        [DisplayName("Destination BankID  ")]
        public string DestinationBankID { get; set; }

        [Required]
        [DisplayName("Destination CardID  ")]
        public string DestinationCardID { get; set; }

        [Required]
        [DisplayName("Money  ")]
        public int Money { get; set; }

        [Required]
        [DisplayName("Got credit sum  ")]
        public int GotCreditSum { get; set; }

        [Required]
        [DisplayName("Paid credit sum  ")]
        public int PaidCreditSum { get; set; }

    }
}