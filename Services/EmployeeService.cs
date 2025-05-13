using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Repositories;
using Microsoft.AspNetCore.Identity;

namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordHasher<FarmerModel> _farPasswordHasher;

        public EmployeeService(IEmployeeRepository employeeRepository,IPasswordHasher<FarmerModel> passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _farPasswordHasher = passwordHasher;
        }
        public async Task<(bool Success, string farmerPass)> addFarmersAsync(FarmerModel farmerProfile)
        {
            var farmerExists = await _employeeRepository.getFarmerByEmailAsync(farmerProfile.farmerEmail);
            if (farmerExists != null)
            {
                return (false, "Farmer already exists with the provided email");
            }

            //generate a random password
            const string vaildCharsLower = "abcdefghijklmnopqrstuvwxyz";
            const string validCharsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string validCharsNums ="1234567890";
            const string validCharsSpecial = "!@#$%^&*-?";
            const string vaildChars = vaildCharsLower + validCharsUpper + validCharsNums + validCharsSpecial;

            Random random = new Random();
            int passwordLength = 12;
            char[] passwordChars = new char[passwordLength];
            passwordChars[0] = vaildCharsLower[random.Next(vaildCharsLower.Length)];
            passwordChars[1] = validCharsUpper[random.Next(validCharsUpper.Length)];
            passwordChars[2] = validCharsNums[random.Next(validCharsNums.Length)];
            passwordChars[3] = validCharsSpecial[random.Next(validCharsSpecial.Length)];
            for (int i = 4; i < passwordLength; i++)
            {
                passwordChars[i] = vaildChars[random.Next(vaildChars.Length)];
            }
            string password = new string(passwordChars);

            // Hash the password
            farmerProfile.farmerPasswordHash = _farPasswordHasher.HashPassword(farmerProfile, password); 

            farmerProfile.farmerPasswordHash= farmerProfile.farmerPasswordHash ?? "";

            try
            {
                await _employeeRepository.addFarmersAsync(farmerProfile);
                return (true, password);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
