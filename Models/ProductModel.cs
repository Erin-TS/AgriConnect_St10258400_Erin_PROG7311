using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public enum ProductCategory
    {
        Fruits,
        Vegetables,
        Grains,
        Dairy,
        Meat,
        Poultry,
        Fish,
        Eggs,
        Honey,
        Nuts,
        Seeds,
        Herbs
    }

    public class ProductModel
    {
        [Key]
        public int productID { get; set; }//primary Key


        [Required(ErrorMessage = "Product Name is required")]
        public string productName { get; set; }//Product name


        [Required(ErrorMessage = "Product Category is required")]
        public ProductCategory? productCategory { get; set; }//Product category


        [Required(ErrorMessage = "Product descriptioin is required")]
        [StringLength(500, ErrorMessage = "Product description cannot be longer than 500 characters")]
        public string productDescription { get; set; }//Product description


        [Required(ErrorMessage = "Product production date is required")]
        [DataType(DataType.Date)]
        public DateTime productionDate { get; set; }//Product production date

      

        public int farmerId { get; set; } //Foreign Key from FarmerModel


        // Navigation property - doesn't create column, C# property that lets you directly access the related entity in your code
        [ForeignKey("farmerId")]
        public virtual FarmerModel? farmer { get; set; } //Navigation property to FarmerModel
        //? allow for nullable to say that it wont be set by the form
        //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

    }
}
