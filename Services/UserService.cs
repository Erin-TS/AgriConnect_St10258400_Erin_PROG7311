//this is the user service class that handles user login and registration logic
//it uses the user repository to access the database and the password hasher to hash and verify passwords

/*RefrenceLinks:
 *https://www.youtube.com/watch?v=8fFBWmbUaIg
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs
 *https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/compute-hash-values
 *https://www.youtube.com/watch?v=9mRSFRvI1H8
 *https://stackoverflow.com/questions/54991/generating-random-passwords
 *https://www.c-sharpcorner.com/UploadFile/brij_mcn/generating-random-passwords-with-asp-net-and-C-Sharp/
 *https://www.youtube.com/watch?v=Vxq8PXvYb6I
 *https://www.youtube.com/watch?v=IGVRVO7KTss
 *https://www.youtube.com/watch?v=CATF49Frgrw
 *https://www.w3schools.com/cs/cs_interface.php
 *https://medium.com/@ravipatel.it/dependency-injection-and-services-in-asp-net-core-a-comprehensive-guide-dd69858c1eab
 *https://medium.com/@solomongetachew112/best-practices-for-using-entity-framework-core-in-asp-net-core-applications-with-net-8-9e4d796c02ac
 *https://ghidyon.hashnode.dev/creating-worker-service-entity-framework-core-in-net
*/

//--------Imports--------//
using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Repositories;
using Microsoft.AspNetCore.Identity;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    //--------Class--------//
    public class UserService : IUserService
    {
        //--------declarations--------//
        private readonly IUserRepository _userRepository;//this is used to access the user repository
        private readonly IPasswordHasher<EmployeeModel> _empPasswordHasher;//this is used to hash the password for the employee model
        private readonly IPasswordHasher<FarmerModel> _farPasswordHasher;//this is used to hash the password for the farmer model

        //--------Constructor--------//
        //this constructor is used to initialize the user repository and the password hasher
        public UserService(IUserRepository userRepository, IPasswordHasher<EmployeeModel> employeeHash, IPasswordHasher<FarmerModel> farmerHash)
        {
            _userRepository = userRepository;
            _empPasswordHasher = employeeHash;
            _farPasswordHasher = farmerHash;
        }

        //--------Methods--------//
        //this method is used to validate the user login it returns a bool indicating if the login was successful and a string containing the role of the user and their full name
        public async Task<(bool Success, string Role, string FullName)> ValidateUserLogin(UserLoginModel userLogin)
        {
            var employee = await _userRepository.GetEmployeeByEmail(userLogin.UserEmail);//this method is used to get the employee by email
            // Check if the employee exists
            if (employee != null)
            {
                var passHashEmployee = _empPasswordHasher.VerifyHashedPassword(employee,employee.employeePasswordHash, userLogin.UserPassword);//this method is used to verify the password hash for the employee

                // Check if the password is correct
                if (passHashEmployee == PasswordVerificationResult.Success)
                {
                    return (true, "Employee", $"{employee.employeeFirstName} {employee.employeeLastName}");//return the employee role and full name
                }
            }
            
            //if employee doesnt make entered details check if it is a farmer
            var farmer = await _userRepository.GetFarmerByEmail(userLogin.UserEmail);//this method is used to get the farmer by email

            // Check if the farmer exists
            if (farmer != null)
            {
                var passHashFarmer = _farPasswordHasher.VerifyHashedPassword(farmer, farmer.farmerPasswordHash, userLogin.UserPassword);//this method is used to verify the password hash for the farmer
                // Check if the password is correct
                if (passHashFarmer == PasswordVerificationResult.Success)
                {
                    return (true, "Farmer", $"{farmer.farmerFirstName} {farmer.farmerLastName}");//return the farmer role and full name
                }
            }

            return (false, null, null);//return false if the login was not successful
        }

        //this method is used to register a new employee it returns a bool indicating if the registration was successful and a string containing an error message
        public async Task<(bool Success, string ErrorMsg)> RegisterEmployee(EmployeeModel employee)
        {
            var existingEmployee = await _userRepository.GetEmployeeByEmail(employee.employeeEmail);//this method is used to get the employee by email
            // Check if the employee already exists
            if (existingEmployee != null)
            {
                return (false, "Email already exists.");//return false if the email already exists
            }

            // Hash the password
            var hashedPassword = _empPasswordHasher.HashPassword(employee, employee.employeePasswordHash);//this method is used to hash the password for the employee
            employee.employeePasswordHash = hashedPassword;//store the hashed password in the employee model

            await _userRepository.AddEmployeeAsync(employee);//this method is used to add the employee to the database
            return (true, null);//return true if the registration was successful
        }
    }
}
