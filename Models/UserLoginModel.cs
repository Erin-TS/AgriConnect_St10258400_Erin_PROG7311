//this is the model for the user login page.It is not stored in the database. It is used to pass the data from the view to the controller to compare what is in the database with what the user entered.
/*Refrencelinks:
 *https://learn.microsoft.com/en-us/ef/core/modeling/
 *https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio
 */

//--------Namespace--------//
namespace AgriConnect_St10258400_Erin_PROG7311.Models
{
    //--------Class--------//
    public class UserLoginModel
    {
        //--------Properties--------//
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
