//this is the repository class for the Farmer model
//It contains methods to interact with the database
//the repository pattern is used to separate the data access logic from the business logic

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
    public class FarmerRepository: IFarmerRepository
    {
        //--------Attributes--------//
        private readonly AppDbContext _context;//attribute to hold the database context

        //--------Constructor--------//
        public FarmerRepository(AppDbContext context)
        {
            _context = context;
        }

        //--------Methods--------//
        //this method gets a farmer from the database by their email address asynchronously
        public async Task<FarmerModel> GetFarmerByEmailAsync(string email)
        {
            return await _context.Farmer.FirstOrDefaultAsync(f => f.farmerEmail == email);
        }

        //this method gets a product from the database by its name asynchronously
        public async Task<ProductModel> GetProductByNameAsync(string productName)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.productName == productName);
        }

        //this method adds a new product to the database and saves the changes asynchronously
        public async Task addProductAsync(ProductModel product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        //this method gets a list of all products from the database asynchronously
        public async Task<List<ProductModel>> GetAllProductsByFarmerAsync(int farmerId)
        {
            return await _context.Product.Where(p => p.farmerId == farmerId).ToListAsync();
        }
    }
}
