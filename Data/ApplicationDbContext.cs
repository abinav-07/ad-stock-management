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
    }
}
