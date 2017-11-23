using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Web;
using PMS.WebApi.Models;

namespace PMS.WebApi.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }
     
       
    }
}