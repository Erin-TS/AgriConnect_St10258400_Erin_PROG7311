using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Repositories;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public class FarmerService
    {
        private readonly IFarmerRepository _farmerRepository;

        public FarmerService(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<(bool success, string productName)> addProductAsync(ProductModel product)
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
    }
}
