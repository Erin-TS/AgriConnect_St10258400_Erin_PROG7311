using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Repositories;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<(bool sucess, string productName)> addProductAsync(ProductModel product)
        {
            var productExists = await _farmerRepository.GetProductByNameAsync(product.productName);
            if (productExists != null)
            {
                return (false, "Product already exists with the provided name");
            }

            try
            {
                await _farmerRepository.addProductAsync(product);
                return (true, product.productName);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        public async Task<List<ProductModel>> GetAllProductsByFarmerAsync(int farmerId)
        {
            var products = await _farmerRepository.GetAllProductsByFarmerAsync(farmerId);
            if (products == null || products.Count == 0)
            {
                return null;
            }
            return products;
        }

        public async Task<FarmerModel> GetFarmerByEmailAsync(string email)
        {
            var farmer = await _farmerRepository.GetFarmerByEmailAsync(email);
            if (farmer == null)
            {
                return null;
            }
            return farmer;
        }

    }
}
