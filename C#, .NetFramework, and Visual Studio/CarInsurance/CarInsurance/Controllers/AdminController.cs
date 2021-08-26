using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();
        private object dateOfBirth;

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                //This is where the quote is determined
                //First I set a vaiable for the current day and the base value for the quote
                DateTime today = DateTime.Today;
                decimal quote = 50;
                //Set the value for an age variable to be equal to today's year minus the person's DOB
                int age = today.Year - insuree.DateOfBirth.Year;
                //Age is checked against a couple of if statments that determine whether to add more money to the quote
                if (age <= 18)
                {
                    quote = quote + 100;
                }
                else if (age > 18 && age < 25)
                {
                    quote = quote + 50;
                }
                else
                {
                    quote = quote + 25;
                }
                //if the car is too old or too new it will cost more
                if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
                {
                    quote = quote + 25;
                }
                //checks to see if the car is a Porche and if it is a 911 Carrera Porsche
                if (insuree.CarMake == "Porsche")
                {
                    quote = quote + 25;
                }
                if (insuree.CarMake == "Porsche" && insuree.CarModel == "911 Carrera")
                {
                    quote = quote + 25;
                }
                //each speeding ticket costs 10 extra dollars so the number of speeding tickets they have is multiplied by ten and that is added to the quote cost
                decimal x = Convert.ToDecimal(insuree.SpeedingTickets * 10);
                quote = quote + x;
                //if they have a DUI then their total is increased by 25%. If they selected FullCoverage then in is increased by 50%
                if (insuree.DUI == true)
                {
                    quote = (quote / 4) * 5;
                }
                if (insuree.CoverageType == true)
                {
                    quote = (quote / 2) * 3;
                }
                //changes are saved to database and then we are taken to the Admin Index page to view the current list of quotes and names stored
                insuree.Quote = quote;
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
