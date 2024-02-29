using System;
using Microsoft.EntityFrameworkCore;
using Wheelzy.Domain.Entities;

namespace Wheelzy.Infrastructure
{
	public class ApplicationDatabaseContext : DbContext
	{
        #region DbSets

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tracking> Trackings { get; set; }

        #endregion

        #region Constructor

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
		{
			//
		}

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBindingBrand(modelBuilder);
            modelBindingModel(modelBuilder);
            modelBindingSubmodel(modelBuilder);
            modelBindingBuyer(modelBuilder);
            modelBindingCar(modelBuilder);
            modelBindingOrder(modelBuilder);
            modelBindingStatus(modelBuilder);
            modelBindingTracking(modelBuilder);

            dataSeedingBuyer(modelBuilder);
            dataSeedingBrand(modelBuilder);
            dataSeedingModel(modelBuilder);
            dataSeedingSubmodel(modelBuilder);
            dataSeedingStatus(modelBuilder);
            dataSeedingCar(modelBuilder);
            dataSeedingOrder(modelBuilder);
            dataSeedingTracking(modelBuilder);
        }

        #region Models Binding

        private void modelBindingBrand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id);
        }

        private void modelBindingModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .ToTable("Models")
                .HasKey(b => b.Id);

            modelBuilder.Entity<Model>()
                .HasOne(m => m.Brand)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Model>()
                .HasIndex(c => c.BrandId)
                .IsUnique(false);
        }

        private void modelBindingSubmodel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submodel>()
                .ToTable("Submodels")
                .HasKey(b => b.Id);

            modelBuilder.Entity<Submodel>()
                .HasOne(m => m.Model)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Submodel>()
                .HasIndex(c => c.ModelId)
                .IsUnique(false);
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
                .HasOne(c => c.Make)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Submodel)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.MakeId).IsUnique(false);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.ModelId).IsUnique(false);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.SubmodelId).IsUnique(false);

            modelBuilder.Entity<Car>()
                .HasIndex(c => new { c.MakeId, c.ModelId, c.SubmodelId })
                .IsUnique(true);
        }

        private void modelBindingOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Order>()
                .HasOne(s => s.Buyer);

            modelBuilder.Entity<Order>()
                .HasOne(s => s.Car);

            modelBuilder.Entity<Order>()
                .HasOne(s => s.Status)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasIndex(s => s.CarId)
                .IsUnique(false);
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
                .HasOne(t => t.Order);

            modelBuilder.Entity<Tracking>()
                .HasOne(t => t.Status)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tracking>()
                .HasIndex(t => t.StatusId)
                .IsUnique(false);
        }

        #endregion

        #region Data seeding

        private void dataSeedingBrand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Description = "Ford" },
                new Brand() { Id = 2, Description = "Chrevrolet" }
            );
        }

        private void dataSeedingModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(
                new Model() { Id = 1, BrandId = 1, Description = "EcoSport" },
                new Model() { Id = 2, BrandId = 1, Description = "Focus" },
                new Model() { Id = 3, BrandId = 2, Description = "Cruze" },
                new Model() { Id = 4, BrandId = 2, Description = "Spark" }
            );
        }

        private void dataSeedingSubmodel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Submodel>().HasData(
                new Submodel() { Id = 1, ModelId = 1, Description = "Base" },
                new Submodel() { Id = 2, ModelId = 1, Description = "S" },
                new Submodel() { Id = 3, ModelId = 2, Description = "Base" },
                new Submodel() { Id = 4, ModelId = 2, Description = "Eco" }
            );
        }

        private void dataSeedingBuyer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>().HasData(
                new Buyer() { Id = 1, Name = "John", Amount = 800M },
                new Buyer() { Id = 2, Name = "George", Amount = 300M },
                new Buyer() { Id = 3, Name = "Sam", Amount = 500M }
            );
        }

        private void dataSeedingCar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, MakeId = 1, ModelId = 1, SubmodelId = 1, Year = 2018, ZipCode = 30033 },
                new Car() { Id = 2, MakeId = 1, ModelId = 2, SubmodelId = 2, Year = 2018, ZipCode = 20110 },
                new Car() { Id = 3, MakeId = 2, ModelId = 1, SubmodelId = 1, Year = 2018, ZipCode = 30315 },
                new Car() { Id = 4, MakeId = 2, ModelId = 2, SubmodelId = 2, Year = 2018, ZipCode = 22003 }
            );
        }

        private void dataSeedingStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status() { Id = 1, Description = "Pending" },
                new Status() { Id = 2, Description = "Acceptance" },
                new Status() { Id = 3, Description = "Accepted" },
                new Status() { Id = 4, Description = "Picked Up" }
            );
        }

        private void dataSeedingOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order() { Id = 1, CarId = 1, BuyerId = 1, StatusId = 1 },
                new Order() { Id = 2, CarId = 2, BuyerId = 2, StatusId = 4, PickedUpDate = new DateTime(2024, 02, 28) }
            );
        }

        private void dataSeedingTracking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracking>().HasData(
                new Tracking() { Id = 1, OrderId = 1, StatusId = 1, Timestamp = new DateTime(2024, 02, 28) },
                new Tracking() { Id = 2, OrderId = 2, StatusId = 1, Timestamp = new DateTime(2024, 02, 24) },
                new Tracking() { Id = 3, OrderId = 2, StatusId = 2, Timestamp = new DateTime(2024, 02, 24) },
                new Tracking() { Id = 4, OrderId = 2, StatusId = 3, Timestamp = new DateTime(2024, 02, 26) }
            );
        }

        #endregion
    }
}

