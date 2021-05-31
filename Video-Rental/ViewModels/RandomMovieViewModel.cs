using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental.Models;

namespace Video_Rental.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movies { get; set; }
        public List<Customer> Customers { get; set; }
    }
}