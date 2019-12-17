using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSBI_test.Models;
using CSBI_test.Areas.Identity.Data;

namespace CSBI_test.Data
{
    public class ApplicationDbContext : IdentityDbContext<Manager>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<CSBI_test.Models.Task> Task { get; set; }
    }
}
