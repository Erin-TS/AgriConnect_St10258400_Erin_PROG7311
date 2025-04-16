using AgriConnect_St10258400_Erin_PROG7311.Models;
using System.Data.Entity;

namespace AgriConnect_St10258400_Erin_PROG7311.Data
{
    public class AppDbContext: DbContext
    {
        //create and name database
        public AppDbContext() : base("name=AgriEnergyConnectDB")
        {
        }

        // setting  the database tables
        public DbSet<UserModel> User { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<FarmerModel> Farmer { get; set; }


        //Configuring tables to what is needed in the database
        //establishes table relationships like one to one or one to many
        //configures the primary keys for each table
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key for the UserModel
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.userId);

            // Configure the primary key for the ProductModel
            //one to many relationship: farmer to product
            modelBuilder.Entity<ProductModel>()
                .HasKey(p => p.productID)
                .HasRequired(p => p.farmer)
                .WithMany(f => f.FarmerProducts) // One farmer can have many products
                .HasForeignKey(p => p.farmerId) // Foreign key in ProductModel
                .WillCascadeOnDelete(false);

            // Configure the primary key for the EmployeeModel
            //one to one relationship: user to employee
            modelBuilder.Entity<EmployeeModel>()
                .HasKey(e => e.employeeId)
                .HasRequired(e => e.user)
                .WithOptional(u => u.Employee)
                .WillCascadeOnDelete(false);

            // Configure the primary key for the FarmerModel
            //one to one relationship: user to farmer
            modelBuilder.Entity<FarmerModel>()
                .HasKey(f => f.farmerId)
                .HasRequired(f => f.user)
                .WithOptional(u => u.Farmer)
                .WillCascadeOnDelete(false); // Prevent cascade delete
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
