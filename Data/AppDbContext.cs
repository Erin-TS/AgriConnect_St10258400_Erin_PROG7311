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
                    farmerPasswordHash = "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==",
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
                    farmerPasswordHash = "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==",
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
                    farmerPasswordHash = "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==",
                    farmerRole = "Farmer",
                    farmerPassword = "Pass1234!"
                },
                new FarmerModel
                {
                    farmerId = 4,
                    farmerLocation = "Onrus",
                    farmerEmail = "l.b@gmail.com",
                    farmerFirstName = "Lilly",
                    farmerLastName = "Brown",
                    farmerPasswordHash = "AQAAAAIAAYagAAAAEANU33h/MGee9PzXT11T3ttuLMaRyucNSwTVig0eSlovR5RbKRsbc7j7GQvsydQjKA==",
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
                    employeePasswordHash = "AQAAAAIAAYagAAAAEAtucICMr/9Qo7oY64ZKjuDNQl4o4IEKTGLnIg2me6gWsT/igV3gX74Rq5fCfXf+tw==",
                },
                new EmployeeModel
                {
                    employeeId = 2,
                    employeeFirstName = "Clive",
                    employeeNumber = "0987654321",
                    employeeEmail = "c.f@gmail.com",
                    employeeLastName = "Frankland",
                    employeePasswordHash = "AQAAAAIAAYagAAAAEJsmEhWsXodkJ0v9yjYctFqboVA3gwmODW59YFnf2fXa9Wz2mE1CUJigmXMZZGxfxw==",
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
                    productionDate = new DateTime(2025, 5, 5, 0, 0, 0, 0),
                    farmerId = 1
                },
                new ProductModel
                {
                    productID = 2,
                    productName = "Carrots",
                    productCategory = ProductCategory.Vegetables,
                    productDescription = "Freshly harvested  orange carrorts",
                    productionDate = new DateTime(2025, 5, 10, 0, 0, 0, 0),
                    farmerId = 1
                },
                new ProductModel
                {
                    productID = 3,
                    productName = "Radish",
                    productCategory = ProductCategory.Vegetables,
                    productDescription = "Freshly harvested baby radish",
                    productionDate = new DateTime(2025, 4, 28, 0, 0, 0, 0),
                    farmerId = 1
                },
                new ProductModel
                {
                    productID = 4,
                    productName = "Chicken",
                    productCategory = ProductCategory.Poultry,
                    productDescription = "Whole Free range chickens",
                    productionDate = new DateTime(2025, 5, 5, 0, 0, 0, 0),
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 5,
                    productName = "Brown Eggs",
                    productCategory = ProductCategory.Eggs,
                    productDescription = "Free range eggs",
                    productionDate = new DateTime(2025, 5, 6, 0, 0, 0, 0),
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 6,
                    productName = "Apples",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Big red gala apples",
                    productionDate = new DateTime(2025, 5, 7, 0, 0, 0, 0),
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 7,
                    productName = "Bananas",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Freshly harvested bananas",
                    productionDate = new DateTime(2025, 5, 8, 0, 0, 0, 0),
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 8,
                    productName = "Grapes",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Freshly harvested grapes",
                    productionDate = new DateTime(2025, 5, 10, 0, 0, 0, 0),
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 9,
                    productName = "Peaches",
                    productCategory = ProductCategory.Fruits,
                    productDescription = "Freshly harvested peaches",
                    productionDate = new DateTime(2025, 5, 13, 0, 0, 0, 0),
                    farmerId = 4
                }
                , new ProductModel
                {
                    productID = 10,
                    productName = "Parsely",
                    productCategory = ProductCategory.Herbs,
                    productDescription = "large leaf parsely",
                    productionDate = new DateTime(2025, 5, 14, 0, 0, 0, 0),
                    farmerId = 1
                }
                , new ProductModel
                {
                    productID = 11,
                    productName = "Rosemary",
                    productCategory = ProductCategory.Herbs,
                    productDescription = "Freshly harvested rosemary",
                    productionDate = new DateTime(2025, 4, 28, 0, 0, 0, 0),
                    farmerId = 2
                }
                , new ProductModel
                {
                    productID = 12,
                    productName = "Thyme",
                    productCategory = ProductCategory.Herbs,
                    productDescription = "Freshly harvested thyme",
                    productionDate = new DateTime(2025, 5, 1, 0, 0, 0, 0),
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 13,
                    productName = "Jersey Milk",
                    productCategory = ProductCategory.Dairy,
                    productDescription = "Pasurised  cow milk",
                    productionDate = new DateTime(2025, 5, 3, 0, 0, 0, 0),
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 14,
                    productName = "Goats Milk",
                    productCategory = ProductCategory.Dairy,
                    productDescription = "Pasurised goats milk",
                    productionDate = new DateTime(2025, 5, 3, 0, 0, 0, 0),
                    farmerId = 4
                }
                , new ProductModel
                {
                    productID = 15,
                    productName = "Brie Cheese",
                    productCategory = ProductCategory.Dairy,
                    productDescription = " Long fermented brie cheese",
                    productionDate = new DateTime(2025, 5, 14, 0, 0, 0, 0),
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 16,
                    productName = "White eggs free range",
                    productCategory = ProductCategory.Eggs,
                    productDescription = "White chicken free range eggs",
                    productionDate = new DateTime(2025, 4, 29, 0, 0, 0, 0),
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 17,
                    productName = "Bacon",
                    productCategory = ProductCategory.Meat,
                    productDescription = "Free range bacon",
                    productionDate = new DateTime(2025, 5, 4, 0, 0, 0, 0),
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 18,
                    productName = "Beef steaks",
                    productCategory = ProductCategory.Meat,
                    productDescription = "Free range beef",
                    productionDate = new DateTime(2025, 5, 5, 0, 0, 0, 0),
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 19,
                    productName = "Rye Flour",
                    productCategory = ProductCategory.Grains,
                    productDescription = "finley ground rye flour",
                    productionDate = new DateTime(2025, 5, 10, 0, 0, 0, 0),
                    farmerId = 3
                },
                new ProductModel
                {
                    productID = 20,
                    productName = "Wheat Flour",
                    productCategory = ProductCategory.Grains,
                    productDescription = "finley ground wheat flour",
                    productionDate = new DateTime(2025, 5, 8, 0, 0, 0, 0),
                    farmerId = 4
                }
                , new ProductModel
                {
                    productID = 21,
                    productName = "Oats",
                    productCategory = ProductCategory.Grains,
                    productDescription = "finley ground oats",
                    productionDate = new DateTime(2025, 5, 14, 0, 0, 0, 0),
                    farmerId = 4
                },
                new ProductModel
                {
                    productID = 22,
                    productName = "Pumkin seeds",
                    productCategory = ProductCategory.Seeds,
                    productDescription = "Raw pumkin seeds",
                    productionDate = new DateTime(2025, 5, 13, 0, 0, 0, 0),
                    farmerId = 2
                },
                new ProductModel
                {
                    productID = 23,
                    productName = "Sunflower seeds",
                    productCategory = ProductCategory.Seeds,
                    productDescription = "Raw sunflower seeds",
                    productionDate = new DateTime(2025, 5, 3, 0, 0, 0, 0),
                    farmerId = 3
                }
            );
        }
    }
}
