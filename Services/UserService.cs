using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Repositories;
using Microsoft.AspNetCore.Identity;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<EmployeeModel> _empPasswordHasher;
        private readonly IPasswordHasher<FarmerModel> _farPasswordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<EmployeeModel> employeeHash, IPasswordHasher<FarmerModel> farmerHash)
        {
            _userRepository = userRepository;
            _empPasswordHasher = employeeHash;
            _farPasswordHasher = farmerHash;
        }

        public async Task<(bool Success, string Role, string FullName)> ValidateUserLogin(UserLoginModel userLogin)
        {
            var employee = await _userRepository.GetEmployeeByEmail(userLogin.UserEmail);
            if (employee != null)
            {
                var passHashEmployee = _empPasswordHasher.VerifyHashedPassword(employee,employee.employeePasswordHash, userLogin.UserPassword);

                    if (passHashEmployee == PasswordVerificationResult.Success)
                {
                    return (true, "Employee", $"{employee.employeeFirstName} {employee.employeeLastName}");
                }
            }

            var farmer = await _userRepository.GetFarmerByEmail(userLogin.UserEmail);
            if (farmer != null)
            {
                var passHashFarmer = _farPasswordHasher.VerifyHashedPassword(farmer, farmer.farmerPasswordHash, userLogin.UserPassword);

                    if (passHashFarmer == PasswordVerificationResult.Success)
                {
                    return (true, "Farmer", $"{farmer.farmerFirstName} {farmer.farmerLastName}");
                }
            }

            return (false, null, null);
        }

        public async Task<(bool Success, string ErrorMsg)> RegisterEmployee(EmployeeModel employee)
        {
            var existingEmployee = await _userRepository.GetEmployeeByEmail(employee.employeeEmail);
            if (existingEmployee != null)
            {
                return (false, "Email already exists.");
            }

            // Hash the password
            var hashedPassword = _empPasswordHasher.HashPassword(employee, employee.employeePasswordHash);
            employee.employeePasswordHash = hashedPassword;

            await _userRepository.AddEmployeeAsync(employee);
            return (true, null);
        }
    }
}
