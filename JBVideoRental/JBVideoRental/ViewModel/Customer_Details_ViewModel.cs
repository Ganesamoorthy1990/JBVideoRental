using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBVideoRental.Models;
using System.ComponentModel.DataAnnotations;

namespace JBVideoRental.ViewModel
{
    public class Customer_Details_ViewModel
    {
        public long Id { get; set; }
    
       // (ErrorMessage = "Email is required")
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name="Phone Number")]
        public long Phone_Number { get; set; }
        [Display(Name = "Aadhar Number ")]
        public string Aadhar_Number { get; set; }
    }
}