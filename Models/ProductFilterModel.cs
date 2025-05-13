using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public class ProductFilterModel
    {
        public ProductCategory? Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? selectedFarmerId { get; set; }

       public List<SelectListItem> Farmers { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
