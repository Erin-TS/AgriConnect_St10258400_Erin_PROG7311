//this is the main entry point for the application. It sets up the ASP.NET Core application, including services, middleware, and routing.
/*Refrence links
 *https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0
 *https://www.c-sharpcorner.com/article/session-in-asp-net-core-mvc-net-8/
 */

//------Imports------//
using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Repositories;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//-------Namespace------//
namespace AgriConnect_St10258400_Erin_PROG7311
{
    //------Program Class------//
    public class Program
    {
        //------Main Method------//
        //this is the starting point of the application
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ------Setup services------//
            // Add services to the container
            builder.Services.AddControllersWithViews();//this adds the MVC services to the container
            // Add session services
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout to 30 minutes
                options.Cookie.HttpOnly = true; // Set the cookie to be HTTP-only
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });

            builder.Services.AddHttpContextAccessor();//this adds the HttpContextAccessor service to the container
            builder.Services.AddScoped<IUserService, UserService>();//this adds the IUserService service to the container
            builder.Services.AddScoped<IUserRepository, UserRepository>();//this adds the IUserRepository service to the container
            builder.Services.AddScoped<IPasswordHasher<EmployeeModel>, PasswordHasher<EmployeeModel>>();//this adds the PasswordHasher service to the container for employee
            builder.Services.AddScoped<IPasswordHasher<FarmerModel>, PasswordHasher<FarmerModel>>();//this adds the PasswordHasher service to the container for farmer
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();//this adds the IEmployeeService service to the container
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//this adds the IEmployeeRepository service to the container
            builder.Services.AddScoped<IFarmerService, FarmerService>();//this adds the IFarmerService service to the container
            builder.Services.AddScoped<IFarmerRepository, FarmerRepository>();//this adds the IFarmerRepository service to the container

            // Add Entity Framework Core and SQL Server
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();//this builds the application

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();//this enables session state in the application
            app.UseHttpsRedirection();//this redirects HTTP requests to HTTPS
            app.UseStaticFiles();//this enables static files in the application
            app.UseRouting();//this enables routing in the application
            app.UseAuthentication();//this enables authentication in the application
            app.UseAuthorization();//this enables authorization in the application

            // Configure the application to use session state
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();//this runs the application
        }
    }
}
