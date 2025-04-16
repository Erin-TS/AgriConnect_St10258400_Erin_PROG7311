using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect_St10258400_Erin_PROG7311.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }


        // setting  the database tables
        public DbSet<UserModel> User { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<FarmerModel> Farmer { get; set; }


        //Configuring tables to what is needed in the database
        //establishes table relationships like one to one or one to many
        //configures the primary keys for each table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // establishing one to one relationship : user to employee
            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e => e.user)
                .WithOne(u => u.Employee)
                .HasForeignKey<EmployeeModel>(e => e.userId)
                .OnDelete(DeleteBehavior.Restrict);

            // establishing one to one relationship : user to farmer
            modelBuilder.Entity<FarmerModel>()
                .HasOne(f => f.user)
                .WithOne(u => u.Farmer)
                .HasForeignKey<FarmerModel>(f => f.userId)
                .OnDelete(DeleteBehavior.Restrict);

            //establishing one to many relationship : farmer to product
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.farmer)
                .WithMany(f => f.FarmerProducts)
                .HasForeignKey(p => p.farmerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
