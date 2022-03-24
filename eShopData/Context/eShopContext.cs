using eShopData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Context
{
    public class eShopContext : IdentityDbContext<User,Role, Guid>
    {
        public eShopContext(DbContextOptions<eShopContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_login").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_token").HasKey(x => x.UserId);
        }
    }
}
