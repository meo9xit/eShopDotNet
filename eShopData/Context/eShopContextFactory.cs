using eShopData.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Context
{
    public class eShopContextFactory : IDesignTimeDbContextFactory<eShopContext>
    {
        public eShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<eShopContext>();
            optionsBuilder.UseSqlServer(DbContextHelper.GetConnectionString());
            return new eShopContext(optionsBuilder.Options);
        }
    }
}
