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
        
        public ActionResult Index()
        {
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
            return RedirectToAction("Index");
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
    }
}