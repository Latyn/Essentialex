using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Essentialex.ViewModels.Law;

namespace Essentialex.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<LawViewModel>();
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Law> Laws { get; set; }
        public DbSet<Law> LawViewModel { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{

        //    var connString = Startup.Configuration["Data:WorldContextConnection"];
        //    optionBuilder.UseSqlServer(connString);

        //    base.OnConfiguring(optionBuilder);
        //}
    }
}
