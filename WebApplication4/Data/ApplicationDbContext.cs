using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<WebApplication4.Models.TodoViewModel> todoViewModels { get; set; }
        public DbSet<WebApplication4.Models.CategoryViewModel> categoryViewModels { get; set; }
    }
}
