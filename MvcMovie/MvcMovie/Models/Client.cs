using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Web.Http.ModelBinding.Binders;

namespace MvcMovie.Models
{
    public class Client
    {
        public Client()
        {
            State = new AccountState();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string AccountType { get; set; }

        public AccountState State { get; set; }

    }

}