using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeModel> GetEmployeeByEmail(string email)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.employeeEmail == email);
        }

        public async Task<FarmerModel> GetFarmerByEmail(string email)
        {
            return await _context.Farmer.FirstOrDefaultAsync(f => f.farmerEmail == email);
        }

        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
    }
}
