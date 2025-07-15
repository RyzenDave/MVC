using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Data;
using VROS.Domain;

namespace VROS.DataAccess
{
    public class VROSDbContext : DbContext
    {
        public VROSDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cast> Cast { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Cast>()
                .HasData(StaticDb.Cast);

            modelBuilder.Entity<Movie>()
                .HasData(StaticDb.Movies);

            modelBuilder.Entity<Rental>()
                .HasData(StaticDb.Rentals);

            modelBuilder.Entity<User>()
                .HasData(StaticDb.Users);

        }
    }
}
