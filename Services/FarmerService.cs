//this class is used to implement the farmer service interface and it contains the methods that are used to access the farmer repo
//it contains the methods that are used to add a product to the database, get all the products by the farmer id and get the farmer by email

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
using AgriConnect_St10258400_Erin_PROG7311.Repositories;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    //--------Class--------//
    public class FarmerService : IFarmerService
    {
        //--------declarations--------//
        private readonly IFarmerRepository _farmerRepository;//this is used to access the farmer repository

        //-------Constructor--------//
        //this constructor is used to initialize the farmer repository
        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        //--------Methods--------//
        //this method is used to add a product to the database it returns a bool indicating if the product was added successfully and a string containing the name of the product that was added
        public async Task<(bool sucess, string productName)> addProductAsync(ProductModel product)
        {
            // Check if the product already exists in the database
            var productExists = await _farmerRepository.GetProductByNameAsync(product.productName);
            // If the product already exists, return false and an error message
            if (productExists != null)
            {
                return (false, "Product already exists with the provided name");
            }


            //try to add the product to the database
            try
            {
                await _farmerRepository.addProductAsync(product);//this method is used to add the product to the database
                return (true, product.productName);// return the product name
            }
            catch (Exception ex)
            {
                //if there is an error while adding the product to the database return false and the error message
                return (false, ex.Message);
            }

        }

        //this method is used to get all the products by the farmer id it returns a list of products
        public async Task<List<ProductModel>> GetAllProductsByFarmerAsync(int farmerId)
        {
            var products = await _farmerRepository.GetAllProductsByFarmerAsync(farmerId);//this method is used to get all the products by the farmer id
            // Check if the products list is null or empty
            if (products == null || products.Count == 0)
            {
                return null;// return null if there are no products
            }
            return products;// return the products list
        }

        //this method is used to get the farmer by email it returns a farmer object
        public async Task<FarmerModel> GetFarmerByEmailAsync(string email)
        {
            var farmer = await _farmerRepository.GetFarmerByEmailAsync(email);//this method is used to get the farmer by email
            // Check if the farmer is null
            if (farmer == null)
            {
                return null;// return null if the farmer is not found
            }
            return farmer;// return the farmer object
        }

    }
}
