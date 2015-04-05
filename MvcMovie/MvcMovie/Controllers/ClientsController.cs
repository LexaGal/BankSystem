using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
        
        private ClientsDbContext db = new ClientsDbContext();

        //
        // GET

        public ActionResult Index(RouteValueDictionary rvd)
        {
            
            object x;
            rvd.TryGetValue("id", out x);
            
            Client client = new Client();
            client = db.Clients.Find(int.Parse(x.ToString()));

            return View(client);
        }

        //
        // GET

        public ActionResult LogIn()
        {
            Client client = new Client(); 
            return View(client);
        }

        //
        // POST

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


                var clients = from d in db.Clients
                         where d.FirstName == client.FirstName &&
                         d.SecondName == client.SecondName &&
                         d.Password == client.Password
                         select d;

                if (clients.Count() == 1)
                {
                    client = clients.First();

                    RouteValueDictionary rvd = new RouteValueDictionary(client);
                    return  RedirectToAction("Index", "Clients", rvd);
                }

                 //return new HttpNotFoundResult();
            
                ModelState.AddModelError("Password" ,"Some data is wrong");
            }

            return View(client);
        }

        //
        // GET: /Clients/Details/

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 

            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            Client client = new Client();
            
            return View(client);
        }

        //
        // POST: /Clients/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            client.State.PinCode = (new Random()).Next(1000, 9999).ToString();
            client.State.CardID = Guid.NewGuid().ToString().Substring(0, 8);
            client.State.BankProcents = (new Random()).Next(1, 25);

            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                RouteValueDictionary rvd = new RouteValueDictionary(client);
                    
                return RedirectToAction("Index", "Clients", rvd);
            }

            return View(client);
        }

        //
        // GET: /Clients/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            
            return View(client);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RouteValueDictionary rvd)
        {
            object x;
            rvd.TryGetValue("id", out x);
                
            if (ModelState.IsValid)
            {
                db.Entry(db.Clients.Find(x)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", rvd);
            }
            
            return View(db.Clients.Find(x));
        }

        //
        // GET: /Clients/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            
            db.Clients.Remove(client);
            db.SaveChanges();
            
            return RedirectToAction("LogIn");
        }

        public ActionResult SearchIndex(string secondName, string firstName)
        {
            var namesList = new List<string>();

            var namesQry = from d in db.Clients
                           orderby d.SecondName
                           select d.SecondName;
            
            namesList.AddRange(namesQry.Distinct());
            ViewBag.secondName = new SelectList(namesList);

            var clients = from m in db.Clients
                         select m;

            if (!String.IsNullOrEmpty(firstName))
            {
                clients = clients.Where(s => s.FirstName.Contains(firstName));
            }

            if (string.IsNullOrEmpty(secondName))
            {
                if (!clients.Any())
                {
                    return new EmptyResult();
                    //ModelState.AddModelError("secondName", "No clients found. Some data is wrong");
                }
                return View(clients);
            }

            var returnClients = clients.Where(x => x.SecondName == secondName);
            if (!returnClients.Any())
            {
                return new EmptyResult();
            }

            return View(clients);
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}