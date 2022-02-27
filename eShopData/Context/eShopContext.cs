using eShopData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Context
{
    public class eShopContext : DbContext
    {
        public eShopContext(DbContextOptions<eShopContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
