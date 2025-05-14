//this is the interface for the FarmerService class
//it states the methods that the FarmerService class must implement

/*RefrenceLinks:
 *https://www.youtube.com/watch?v=8fFBWmbUaIg
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs
 *https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/compute-hash-values
 *https://www.youtube.com/watch?v=Vxq8PXvYb6I
 *https://www.youtube.com/watch?v=IGVRVO7KTss
 *https://www.youtube.com/watch?v=CATF49Frgrw
 *https://www.w3schools.com/cs/cs_interface.php
 *https://medium.com/@ravipatel.it/dependency-injection-and-services-in-asp-net-core-a-comprehensive-guide-dd69858c1eab
 *https://medium.com/@solomongetachew112/best-practices-for-using-entity-framework-core-in-asp-net-core-applications-with-net-8-9e4d796c02ac
 *https://ghidyon.hashnode.dev/creating-worker-service-entity-framework-core-in-net
*/

//--------Imports--------//
using AgriConnect_St10258400_Erin_PROG7311.Models;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    //--------Interface--------//
    public interface IFarmerService
    {
        Task<(bool sucess,string productName)> addProductAsync(ProductModel product);//this method is used to add a product to the database it returns a bool indicating if the product was added successfully and a string containing the name of the product that was added
        Task<FarmerModel> GetFarmerByEmailAsync(string email);//this method is used to get a farmer by their email it returns a FarmerModel object
        Task<List<ProductModel>> GetAllProductsByFarmerAsync(int farmerId);//this method is used to get all the products by the farmer id it returns a list of ProductModel objects
    }
}
