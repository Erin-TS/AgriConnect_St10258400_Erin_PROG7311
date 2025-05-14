//this is the model for the employee table in the database
//it contains all the properties that are needed to create an employee
//it also contains data annotations for validation and to specify the primary key

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
using System.ComponentModel.DataAnnotations.Schema;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    //--------Class--------//
    public class EmployeeModel
    {
        //--------Properties--------//
        [Key]
        public int employeeId { get; set; } //Primary key

      
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string employeeFirstName { get; set; }//First Name


        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(70, ErrorMessage = "Last Name cannot be longer than 70 characters")]
        public string employeeLastName { get; set; }//Last Name

        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Please enter a valid employee number")]//Employee number must be 10 digits AND only numbers
        [Required(ErrorMessage = "Employee number is required")] //Employee number is required
        public string employeeNumber { get; set; }//Employee number


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string employeeEmail { get; set; }//Email


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character. Password must be a minimun of 8 characters")] //UPERCASE, lowercase, number, special character, MIN LENGTH 8
        public string employeePasswordHash { get; set; }//Password



        [Required(ErrorMessage = "Passwords do not match!")]
        [NotMapped]
        [Compare("employeePasswordHash", ErrorMessage = "Passwords do not match!")]
        public string employeePasswordConfirm { get; set; }//Confirm Password


        [Required]
        public string employeeRole = "Employee";  // Employee

    }
}
