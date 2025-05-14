//this is the model for the Farmer table in the database. It contains the properties for the Farmer table and the validation attributes for each property
//The validation attributes are used to validate the data entered by the user in the form
/*Refrencelinks:
 *https://learn.microsoft.com/en-us/ef/core/modeling/
 *https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio
 *https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy
 *https://learn.microsoft.com/en-us/ef/core/
 *https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx
 *https://learn.microsoft.com/en-us/ef/ef6/fundamentals/relationships
 */

//--------Imports--------//
using System.ComponentModel.DataAnnotations;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    //--------Class--------//
    public class FarmerModel
    {
        //--------Properties--------//
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

        public string farmerPassword { get; set; } //Password for the view 

        [Required]
        public string farmerRole { get; set; } = "Farmer";  // Farmer

        [Required(ErrorMessage = "Farmer Location is required")]
        public string farmerLocation { get; set; }//Farmer location

        public virtual ICollection<ProductModel> FarmerProducts { get; set; } = new List<ProductModel>(); //Navigation property to ProductModel
        //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

    }
}
