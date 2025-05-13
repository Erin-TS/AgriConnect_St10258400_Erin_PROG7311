using AgriConnect_St10258400_Erin_PROG7311.Models;

namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    public interface IEmployeeRepository
    {
        Task addFarmersAsync(FarmerModel farmer);
        Task<FarmerModel> getFarmerByEmailAsync(string email);
        Task<List<FarmerModel>> getallFarmersListAsync();
    }
}
