using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.WebApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }

        [MaxLength(265)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        [MaxLength(256)]
        public string ProductName { get; set; }

        public DateTime ReleaseDate  { get; set; }

        public string ImageUrl { get; set; }

        

    }
}