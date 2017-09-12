using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JBVideoRental.Models;
using JBVideoRental.ViewModel;
using System.Data.Entity.Infrastructure;

namespace JBVideoRental.Controllers
{
    public class Customer_DetailsController : Controller
    {
 JBVideo_RentalEntities1 db = new JBVideo_RentalEntities1();
        // GET: Customer_Details

        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                Customer_Details cd = db.Customer_Details.Find(id);
                var viewmodel = new Customer_Details_ViewModel
                {
                    Email = cd.Email,
                    Password = cd.Password,
                    Phone_Number = cd.Phone_Number,
                    Aadhar_Number = cd.Aadhar_Number

                };
                return View(viewmodel);
            }
            return View();
        }

       public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer_Details_ViewModel customer)
        {
            var login = (from n in db.Customer_Details where !n.Is_Deleted & n.Email == customer.Email & n.Password == customer.Password select n).Count();
            long id = (from n in db.Customer_Details where !n.Is_Deleted & n.Email == customer.Email & n.Password == customer.Password select n.Id).SingleOrDefault();
            if (login==1 & id==1)
            {
                return RedirectToAction("Details");
            }
            else if(login == 1 & id!=0)
            {
                return RedirectToAction("Create");
            }
                return View();
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int? id, Customer_Details_ViewModel cv)
        {
            Customer_Details cd = new Customer_Details();
            cd.Email = cv.Email;
            cd.Password = cv.Password;
            cd.Phone_Number = cv.Phone_Number;
            cd.Aadhar_Number = cv.Aadhar_Number;
            if (id == null)
            {
                db.SP_NewUser(cd.Email, cd.Password, cd.Phone_Number, cd.Aadhar_Number);

            }
            else
            {
                db.SP_UpdateCustomer(id, cd.Email, cd.Password, cd.Phone_Number, cd.Aadhar_Number);
            }
            db.SaveChanges();
            return RedirectToAction("Home");
        }



        public ActionResult Details()
        {
            int count = (from register in db.Customer_Details where !register.Is_Deleted select register).Count();
            ViewBag.Total = count;
            var CustomerDetails = from register in db.Customer_Details where !register.Is_Deleted select register;
            return View(CustomerDetails);
        }

        public ActionResult Delete(long? id)
        {
            db.SP_DeleteCustomer(id);
            db.SaveChanges();
            return RedirectToAction("Details");
        }


        
    }
}
