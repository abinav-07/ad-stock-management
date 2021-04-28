using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GroupCourseWork.Models;

namespace GroupCourseWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GroupCourseWork.Models.Category> Category { get; set; }
        public DbSet<GroupCourseWork.Models.Product> Product{ get; set; }
        public DbSet<GroupCourseWork.Models.ProductStock> ProductStock { get; set; }

        public DbSet<GroupCourseWork.Models.Customer> Customer { get; set; }
        public DbSet<GroupCourseWork.Models.Purchase> Purchase { get; set; }
        public DbSet<GroupCourseWork.Models.PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<GroupCourseWork.Models.Sales> Sales { get; set; }
        public DbSet<GroupCourseWork.Models.SalesDetail> SalesDetail { get; set; }
        public DbSet<GroupCourseWork.Models.User> User { get; set; }
        public DbSet<GroupCourseWork.Models.Role> Role { get; set; }
        public DbSet<GroupCourseWork.Models.UserRole> UserRole { get; set; }
    }
}
