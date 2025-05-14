//this class is used to manage the employee service layer and implements the IEmployeeService interface
//hass methods to add farmers and retrieve lists of farmers and products.

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
    public class EmployeeService: IEmployeeService
    {
        //--------declarations--------//
        private readonly IEmployeeRepository _employeeRepository;//this is used to access the employee repository
        private readonly IPasswordHasher<FarmerModel> _farPasswordHasher; //this is used to hash the password for the farmer model


        //--------Constructor--------//
        //this constructor is used to initialize the employee repository and the password hasher
        public EmployeeService(IEmployeeRepository employeeRepository,IPasswordHasher<FarmerModel> passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _farPasswordHasher = passwordHasher;
        }

        //--------Methods--------//
        //this method is used to add a farmer to the database it returns a bool indicating if the farmer was added successfully and a string containing the password that was automatically generated
        public async Task<(bool Success, string farmerPass)> addFarmersAsync(FarmerModel farmerProfile)
        {
            // Check if the farmer already exists in the database
            var farmerExists = await _employeeRepository.getFarmerByEmailAsync(farmerProfile.farmerEmail);

            // If the farmer already exists, return false and an error message
            if (farmerExists != null)
            {
                return (false, "Farmer already exists with the provided email");
            }

            //generate a random password

            //initializing the valid characters for the password
            const string vaildCharsLower = "abcdefghijklmnopqrstuvwxyz";//valid characters for lower case letters
            const string validCharsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";//valid characters for upper case letters
            const string validCharsNums ="1234567890";//valid characters for numbers
            const string validCharsSpecial = "!@#$%^&*-?";//valid characters for special characters
            const string vaildChars = vaildCharsLower + validCharsUpper + validCharsNums + validCharsSpecial;//valid characters for the password combined

            Random random = new Random();//random number generator
            int passwordLength = 12; //length of the password
            char[] passwordChars = new char[passwordLength];////array to store the password characters

            // Ensure the password contains at least one character from each category
            passwordChars[0] = vaildCharsLower[random.Next(vaildCharsLower.Length)];//add a random lower case letter to the password
            passwordChars[1] = validCharsUpper[random.Next(validCharsUpper.Length)];//add a random upper case letter to the password
            passwordChars[2] = validCharsNums[random.Next(validCharsNums.Length)];//add a random number to the password
            passwordChars[3] = validCharsSpecial[random.Next(validCharsSpecial.Length)];//add a random special character to the password

            // Fill the rest of the password with random characters from the valid characters
            for (int i = 4; i < passwordLength; i++)
            {
                passwordChars[i] = vaildChars[random.Next(vaildChars.Length)];//add a random character to the password
            }

            string password = new string(passwordChars);//create a string from the password characters

            farmerProfile.farmerPassword = password; // Store the password in the model for the view 

            // Hash the password
            farmerProfile.farmerPasswordHash = _farPasswordHasher.HashPassword(farmerProfile, password); 

            farmerProfile.farmerPasswordHash= farmerProfile.farmerPasswordHash ?? "";//if the password hash is null set it to an empty string

            // try to add the farmer to the database
            try
            {
                await _employeeRepository.addFarmersAsync(farmerProfile);//add the farmer to the database
                return (true, password);//return true and the password
            }
            catch (Exception ex)
            {
                return (false, ex.Message);//return false and the error message
            }
        }


        //this method  gets all the farmers from the database and returns a list of farmers
        public async Task<List<FarmerModel>> getallFarmersListAsync()
        {
            return await _employeeRepository.getallFarmersListAsync();
        }

        //this method gets all the products from the database and returns a list of products
        public async Task<List<ProductModel>> getProductsListAsync()
        {
            return await _employeeRepository.getProductsListAsync();
        }
    }
}
