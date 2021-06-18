using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Video_Rental.Models
{
    public class Min18YrsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                //validate is a success
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
            {
                //indicates an error and returns message
                return new ValidationResult("Birthdate is required.");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to be on a membership.");
        }
    }
}