using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBVideoRental.Models;

namespace JBVideoRental.ViewModel
{
    public class Customer_Details_ViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long Phone_Number { get; set; }
        public string Aadhar_Number { get; set; }
    }
}