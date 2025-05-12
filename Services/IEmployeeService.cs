using AgriConnect_St10258400_Erin_PROG7311.Models;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public interface IEmployeeService
    {
        Task<(bool Success, string farmerPass)> addFarmersAsync(FarmerModel farmerProfile);
    }
}
