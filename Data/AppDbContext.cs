/*this is the database context class that is used to interact with the database and 
intialse tables and seed data. The table relationships are also creted here*/
/*Refrence links
 *https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
 *https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
 *https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0
 *https://www.pragimtech.com/blog/blazor/asp.net-core-rest-api-dbcontext/
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


            //-----Seeding the database with initial data-----//
            //Farmers
            modelBuilder.Entity<FarmerModel>().HasData(
                new FarmerModel
                {
                    farmerId = 1,
                    farmerLocation = "Paarl",
                    farmerEmail = "j.m@gmail.com",
                    farmerFirstName = "Jack",
                    farmerLastName = "Mcdonald",
                    farmerPasswordHash = new PasswordHasher<FarmerModel>().HashPassword(null, "Pass1234!"),
                    farmerRole = "Farmer",
                    farmerPassword = "Pass1234!"

                },
                new FarmerModel
                {
                    farmerId = 2,
                    farmerLocation = "Cape Town",
                    farmerEmail = "p.l@gmail.com",
                    farmerFirstName = "Penny",
                    farmerLastName = "Leaf",
                    farmerPasswordHash = new PasswordHasher<FarmerModel>().HashPassword(null, "Pass1234!"),
                    farmerRole = "Farmer",
                    farmerPassword = "Pass1234!"
                },
                new FarmerModel
                {
                    farmerId = 3,
                    farmerLocation = "Stenllenbosch",
                    farmerEmail = "m.v@gmail.com",
                    farmerFirstName = "Max",
                    farmerLastName = "Verstappen",
                    farmerPasswordHash = new PasswordHasher<FarmerModel>().HashPassword(null, "Pass1234!"),
                    farmerRole = "Farmer",
                    farmerPassword = "Pass1234!"
                },
                new FarmerModel
                {
                    farmerId = 3,
                    farmerLocation = "Onrus",
                    farmerEmail = "l.b@gmail.com",
                    farmerFirstName = "Lilly",
                    farmerLastName = "Brown",
                    farmerPasswordHash = new PasswordHasher<FarmerModel>().HashPassword(null, "Pass1234!"),
                    farmerRole = "Farmer",
                    farmerPassword = "Pass1234!"
                }
            );

            //Empoloyees
            modelBuilder.Entity<EmployeeModel>().HasData(
                new EmployeeModel
                {
                    employeeId = 1,
                    employeeFirstName = "Erin",
                    employeeNumber = "1234567890",
                    employeeEmail = "e.s@gmail.com",
                    employeeLastName = "Steenveld",
                    employeePasswordHash = new PasswordHasher<EmployeeModel>().HashPassword(null, "Abcd1234!"),
                },
                new EmployeeModel
                {
                    employeeId = 1,
                    employeeFirstName = "Clive",
                    employeeNumber = "0987654321",
                    employeeEmail = "c.f@gmail.com",
                    employeeLastName = "Frankland",
                    employeePasswordHash = new PasswordHasher<EmployeeModel>().HashPassword(null, "Abcd1234@"),
                }
                );

            //Products
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    productID = 1,
                    productName = "Potatoes",
                    productCategory = ProductCategory.Vegetables,
                    productDescription = "Freshly harvested potatoes",
                    productionDate = DateTime.Now,
                    farmerId = 1
                },
                new ProductModel
                {
                    productID = 2,
                    productName = "Carrots",
                    productCategory = ProductCategory.Vegetables,
                    productDescription = "Freshly harvested  orange carrorts",
                    productionDate = DateTime.Now,
                    farmerId = 1
                },
                new ProductModel
                {
                    productID = 3,
                    productName = "Radish",
                    productCategory = ProductCategory.Vegetables,
                    productDescription = "Freshly harvested baby radish",
                    productionDate = DateTime.Now,
                    farmerId = 1
                },
                new ProductModel
                {
                    productID = 4,
                    productName = "Chicken",
                    productCategory = ProductCategory.Poultry,
                    productDescription = "Whole Free range chickens",
                    productionDate = DateTime.Now,
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 5,
                    productName = "Brown Eggs",
                    productCategory = ProductCategory.Eggs,
                    productDescription = "Free range eggs",
                    productionDate = DateTime.Now,
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 6,
                    productName = "Apples",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Big red gala apples",
                    productionDate = DateTime.Now,
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 7,
                    productName = "Bananas",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Freshly harvested bananas",
                    productionDate = DateTime.Now,
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 8,
                    productName = "Grapes",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Freshly harvested grapes",
                    productionDate = DateTime.Now,
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 9,
                    productName = "Peaches",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Freshly harvested peaches",
                    productionDate = DateTime.Now,
                    farmerId = 4
                }
                , new ProductModel
                {
                    productID = 10,
                    productName = "Parsely",
                    productCategory = ProductCategory.Herbs,
                    productDescription = "large leaf parsely",
                    productionDate = DateTime.Now,
                    farmerId = 1
                }
                , new ProductModel
                {
                    productID = 11,
                    productName = "Rosemary",
                    productCategory = ProductCategory.Herbs,
                    productDescription = "Freshly harvested rosemary",
                    productionDate = DateTime.Now,
                    farmerId = 2
                }
                , new ProductModel
                {
                    productID = 12,
                    productName = "Thyme",
                    productCategory = ProductCategory.Herbs,
                    productDescription = "Freshly harvested thyme",
                    productionDate = DateTime.Now,
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 13,
                    productName = "Jersey Milk",
                    productCategory = ProductCategory.Dairy,
                    productDescription = "Pasurised  cow milk",
                    productionDate = DateTime.Now,
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 14,
                    productName = "Goats Milk",
                    productCategory = ProductCategory.Dairy,
                    productDescription = "Pasurised goats milk",
                    productionDate = DateTime.Now,
                    farmerId = 4
                }
                , new ProductModel
                {
                    productID = 15,
                    productName = "Brie Cheese",
                    productCategory = ProductCategory.Dairy,
                    productDescription = " Long fermented brie cheese",
                    productionDate = DateTime.Now,
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 16,
                    productName = "White eggs free range",
                    productCategory = ProductCategory.Eggs,
                    productDescription = "White chicken free range eggs",
                    productionDate = DateTime.Now,
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 17,
                    productName = "Bacon",
                    productCategory = ProductCategory.Meat,
                    productDescription = "Free range bacon",
                    productionDate = DateTime.Now,
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 18,
                    productName = "Beef steaks",
                    productCategory = ProductCategory.Meat,
                    productDescription = "Free range beef",
                    productionDate = DateTime.Now,
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 19,
                    productName = "Rye Flour",
                    productCategory = ProductCategory.Grains,
                    productDescription = "finley ground rye flour",
                    productionDate = DateTime.Now,
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 20,
                    productName = "Wheat Flour",
                    productCategory = ProductCategory.Grains,
                    productDescription = "finley ground wheat flour",
                    productionDate = DateTime.Now,
                    farmerId = 4
                }
                , new ProductModel
                {
                    productID = 21,
                    productName = "Oats",
                    productCategory = ProductCategory.Grains,
                    productDescription = "finley ground oats",
                    productionDate = DateTime.Now,
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 22,
                    productName = "Pumkin seeds",
                    productCategory = ProductCategory.Seeds,
                    productDescription = "Raw pumkin seeds",
                    productionDate = DateTime.Now,
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 23,
                    productName = "Sunflower seeds",
                    productCategory = ProductCategory.Seeds,
                    productDescription = "Raw sunflower seeds",
                    productionDate = DateTime.Now,
                    farmerId = 3
                }
            );
        }
    }
}
