﻿using System.ComponentModel.DataAnnotations;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public class UserModel
    {
        [Key]
        public int userId { get; set; }//primary Key

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string userFirstName { get; set; }//First Name


        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(70, ErrorMessage = "Last Name cannot be longer than 70 characters")]
        public string userLastName { get; set; }//Last Name


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string userEmail { get; set; }//Email


        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character. Password must be a minimun of 8 characters")] //UPERCASE, lowercase, number, special character, MIN LENGTH 8
        public string userPasswordHash { get; set; }//Password


        [Required]
        public string userRole { get; set; } // Farmer or Employee


        //table relationships
        // can be an employee or farmer
        // Navigation property - doesn't create column, C# property that lets you directly access the related entity in your code
        //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

        public virtual EmployeeModel Employee { get; set; }
        public virtual FarmerModel Farmer { get; set; }
    }
}
