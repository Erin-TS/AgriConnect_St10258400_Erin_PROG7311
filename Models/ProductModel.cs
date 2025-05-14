//this is the model for the product table in the database.It is used to stores all the infromation of the product.
/*Refrencelinks:
 *https://learn.microsoft.com/en-us/ef/core/modeling/
 *https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio
 *https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy
 *https://learn.microsoft.com/en-us/ef/core/
 *https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx
 *https://learn.microsoft.com/en-us/ef/ef6/fundamentals/relationships
 */

//-------Imports--------//
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    //--------Enumeration--------//
    //this is the enumeration for the product category. It is used to create set categories for a product.
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

    //--------Class--------//
    public class ProductModel
    {
        //--------Properties--------//
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


        // Navigation property - doesn't create column it is a C# property that lets you directly access the related entity in your code
        [ForeignKey("farmerId")]
        public virtual FarmerModel? farmer { get; set; } //Navigation property to FarmerModel
        //? allow for nullable to say that it wont be set by the form
        //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

    }
}
