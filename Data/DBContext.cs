using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TShirtCompany.Models;

namespace TShirtCompany.Models
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //           => options.UseSqlite("Data Source=blogging.db");
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        //public DbSet<TShirtCompany.Models.RegisterViewModel> RegisterViewModel { get; set; }

        //public DbSet<TShirtCompany.Models.LoginViewModel> LoginViewModel { get; set; }

        //public DbSet<TShirtCompany.Models.OrderRequestVM> OrderRequestVM { get; set; }

        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<>
        //}

    }
}
