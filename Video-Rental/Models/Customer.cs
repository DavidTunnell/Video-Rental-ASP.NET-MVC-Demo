using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Video_Rental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //Example of how to override Enitity Framework data conventions with data annotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        //The Entity framework detects the naming convention below and treats it at the foreign key for the above entity/model type.
        public int MembershipTypeId { get; set; }
    }
}