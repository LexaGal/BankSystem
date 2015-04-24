using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ClientsListController : Controller
    {
        //
        // GET: /ClientsList/
        public ActionResult AllClients(string surname, string name)
        {
            var namesList = new List<string>();

            var namesQry = from d in ClientsController.DataBase.Clients
                orderby d.SecondName
                select d.SecondName;

            namesList.AddRange(namesQry.Distinct());
            ViewBag.surname = new SelectList(namesList);

            IQueryable<Client> queryable = from c in ClientsController.DataBase.Clients
                select c;

            var enumerable = (from c in ClientsController.DataBase.Clients
                //select new Client(c)).ToList();

                select new Client
                {
                    ID = c.ID,
                    FirstName = c.FirstName,
                    SecondName = c.SecondName,
                    Email = c.Email,
                    Password = c.Password,
                    AccountType = c.AccountType,

                    State = new AccountState
                    {
                        BankID = c.State.BankID,
                        BankMoney = c.State.BankMoney,
                        BankProcents = c.State.BankProcents,
                        CardMoney = c.State.CardMoney,
                        PinCode = c.State.PinCode,
                        CreditCardID = c.State.CreditCardID,
                        CreditProcents = c.State.CreditProcents,
                        CreditMoney = c.State.CreditMoney,
                    }
                });

            ClientsList cl = new ClientsList {Clients = new List<Client>(queryable.AsEnumerable())};

            return View(cl);
        }
    }
}
