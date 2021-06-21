using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Video_Rental.Models;

namespace Video_Rental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YrsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }
    }
}