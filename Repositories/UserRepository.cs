//tjis is a repository class for user to handle validationan login and register
//it implements the IUserRepository interface
//it is responsible for handling data access logic related to users

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
using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.EntityFrameworkCore;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    //---------Class---------//
    public class UserRepository : IUserRepository
    {
        //--------Attributes--------//
        private readonly AppDbContext _context;//attribute to hold the database context

        //--------Constructor--------//
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        //--------Methods--------//
        //This method gets an employee from the database by their email address asynchronously
        public async Task<EmployeeModel> GetEmployeeByEmail(string email)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.employeeEmail == email);
        }

        //This method gets a farmer from the database by their email address asynchronously
        public async Task<FarmerModel> GetFarmerByEmail(string email)
        {
            return await _context.Farmer.FirstOrDefaultAsync(f => f.farmerEmail == email);
        }

        //this method adds a new employee to the database and saves the changes asynchronously
        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
    }
}
