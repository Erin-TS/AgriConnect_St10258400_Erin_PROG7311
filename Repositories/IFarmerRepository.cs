using AgriConnect_St10258400_Erin_PROG7311.Models;

namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    public interface IFarmerRepository
    {
        Task addProductAsync(ProductModel product);
        Task<ProductModel> GetProductByNameAsync(string productName);
        Task<FarmerModel> GetFarmerByEmailAsync(string email);
    }
}
