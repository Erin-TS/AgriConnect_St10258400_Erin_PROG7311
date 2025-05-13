using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task addFarmersAsync(FarmerModel farmer)
        {
          await _context.Farmer.AddAsync(farmer);
            await _context.SaveChangesAsync();
        }

        public async Task<FarmerModel> getFarmerByEmailAsync(string email)
        {
            return await _context.Farmer.FirstOrDefaultAsync(f => f.farmerEmail == email);
        }
    }
}
