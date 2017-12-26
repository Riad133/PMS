using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
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
        [ResponseType(typeof(ProductDto))]
          //get/api/products/
        public IHttpActionResult GetCustomers()
        {
       
            IEnumerable<ProductDto> productDtos = new List<ProductDto>();
            try
            {
                productDtos =_context.Products.ToList().Select(Mapper.Map<Product,ProductDto>);
                return Ok(productDtos);
            }
            catch (Exception exception)
            {
                HttpResponseMessage Response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                throw  new HttpResponseException(Response);
             
            }
            
        }
        [ResponseType(typeof(ProductDto))]
        //get/api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            
            Product product = new Product();
            if (id ==0)
            {
                product.ProductId = 0;
                product.ReleaseDate= DateTime.Today.Date;
                return Ok( Mapper.Map<Product, ProductDto>(product));
            }
            try
            {
               
                product = _context.Products.SingleOrDefault(p => p.ProductId == id);
                
                
            }
            catch (Exception exception)
            {
                //HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                //    exception.InnerException.Message);
                return InternalServerError(exception);

            }
            if (product == null)
            {
                return NotFound();
            }
            return Ok( Mapper.Map<Product,ProductDto>(product));
           

        }
        [ResponseType(typeof(ProductDto))]
        //Post  /api/products
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = Mapper.Map<ProductDto, Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();
            productDto.ProductId = product.ProductId;
            return Created(new Uri(Request.RequestUri +"/"+product.ProductId),productDto );

        }
        [ResponseType(typeof(ProductDto))]
        //PUT /api/products/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            try
            {
                var ProductInDB = _context.Products.SingleOrDefault(p => p.ProductId == id);
                
                if (ProductInDB == null)
                {
                    return NotFound();

                }

                Mapper.Map<ProductDto, Product>(productDto, ProductInDB);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception exception)
            {
                
                HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                responseMessage.Headers.Location= new Uri(Request.RequestUri+"/"+productDto.ProductId);
                IHttpActionResult response = ResponseMessage(responseMessage);
                return response;
            }
        }
        //Delete /api/products/1

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                var ProductInDB = _context.Products.SingleOrDefault(p => p.ProductId == id);

                if (ProductInDB == null)
                {
                    return NotFound(); 

                }


                _context.Products.Remove(ProductInDB);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception exception)
            {
                HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    exception.InnerException.Message);
                IHttpActionResult resposnse = ResponseMessage(responseMessage);
                return resposnse;
            }
        }
    }
}
