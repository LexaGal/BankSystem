using System;
using System.ComponentModel;
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
        [DisplayName("Name  ")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Surname  ")]
        public string SecondName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Account  ")]
        public string AccountType { get; set; }

        public AccountState State { get; set; }

        public Client(Client client)
        {
            ID = client.ID;
            FirstName = client.FirstName;
            SecondName = client.SecondName;
            Email = client.Email;
            Password = client.Password;
            AccountType = client.AccountType;

            State = new AccountState(client.State);

        }
    }

}