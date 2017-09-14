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
        public DateTime dt;
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var dc = from c in db.Customer_Details where c.Is_Deleted == false select c;
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

        public ActionResult Home()
        {
            return View();
        }
        // GET: Appointments/Edit/5
        public ActionResult Edit(long? id)
        {
            var employeeId = Session["employeeId"] != null ? Convert.ToInt32(Session["employeeId"]) : 0;
            if (employeeId==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details appointment = db.Customer_Details.Find(employeeId);
            //var cd = from s in db.Customer_Details where s.Id == employeeId select s.Create_Time_Stamp;
          
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
        public JsonResult EditProfile(FormCollection Form,Customer_Details_ViewModel cus )
        {
            var employeeId = Session["employeeId"] != null ? Convert.ToInt32(Session["employeeId"]) : 0;
           // Customer_Details cus = new Customer_Details();
            long id = cus.Id;
           
            cus.Aadhar_Number= Form["Aadhar_Number"];
            cus.Email = Form["Email"];
            cus.Password = Form["Password"];
            cus.Phone_Number = long.Parse(Form["Phone_Number"]);
            Customer_Details appointment = db.Customer_Details.Find(employeeId);
            db.SP_UpdateCustomer(id, cus.Email, cus.Password, cus.Phone_Number, cus.Aadhar_Number);
            db.SaveChanges();
            return Json(cus, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer_Details_ViewModel appointment)
        {
            //if (ModelState.IsValid)
            //{

                Customer_Details custom = new Customer_Details();
            long id = appointment.Id;
                custom.Email = appointment.Email;
                custom.Password = appointment.Password;
                custom.Phone_Number = appointment.Phone_Number;
                custom.Aadhar_Number = appointment.Aadhar_Number;
                custom.Update_Time_Stamp = DateTime.Now;
            // db.Entry(custom).State = EntityState.Modified;
                db.SP_UpdateCustomer(id, custom.Email, custom.Password, custom.Phone_Number, custom.Aadhar_Number);
                db.SaveChanges();
            TempData["message"] = "Your Message";
            return RedirectToAction("SendMessage");
            //return View("Home");
            //}
           // return View(appointment);
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
            if (login == 1 & id == 1)
            {
                Session["employeeId"] = id;
                return View("Home");
               
            } 
            else if(login == 1 & id!=0)
            {
                return View("../User/UserHome");
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

        public bool CheckEmail(string Email_Id, string Password)
        {
            bool emailExit = false;
            if (!string.IsNullOrEmpty(Email_Id) || !string.IsNullOrEmpty(Password))
            {
                emailExit = db.Customer_Details.Any(x => x.Email == Email_Id && x.Password == Password);
                //emailExit = true;
            }
            return emailExit;



        }
        public JsonResult CheckEmailExistOrNot(string Email_Id, string Password)
        {

            return Json(CheckEmail(Email_Id, Password), JsonRequestBehavior.AllowGet);
        }



    }
}
