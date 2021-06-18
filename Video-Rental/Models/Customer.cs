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
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        // When using labels in views it will use this name as opposed to the property name
        [Display(Name = "Date of Birth")]
        [Min18YrsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        //The Entity framework detects the naming convention below and treats it at the foreign key for the above entity/model type.
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}