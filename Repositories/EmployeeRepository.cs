//This is a repository class that implements the IEmployeeRepository interface
//the repsitory class is responsible for handling data access logic related to employees and farmers
//It uses Entity Framework Core to interact with the database

/*RefrenceLinks:
 *https://www.youtube.com/watch?v=8fFBWmbUaIg
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs
 *https://tom-collings.medium.com/controller-service-repository-16e29a4684e5
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs
 *https://www.youtube.com/watch?v=-LAeEQSfOQk
 *https://stackoverflow.com/questions/10616131/repository-pattern-why-exactly-do-we-need-interfaces
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
*/

//------Imports------//
using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.EntityFrameworkCore;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    //---------Class---------// 
    public class EmployeeRepository : IEmployeeRepository
    {
        //--------Attributes--------//
        private readonly AppDbContext _context; //attribute to hold the database context

        //--------Constructor--------//
        //This constructor initializes the _context attribute with the provided AppDbContext instance.
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        //--------Methods--------//
        //This method adds a new farmer to the database and saves the changes asynchronously
        public async Task addFarmersAsync(FarmerModel farmer)
        {
          await _context.Farmer.AddAsync(farmer);
            await _context.SaveChangesAsync();
        }

        //This method gets a farmer from the database by their email address asynchronously
        public async Task<FarmerModel> getFarmerByEmailAsync(string email)
        {
            return await _context.Farmer.FirstOrDefaultAsync(f => f.farmerEmail == email);
        }

        //This method gets a list of all farmers from the database asynchronously
        public async Task<List<FarmerModel>> getallFarmersListAsync()
        {
            return await _context.Farmer.ToListAsync();
        }

        //This method gets a list of all products from the database asynchronously
        public async Task<List<ProductModel>> getProductsListAsync()
        {
            return await _context.Product.ToListAsync();
        }
    }
}
