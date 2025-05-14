/*this is the database context class that is used to interact with the database and 
intialse tables and seed data. The table relationships are also creted here*/
/*Refrence links
 *https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
 *https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
 *https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0
 *https://www.pragimtech.com/blog/blazor/asp.net-core-rest-api-dbcontext/
 *https://www.youtube.com/watch?v=wE8cW_Fn0mU
 */

//------Imports------//
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//------Namespace------//
namespace AgriConnect_St10258400_Erin_PROG7311.Data
{
    //------Class------//
    public class AppDbContext : DbContext
    {
        //------Constructor------//
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }


        // setting  the database tables
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<FarmerModel> Farmer { get; set; }



        /*this method is called when the database is created
        Configuring tables to what is needed in the database
        establishes table relationships like one to one or one to many
        configures the primary keys for each table
        seeds intial data to the database*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //establishing one to many relationship so a farmer  can have many products
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.farmer)
                .WithMany(f => f.FarmerProducts)
                .HasForeignKey(p => p.farmerId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
