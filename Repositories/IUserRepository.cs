using AgriConnect_St10258400_Erin_PROG7311.Models;

namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    public interface IUserRepository
    {
        Task<EmployeeModel> GetEmployeeByEmail(string email);
        Task<FarmerModel> GetFarmerByEmail(string email);
        Task AddEmployeeAsync(EmployeeModel employee);
    }
}
