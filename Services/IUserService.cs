//this is the interface for the user service
//it states the methods that will be implemented in the UserService class


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

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Services
{
    //--------Interface--------//
    public interface IUserService
    {
        //this method is used to validate the user login it returns a bool indicating if the login was successful and a string containing the role of the user and their full name
        Task<(bool Success, string Role, string FullName)> ValidateUserLogin(UserLoginModel userLogin);

        //this method is used to register a new employee it returns a bool indicating if the registration was successful and a string containing an error message
        Task<(bool Success, string ErrorMsg)> RegisterEmployee(EmployeeModel employee);

    }
}
