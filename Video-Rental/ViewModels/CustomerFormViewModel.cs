using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental.Models;

namespace Video_Rental.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}