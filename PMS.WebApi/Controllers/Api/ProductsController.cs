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
      
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
          //get/api/products/
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
        //get/api/products/1
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

        //Post  /api/products
        [HttpPost]
        public Product CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;

        }
        //PUT /api/products/1
        [HttpPut]
        public void UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            

            try
            {
                var ProductInDB = _context.Products.SingleOrDefault(p => p.ProductId == id);
                
                if (ProductInDB == null)
                {
                    throw  new HttpResponseException(HttpStatusCode.NotFound);
                    
                }

                ProductInDB.ProductName = product.ProductName;
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                HttpResponseMessage Response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                throw new HttpResponseException(Response);
            }
        }
        //Delete /api/products/1

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            try
            {
                var ProductInDB = _context.Products.SingleOrDefault(p => p.ProductId == id);

                if (ProductInDB == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                }


                _context.Products.Remove(ProductInDB);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                HttpResponseMessage Response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                throw new HttpResponseException(Response);
            }
        }
    }
}
