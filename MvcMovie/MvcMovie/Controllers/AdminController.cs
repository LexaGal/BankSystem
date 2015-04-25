using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Search(FormCollection form)
        {
            var namesList = new List<string>();

            var namesQry = from d in ClientsController.DataBase.Clients
                           orderby d.SecondName
                           select d.SecondName;

            namesList.AddRange(namesQry.Distinct());
            ViewBag.surname = new SelectList(namesList);

            var clients = ClientsController.DataBase.Clients.ToList();

            string name = form["name"];
            string surname = form["surname"];

            if (!String.IsNullOrEmpty(name))
            {
                clients = clients.Where(s => s.FirstName.Contains(name)).ToList();
            }

            if (string.IsNullOrEmpty(surname))
            {
                if (!clients.Any())
                {
                    ModelState.AddModelError("surname", "No clients found. Some data is wrong");
                }

                return View(clients);
            }

            clients = clients.Where(x => x.SecondName == surname).ToList();

            if (!clients.Any())
            {
                ModelState.AddModelError("surname", "No clients found. Some data is wrong");
            }

            return View(clients);
            
            return View(ClientsController.DataBase.Clients.ToList());
        }

        public ActionResult Index()
        {
            if (ClientsController.DataBase == null)
            {
                ClientsController.DataBase = new ClientsDbContext();
            }

            return View(ClientsController.DataBase.Clients.ToList());
        }

        
        public ActionResult Details(int id = 0)
        {
            Client client = ClientsController.DataBase.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        
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
                List<Client> list = ClientsController.DataBase.Clients.ToList();
                var bankClient = list.Any(p => String.CompareOrdinal(p.Email, client.Email) == 0);

                if (bankClient)
                {
                    ModelState.AddModelError("Email", "Such email is already used");
                    return View(client);
                }
                
                ClientsController.DataBase.Clients.Add(client);
                ClientsController.DataBase.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            return View(client);
        }

        public ActionResult Edit(int id = 0)
        {
            Client client = ClientsController.DataBase.Clients.Find(id);
            
            if (client == null)
            {
                return HttpNotFound();
            }
            
            return View(client);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                List<Client> list = ClientsController.DataBase.Clients.ToList();
                var bankClient = list.Any(p => String.CompareOrdinal(p.Email, client.Email) == 0);

                if (bankClient)
                {
                    ModelState.AddModelError("Email", "Such email is already used");
                    return View(client);
                }
             
                ClientsController.DataBase.Entry(client).State = EntityState.Modified;
                ClientsController.DataBase.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Delete(int id = 0)
        {
            Client client = ClientsController.DataBase.Clients.Find(id);
            
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
            Client client = ClientsController.DataBase.Clients.Find(id);
            ClientsController.DataBase.Clients.Remove(client);
            ClientsController.DataBase.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }


        [HttpPost, ActionName("Get")]
        [ValidateAntiForgeryToken]
        public ActionResult Get(RouteValueDictionary rvd)
        {
            Client client = new Client();
            
            return RedirectToAction("Create", "Admin", new RouteValueDictionary(client));
        }

        protected override void Dispose(bool disposing)
        {
            //ClientsController.DataBase.Dispose();
            //base.Dispose(disposing);
        }


        public ActionResult OperationsLog()
        {
            if (ClientsController.DataBase == null)
            {
                ClientsController.DataBase = new ClientsDbContext();
            }

            return View(ClientsController.DataBase.Operations.ToList());
        }

        public ActionResult DeleteLog(int id = 0)
        {
            OperationLogger logger = ClientsController.DataBase.Operations.Find(id);

            if (logger == null)
            {
                return HttpNotFound();
            }
            return View(logger);
        }


        [HttpPost, ActionName("DeleteLog")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLogConfirmed(int id)
        {
            OperationLogger logger = ClientsController.DataBase.Operations.Find(id);
            ClientsController.DataBase.Operations.Remove(logger);
            ClientsController.DataBase.SaveChanges();
            return RedirectToAction("OperationsLog", "Admin");
        }

    }
}