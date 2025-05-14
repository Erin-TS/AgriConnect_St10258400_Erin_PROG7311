//this class is the model for the filter view. it is used to filter the products by category, date and farmer.
//it is also used to store the list of farmers for the dropdown list.
//it is used in the ProductController to filter the products and display the filtered products in the view.
//it is also used to store the selected farmer id for the filter.
//it is not created in the database, it is only used in the view.

/*Refrenceslinks
  *https://learn.microsoft.com/en-us/ef/core/modeling/
 *https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio
*/

//--------Imports--------//
using Microsoft.AspNetCore.Mvc.Rendering;

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    //--------Class--------//
    public class ProductFilterModel
    {
        //--------Properties--------//
        //nulls are used to make the properties optional
        public ProductCategory? Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? selectedFarmerId { get; set; }

        
       public List<SelectListItem> Farmers { get; set; }//list of farmers for the dropdown list
        public List<ProductModel> Products { get; set; }//list of products for the view
    }
}
