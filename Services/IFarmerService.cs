using AgriConnect_St10258400_Erin_PROG7311.Models;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public interface IFarmerService
    {
        Task<(bool sucess,string productName)> addProductAsync(ProductModel product);
        Task<FarmerModel> GetFarmerByEmailAsync(string email);
    }
}
