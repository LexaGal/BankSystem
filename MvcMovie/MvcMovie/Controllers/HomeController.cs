using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CurrencyConvertor(FormCollection form)
        {
            var FromList = new List<string> { "USD", "EUR", "BLR", "RUB"};
            var ToList = new List<string> { "USD", "EUR", "BLR", "RUB" };

            ViewBag.From = new SelectList(FromList);
            ViewBag.To = new SelectList(ToList);

            string from = form["From"];
            string to = form["To"];
            string sum = form["SumFrom"];

            CurrencyConvertor currencyConvertor = new CurrencyConvertor();
            string sumReturn = null;

            foreach (var item in currencyConvertor.Coefficients)
            {
                if (item.Item1 == from && item.Item2 == to)
                {
                    sumReturn = (double.Parse(sum)*item.Item3).ToString();
                }
                ViewBag.From = from;
                ViewBag.To = to;
                ViewBag.SumReturn = sumReturn;
                ViewBag.Sum = sum;
            }

            return View();
        }

    }
}