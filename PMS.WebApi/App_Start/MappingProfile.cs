using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PMS.WebApi.Dtos;
using PMS.WebApi.Models;

namespace PMS.WebApi.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}