using AgriConnect_St10258400_Erin_PROG7311.Models;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public interface IUserService
    {
        Task<(bool Success, string Role, string FullName)> ValidateUserLogin(UserLoginModel userLogin);
        Task<(bool Success, string ErrorMsg)> RegisterEmployee(EmployeeModel employee);

    }
}
