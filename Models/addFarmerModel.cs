using System.ComponentModel.DataAnnotations;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public class addFarmerModel
    {

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string farmerFirstName { get; set; }//First Name


        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(70, ErrorMessage = "Last Name cannot be longer than 70 characters")]
        public string farmerLastName { get; set; }//Last Name


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string farmerEmail { get; set; }//Email


        [Required(ErrorMessage = "Farmer Location is required")]
        public string farmerLocation { get; set; }//Farmer location
    }
}
