using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCMChurch.Models
{
    public class ViewModel
    {
        public IEnumerable<Member> Member { get; set; }
        public IEnumerable<Address> Address { get; set; }
    }
}