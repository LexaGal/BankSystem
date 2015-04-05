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
        private ClientsDbContext db = new ClientsDbContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            Client client = new Client();

            return View(client);
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                client.State.PinCode = (new Random()).Next(1000, 9999).ToString();
                client.State.CardID = Guid.NewGuid().ToString().Substring(0, 8);

                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

            return View(client);
        }

        //
        // GET: /Admin/Edit/5

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
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Admin/Delete/5

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
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Get")]
        [ValidateAntiForgeryToken]
        public ActionResult Get(RouteValueDictionary rvd)
        {
            Client client = new Client();
            client.State.PinCode = (new Random()).Next(1000, 9999).ToString();
            client.State.CardID = Guid.NewGuid().ToString().Substring(0, 8);

            return RedirectToAction("Create", "Admin", new RouteValueDictionary(client));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}