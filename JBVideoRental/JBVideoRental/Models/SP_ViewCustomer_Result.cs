//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JBVideoRental.Models
{
    using System;
    
    public partial class SP_ViewCustomer_Result
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password_Hash { get; set; }
        public string Security_Stamp { get; set; }
        public long Phone_Number { get; set; }
        public string Aadhar_Number { get; set; }
        public bool Is_Deleted { get; set; }
        public System.DateTime Create_Time_Stamp { get; set; }
        public Nullable<System.DateTime> Update_Time_Stamp { get; set; }
    }
}