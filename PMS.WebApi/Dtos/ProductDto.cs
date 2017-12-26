using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.WebApi.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Code is required")]
        [MinLength(6, ErrorMessage = "Product code min length is 6 characters")]
        public string ProductCode { get; set; }

        [MaxLength(265)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        [Range(1, Double.MaxValue, ErrorMessage = "Product Min Price must be gratter then or equal 1")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product Name is Required", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "Product Name Min Length is 5 Characters")]
        [MaxLength(30, ErrorMessage = "Product Name Max Length is 30 Characters")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

    }
}