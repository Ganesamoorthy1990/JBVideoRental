using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBVideoRental.ViewModel
{
    public class Movie_Details_ViewModel
    {
        public string Movie_Name { get; set; }
        public string Genre { get; set; }
        public System.DateTime Birth_Date { get; set; }
        public string Account_Number { get; set; }
        public string Video_File { get; set; }
        public bool Is_Subscribed_To_Newletter { get; set; }
    }
}