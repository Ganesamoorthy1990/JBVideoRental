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
    public class Movie_DetailsController : Controller
    {
        private JBVideo_RentalEntities1 db = new JBVideo_RentalEntities1();

        // GET: Movie_Details
        public ActionResult Index()
        {
            var movie_Details = db.Movie_Details.Include(m => m.Customer_Details);
            return View(movie_Details.ToList());
        }

        // GET: Movie_Details/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Details movie_Details = db.Movie_Details.Find(id);
            if (movie_Details == null)
            {
                return HttpNotFound();
            }
            return View(movie_Details);
        }

        // GET: Movie_Details/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email");
            return View();
        }

        // POST: Movie_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie_Id,Id,Movie_Name,Genre,Birth_Date,Movies_In_Stock,Movies_Availablility,Account_Number,Video_File,Is_Subscribed_To_Newletter,Is_Deleted,Create_Time_Stamp,Update_Time_Stamp")] Movie_Details movie_Details)
        {
            if (ModelState.IsValid)
            {
                db.Movie_Details.Add(movie_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", movie_Details.Id);
            return View(movie_Details);
        }

        // GET: Movie_Details/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Details movie_Details = db.Movie_Details.Find(id);
            if (movie_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", movie_Details.Id);
            return View(movie_Details);
        }

        // POST: Movie_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movie_Id,Id,Movie_Name,Genre,Birth_Date,Movies_In_Stock,Movies_Availablility,Account_Number,Video_File,Is_Subscribed_To_Newletter,Is_Deleted,Create_Time_Stamp,Update_Time_Stamp")] Movie_Details movie_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Customer_Details, "Id", "Email", movie_Details.Id);
            return View(movie_Details);
        }

        // GET: Movie_Details/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_Details movie_Details = db.Movie_Details.Find(id);
            if (movie_Details == null)
            {
                return HttpNotFound();
            }
            return View(movie_Details);
        }

        // POST: Movie_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Movie_Details movie_Details = db.Movie_Details.Find(id);
            db.Movie_Details.Remove(movie_Details);
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
