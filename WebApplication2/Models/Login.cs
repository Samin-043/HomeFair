//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Login
    {
        public string Usename { get; set; }
        public string Login_Password { get; set; }
        public Nullable<int> Admin_id { get; set; }
    
        public virtual Admin Admin { get; set; }
    }
}