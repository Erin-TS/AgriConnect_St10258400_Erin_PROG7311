//this is the interface for the user repository
//it has the methods that the user repository class must implement

/*RefrenceLinks:
 *https://www.youtube.com/watch?v=8fFBWmbUaIg
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs
 *https://tom-collings.medium.com/controller-service-repository-16e29a4684e5
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs
 *https://www.youtube.com/watch?v=-LAeEQSfOQk
 *https://stackoverflow.com/questions/10616131/repository-pattern-why-exactly-do-we-need-interfaces
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
*/

//------Imports------//
using AgriConnect_St10258400_Erin_PROG7311.Models;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    //---------Interface---------//
    public interface IUserRepository
    {
        //--------Methods--------//
        Task<EmployeeModel> GetEmployeeByEmail(string email); //gets an employee by their email
        Task<FarmerModel> GetFarmerByEmail(string email);//gets a farmer by their email
        Task AddEmployeeAsync(EmployeeModel employee);//adds a new employee to the database
    }
}
