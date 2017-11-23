using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PMS.WebApi.Infrastructure;
using PMS.WebApi.Models;

namespace PMS.WebApi.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;
        //get/api/customers\
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Product> GetCustomers()
        {
            IEnumerable<Product> products = new List<Product>();
            try
            {
                products =_context.Products.ToList();
            }
            catch (Exception exception)
            {
                HttpResponseMessage Response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                throw  new HttpResponseException(Response);
             
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            try
            {
                product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            }
            catch (Exception exception)
            {
                HttpResponseMessage Response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                throw new HttpResponseException(Response);
            }
            if (product == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;

        }
    }
}
