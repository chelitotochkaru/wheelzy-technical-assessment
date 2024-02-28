using System;
using Microsoft.EntityFrameworkCore;
using Wheelzy.Domain.Entities;

namespace Wheelzy.Infrastructure
{
	public class ApplicationDatabaseContext : DbContext
	{
        #region DbSets

        DbSet<Brand> Brands { get; set; }
        DbSet<Buyer> Buyers { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Sell> Sells { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Tracking> Trackings { get; set; }

        #endregion

        #region Constructor

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
		{
			//
		}

        #endregion

        #region Models Binding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBindingBrand(modelBuilder);
            modelBindingBuyer(modelBuilder);
            modelBindingCar(modelBuilder);
            modelBindingSell(modelBuilder);
            modelBindingStatus(modelBuilder);
            modelBindingTracking(modelBuilder);
        }

        private void modelBindingBrand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id);
        }

        private void modelBindingBuyer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Buyer>()
                .Property(b => b.Amount)
                .HasColumnType("DECIMAL(5,2)");
        }

        private void modelBindingCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Make);
        }

        private void modelBindingSell(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sell>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.Buyer);

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.Car);

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.Status)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }

        private void modelBindingStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasKey(b => b.Id);
        }

        private void modelBindingTracking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracking>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Tracking>()
                .HasOne(t => t.Sell);

            modelBuilder.Entity<Tracking>()
                .HasOne(t => t.Status)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}

