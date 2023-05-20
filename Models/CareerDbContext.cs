using System;
using Microsoft.EntityFrameworkCore;

namespace career_api_server.Models {

    public class CareerDbContext : DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<CompanyMaster> CompanyMasters { get; set; }

        public CareerDbContext(DbContextOptions<CareerDbContext> options) : base(options) {
            //this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
        }
    }
}

