using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_Rental.Dtos;
using Video_Rental.Models;

namespace Video_Rental.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //map model to data transform object and vice versa
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}