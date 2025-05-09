using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    public class EmployeeModel
    {
        [Key]
        public int employeeId { get; set; } //Primary key

        [Required]
        public int userId { get; set; } // Foreign key property - creates column in DB

        [ForeignKey("userId")]
        public virtual UserModel user { get; set; } // Navigation property - doesn't create column, C# property that lets you directly access the related entity in your code
                                                    //virtual is lazy loading - only loaded when they are needed, rather than all at once when the page initially loads

        [Required]
        [StringLength(10)]
        public string employeeNumber { get; set; }//Employee number

        [Required]
        [StringLength(50, ErrorMessage = "First Employee type cannot be longer than 50 characters")]
        public string employeeType { get; set; }//Employee type
    }
}
