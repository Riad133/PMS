using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PMS.WebApi.Dtos;
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
        public IEnumerable<ProductDto> GetCustomers()
        {
            IEnumerable<ProductDto> productDtos = new List<ProductDto>();
            try
            {
                productDtos =_context.Products.ToList().Select(Mapper.Map<Product,ProductDto>);
                return productDtos;
            }
            catch (Exception exception)
            {
                HttpResponseMessage Response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                throw  new HttpResponseException(Response);
             
            }
            
        }
        //get/api/products/1
        public ProductDto GetProduct(int id)
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
            return Mapper.Map<Product,ProductDto>(product);
           

        }

        //Post  /api/products
        [HttpPost]
        public ProductDto CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var product = Mapper.Map<ProductDto, Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();
            return productDto;

        }
        //PUT /api/products/1
        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
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

                Mapper.Map<ProductDto, Product>(productDto, ProductInDB);
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
