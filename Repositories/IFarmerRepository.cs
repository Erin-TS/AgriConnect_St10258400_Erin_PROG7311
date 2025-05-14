//this is the interface for the FarmerRepository class
//it has the methods that the FarmerRepository class must implement.

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
using AgriConnect_St10258400_Erin_PROG7311.Models;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    //---------Interface---------//
    public interface IFarmerRepository
    {
        //--------Methods--------//
        Task addProductAsync(ProductModel product);//adds a new product to the database
        Task<ProductModel> GetProductByNameAsync(string productName);//gets a product by its name
        Task<FarmerModel> GetFarmerByEmailAsync(string email);//gets a farmer by their email
        Task<List<ProductModel>> GetAllProductsByFarmerAsync(int farmerId);//gets all products by a farmer
    }
}
