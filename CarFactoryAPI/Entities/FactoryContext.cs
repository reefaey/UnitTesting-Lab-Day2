using CarAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactoryAPI.Entities
{
    public class FactoryContext : DbContext
    {


        public FactoryContext() { }
        public FactoryContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UnitTest_Intake44_MNF;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne<Owner>(c => c.Owner)
                .WithOne(o => o.Car);
            modelBuilder.Entity<Car>().Property(c => c.OwnerId).IsRequired(false);
            modelBuilder.Entity<Car>()
                .HasIndex(car => car.VIN) // Indexes the VIN property
                .IsUnique(); // Marks the index as unique;

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
    }
}
