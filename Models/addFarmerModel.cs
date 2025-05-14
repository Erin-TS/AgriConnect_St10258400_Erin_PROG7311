//this model is used to add a farmer to the database
//tt contains the properties that are required to create a new farmer there is data annotations to validate the input
//this model is not stored in the database, it is used to pass the data from the view to the controller . the controller then takes this data ans assigns it to another model with all properties like the randome generated password

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
    public class addFarmerModel
    {
        //--------Properties--------//
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
