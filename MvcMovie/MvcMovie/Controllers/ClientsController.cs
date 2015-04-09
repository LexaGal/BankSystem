using System;
using System.Activities;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ClientsController : Controller
    {
        public static ClientsDbContext DataBase = new ClientsDbContext();
        
        public ActionResult Index(RouteValueDictionary rvd)
        {
            object x;
            rvd.TryGetValue("id", out x);
            
            Client client = new Client();
            if (x != null)
            {
                client = DataBase.Clients.Find(int.Parse(x.ToString()));
            }

            return View(client);
        }

        //-------------------------------------------------------------------------------------------------

        public ActionResult LogIn()
        {
            Client client = new Client(); 
            return View(client);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Client client)
        {
            if (ModelState.IsValid)
            {
                if (client.FirstName == "a" &&
                    client.SecondName == "a" &&
                    client.Password == "a")
                {
                    return RedirectToAction("Index", "Admin");
                }
                
                var c = client;
                var clients = from d in DataBase.Clients
                         where d.FirstName == c.FirstName &&
                         d.SecondName == c.SecondName &&
                         d.Password == c.Password
                         select d;

                if (clients.Count() == 1)
                {
                    client = clients.First();

                    RouteValueDictionary rvd = new RouteValueDictionary(client);
                
                    return  RedirectToAction("Index", "Clients", rvd);
                }
                
                ModelState.AddModelError("Password" ,"Some data is wrong");
            }

            return View(client);
        }

        //-------------------------------------------------------------------------------------------------

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 

            Client client = DataBase.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //-------------------------------------------------------------------------------------------------

        public ActionResult Create()
        {
            Client client = new Client();
            
            return View(client);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                List<Client> list = DataBase.Clients.ToList();
                var bankClient = list.Any(p => String.CompareOrdinal(p.Email, client.Email) == 0);
                
                if (bankClient)
                {
                    ModelState.AddModelError("Email", "Such email is already used");
                    return View(client);
                }
                
                DataBase.Clients.Add(client);
                DataBase.SaveChanges();

                RouteValueDictionary rvd = new RouteValueDictionary(client);
                    
                return RedirectToAction("Index", "Clients", rvd);
            }

            return View(client);
        }

        //-------------------------------------------------------------------------------------------------
        
        public ActionResult Edit(int id = 0)
        {
            Client client = DataBase.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            
            return View(client);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection client)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(client["id"]);

                Client currClient = DataBase.Clients.ToList().First(c => c.ID == id);

                List<Client> list = DataBase.Clients.ToList();
                var bankClient = list.Any(p => String.CompareOrdinal(p.Email, client["Email"]) == 0 && p.ID != id);

                if (bankClient)
                {
                    ModelState.AddModelError("Email", "Such email is already used");
                    return View("Edit", currClient);
                }


                if (currClient != null)
                {
                    currClient.FirstName = client["FirstName"];
                    currClient.SecondName = client["SecondName"];
                    currClient.Email = client["Email"];
                    currClient.Password = client["Password"];
                    currClient.AccountType = client["AccountType"];
                }

                DataBase.Entry(currClient).State = EntityState.Modified;
                DataBase.SaveChanges();

                return RedirectToAction("Index", "Clients", new RouteValueDictionary(currClient));
            }

            return View(DataBase.Clients.Find(client));
        }

        //-------------------------------------------------------------------------------------------------

        public ActionResult Delete(int id = 0)
        {
            Client client = DataBase.Clients.Find(id);
            
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = DataBase.Clients.Find(id);
            
            DataBase.Clients.Remove(client);
            DataBase.SaveChanges();
            
            return RedirectToAction("LogIn");
        }

        //-------------------------------------------------------------------------------------------------

        public ActionResult SearchIndex(string secondName, string firstName)
        {
            var namesList = new List<string>();

            var namesQry = from d in DataBase.Clients
                           orderby d.SecondName
                           select d.SecondName;
            
            namesList.AddRange(namesQry.Distinct());
            ViewBag.secondName = new SelectList(namesList);

            var clients = from m in DataBase.Clients
                         select m;

            if (!String.IsNullOrEmpty(firstName))
            {
                clients = clients.Where(s => s.FirstName.Contains(firstName));
            }

            if (string.IsNullOrEmpty(secondName))
            {
                if (!clients.Any())
                {
                    ModelState.AddModelError("secondName", "No clients found. Some data is wrong");
                }
                return View(clients);
            }

            var returnClients = clients.Where(x => x.SecondName == secondName);
            if (!returnClients.Any())
            {
                ModelState.AddModelError("secondName", "No clients found. Some data is wrong");
            }

            return View(returnClients);
            
        }

        //-------------------------------------------------------------------------------------------------

        protected override void Dispose(bool disposing)
        {
            //DataBase.Dispose();
            //base.Dispose(disposing);
        }

        //-------------------------------------------------------------------------------------------------

        public ActionResult Operations()
        {
            return View();
        }

        public ActionResult PutMoney()
        {
            Client client = new Client();
            int sum = 0;
            Tuple<Client, int> tuple = new Tuple<Client, int>(client, sum);

            return View(tuple);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PutMoney(Tuple<Client, int> tuple)
        {
            List<Client> list = DataBase.Clients.ToList();

            var bankClient = list.First(p => String.CompareOrdinal(p.State.BankID, tuple.Item1.State.BankID) == 0);

            if (bankClient == null)
            {
                ModelState.AddModelError("BankID", "No such ID");
                return View(tuple);
            }

            if (tuple.Item2 <= 0 || tuple.Item2 > 100000000)
            {
                ModelState.AddModelError("Summ to put: ", "Wrong summ");
                return View(tuple);
            }

            MoneyOperation moneyOperation = new MoneyOperation(bankClient);
            moneyOperation.PutMoney(tuple.Item2);

            DataBase.Entry(bankClient).State = EntityState.Modified;

            return RedirectToAction("PutMoney", "Clients");
        }

        public ActionResult TransferMoney()
        {
            throw new NotImplementedException();
        }
    }
}