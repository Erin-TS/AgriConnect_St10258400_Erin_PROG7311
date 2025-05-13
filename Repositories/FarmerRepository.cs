using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect_St10258400_Erin_PROG7311.Repositories
{
    public class FarmerRepository: IFarmerRepository
    {
        private readonly AppDbContext _context;

        public FarmerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<FarmerModel> GetFarmerByEmailAsync(string email)
        {
            return await _context.Farmer.FirstOrDefaultAsync(f => f.farmerEmail == email);
        }

        public async Task<ProductModel> GetProductByNameAsync(string productName)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.productName == productName);
        }
        public async Task addProductAsync(ProductModel product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductModel>> GetAllProductsByFarmerAsync(int farmerId)
        {
            return await _context.Product.Where(p => p.farmerId == farmerId).ToListAsync();
        }
    }
}
