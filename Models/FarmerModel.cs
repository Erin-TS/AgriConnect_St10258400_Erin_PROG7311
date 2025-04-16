using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public class FarmerModel
    {
        [Key]
        public int farmerId { get; set; }//primary Key 

        [Required]
        public int userId { get; set; } // Foreign key property - creates column in DB

        [ForeignKey("userId")]
        public virtual UserModel user { get; set; } // Navigation property - doesn't create column, C# property that lets you directly access the related entity in your code

        [Required(ErrorMessage = "Farmer Location is required")]
        public string farmerLocation { get; set; }//Farmer location

        public virtual ICollection<ProductModel> FarmerProducts { get; set; } = new List<ProductModel>(); //Navigation property to ProductModel
        //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

    }
}
