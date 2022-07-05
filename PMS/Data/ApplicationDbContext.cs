using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PMS.Models;

namespace PMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PMS.Models.purchasing> purchasing { get; set; }
        public DbSet<PMS.Models.Customer> customers { get; set; }
        public DbSet<PMS.Models.Medicine> medicines { get; set; }
    }
}
