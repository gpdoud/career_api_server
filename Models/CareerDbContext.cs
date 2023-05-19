using System;
using Microsoft.EntityFrameworkCore;

namespace career_api_server.Models {

    public class CareerDbContext : DbContext {

        public DbSet<User> Users { get; set; }

        public CareerDbContext(DbContextOptions<CareerDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) {
        }
    }
}

