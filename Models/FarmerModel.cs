using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public class FarmerModel
    {
        [Key]
        public int farmerId { get; set; }//primary Key 
   

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string farmerFirstName { get; set; }//First Name


        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(70, ErrorMessage = "Last Name cannot be longer than 70 characters")]
        public string farmerLastName { get; set; }//Last Name



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string farmerEmail { get; set; }//Email


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character. Password must be a minimun of 8 characters")] //UPERCASE, lowercase, number, special character, MIN LENGTH 8
        public string farmerPasswordHash { get; set; }//Password


        [Required]
        public string farmerRole = "Farmer";  // Farmer

        [Required(ErrorMessage = "Farmer Location is required")]
        public string farmerLocation { get; set; }//Farmer location

        public virtual ICollection<ProductModel> FarmerProducts { get; set; } = new List<ProductModel>(); //Navigation property to ProductModel
        //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

    }
}
