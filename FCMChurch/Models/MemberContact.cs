//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FCMChurch.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberContact
    {
        public long MemberContactID { get; set; }
        public long MemberID { get; set; }
        public long EmailID { get; set; }
        public long PhoneID { get; set; }
        public long AddressID { get; set; }
        public long StateNameID { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Email Email { get; set; }
        public virtual Member Member { get; set; }
        public virtual Phone Phone { get; set; }
        public virtual StateName StateName { get; set; }
    }
}
