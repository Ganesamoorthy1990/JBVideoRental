using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JBVideoRental.Models;

namespace JBVideoRental.Controllers
{
    public class Customer_DetailsController : Controller
    {
        private JBVideo_RentalEntities1 db = new JBVideo_RentalEntities1();

        // GET: Customer_Details
        public ActionResult Index()
        {
            var customer_Details = db.Customer_Details.Include(c => c.Customer_Details1).Include(c => c.Customer_Details2);
            return View(customer_Details.ToList());
        }

        // GET: Customer_Details/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // GET: Customer_Details/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email");
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email");
            return View();
        }

        // POST: Customer_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Password_Hash,Security_Stamp,Phone_Number,Aadhar_Number,Is_Deleted,Create_Time_Stamp,Update_Time_Stamp")] Customer_Details customer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Details.Add(customer_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", customer_Details.Id);
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", customer_Details.Id);
            return View(customer_Details);
        }

        // GET: Customer_Details/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", customer_Details.Id);
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", customer_Details.Id);
            return View(customer_Details);
        }

        // POST: Customer_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Password_Hash,Security_Stamp,Phone_Number,Aadhar_Number,Is_Deleted,Create_Time_Stamp,Update_Time_Stamp")] Customer_Details customer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", customer_Details.Id);
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", customer_Details.Id);
            return View(customer_Details);
        }

        // GET: Customer_Details/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // POST: Customer_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            db.Customer_Details.Remove(customer_Details);
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
