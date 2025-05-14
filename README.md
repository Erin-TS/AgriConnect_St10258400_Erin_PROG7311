# AgriConnect_St10258400_Erin_PROG7311

---

## Table of contents
1. [GithubLink](#Github-link)
2. [Project Overview](#Project-overview)
3. [Features](#Features)
4. [Technologies](#Technologies)
5. [How to run and install](#How-to-run-and-install)
6. [Seeded data](#Seeded-data)
7. [How to use the system](#How-to-use-the-system)
8. [Refrences](#Refrences)

---

## Github link
[GitHub-Repo-Link](https://github.com/Erin-TS/AgriConnect_St10258400_Erin_PROG7311.git)

---

## Project overview
#### Name - ***AgriConnect***
#### Purpose - To bridge the gap between the agricultural sector and green energy Technology.
#### Description - Allows for Employees to create thier accounts and create farmers  and view all product. Allows for farmers to add and view thier products.

---

## Features
- Role based Authentication system allowing only logged in user with the role of "Farmer" or "Employee" to access certian pages to complete certian tasks. this is done via sessions.
- Employees can create thier own accounts if they have thier employee number.
- Employees can Login to thier accounts.
- Only Employees can add farmers to the sytem and then they must provide the login details to that farmer.
- Employees can view a list of all farmers to provide login details to the farmer.
- Employees can filter a list of all products in the system by date range, farmer or category.
- Farmers can login to thier existing accounts.
- Farmers can add products to thier profiles and view all thier products.
- User input validation in forms.

---


## Technologies

- Razor Views (ASP.NET Core MVC) and css for UI and UX
- Programing lanugage : C#
- Architecture and Design patterns: MVC with Servie and Repository
- SQL Server using Entity Framework Core for the database
- ASP.NET Core Session to manage logged in user

---

## How to run and install
1. Clone the repository
   there are two options
   - run the following command in the terminal:
       ```bash
       git clone https://github.com/Erin-TS/AgriConnect_St10258400_Erin_PROG7311.git
       cd AgriConnect_St10258400_Erin_PROG7311


    #####                       OR
    - open the repository link , click the green button that says **"<>Code"**
    - clone repository

2. Ensure that you install the following NuGet packages
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools
   - Microsoft.EntityFrameworkCore

   <img width="376" alt="image" src="https://github.com/user-attachments/assets/2ed0a0ec-3e48-466c-99b1-67a3df089e7e" />


3. Check the connection string in the `appsettings.json` file. Check that the connection string uses local sever and database.
   ```bash
   {
      "ConnectionStrings": {
          "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=AgriConnectDB;Trusted_Connection=True;"
      },
      "Logging": {
          "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
          }
      },
      "AllowedHosts": "*"
   }

5. Add the migration
   In Visual Studio:
   - Go to the **Tools > NugGet Package manager > NuGet package manager console
   - In the console run the following commands:
   ```
   Add-Migration InitalCreate
   Update-database
   
7. Now you may run the project
   In visual studio you will see a green right pointing arrow with https click that and the project will run

   <img width="146" alt="image" src="https://github.com/user-attachments/assets/68256ea4-f613-4a0e-86a0-5f73e6494722" />


---

## Seeded data
Here are the users that have been seeded into the database:
### Farmers:
- Jack Mcdonald(email:j.m@gmail.com, Password:Pass1234!)
- Penny Leaf(email:p.l@gmail.com, Password:Pass1234!)
- Max Verstappen(email:m.v@gmail.com, Password:Pass1234!)
- Lilly Brown(email:l.b@gmail.com, Password:Pass1234!)

### Empoloyees
- Erin Steenveld(Email:e.s@gmail.com, Password:Abcd1234!)
- Clive Frankland(Email:c.f@gmail.com, Password:Abcd1234@)

### Products
There are 23 products in the system
- Potatoes
- Carrots
- Radish
- Chicken
- Brown Eggs
- Apples
- Bananas
- Grapes
- Peaches
- Parsely
- Rosemary
- Thyme
- Jersey Milk
- Goats Milk
- Brie Cheese
- White eggs free range
- Bacon
- Beef steaks
- Rye Flour
- Wheat Flour
- Oats
- Pumkin seeds
- Sunflower seeds

---

## How to use the system
### Employee
- Register a new account or login to an existing account
- add new farmers
- View a list of all farmers details int the system
- View a list of all product in the sytem this list can be filtered by product category , date and by farmer

### Farmer
- Login to existing account that was created by a employee
- Add products to your profile
- view a list of products you have ever added to your profile

If farmer tries to access an employees page or visa verse or if a logged out user tryies to access any page that is not login or register the unauthrised access page will display with a button to redirect the user to the home page. This is donte through the use of sessions.

---

## Refrences
ASP.NET MVC, 2023. Drop Table using migration Command in Entity Framework Core. [online] Available at: https://www.youtube.com/watch?v=wE8cW_Fn0mU [Accessed 8 May 2025].
<br />Brijesh Jalan, 2010. Generating Random Passwords with ASP. NET and C#. [online] Available at: https://www.c-sharpcorner.com/UploadFile/brij_mcn/generating-random-passwords-with-asp-net-and-C-Sharp/ [Accessed 11 May 2025].
<br />Collings, T., 2021. Controller-Service-Repository. [online] Available at: https://tom-collings.medium.com/controller-service-repository-16e29a4684e5 [Accessed 11 May 2025].
<br />Complete C# Tutorial, 2015. ASP.NET MVC 5 – HTTPGET and HTTPPOST Method with Example. [online] Available at: https://www.completecsharptutorial.com/asp-net-mvc5/asp-net-mvc-5-httpget-and-httppost-method-with-example.php [Accessed 12 May 2025].
<br />dotnet-bot, 2025. DbContext Class, System.Data.Entity. [online] Available at: https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0 [Accessed 10 May 2025].
<br />Getachew, S., 2024. Best Practices for Using Entity Framework Core in ASP.NET Core Applications with .NET 8. [online] Available at: https://medium.com/@solomongetachew112/best-practices-for-using-entity-framework-core-in-asp-net-core-applications-with-net-8-9e4d796c02ac [Accessed 10 May 2025].
<br />Kalla, M., 2024. Session in ASP.NET Core MVC .NET 8. [online] Available at: https://www.c-sharpcorner.com/article/session-in-asp-net-core-mvc-net-8/ [Accessed 13 May 2025].
<br />Learn Smart Coding, 2024. EP3: Setting Up .NET Core API Project & EF Core Integration | Scaffolding & Dependency Injection. [online] Available at: https://www.youtube.com/watch?v=CATF49Frgrw [Accessed 9 May 2025].
<br />Microsoft, 2021a. Lazy Loading of Related Data - EF Core. [online] Available at: https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy [Accessed 8 May 2025].
<br />Microsoft, 2021b. Overview of Entity Framework Core - EF Core. [online] Available at: https://learn.microsoft.com/en-us/ef/core/ [Accessed 6 May 2025].
<br />Microsoft, 2022a. Compute/compare hash values by using C# - C#. [online] Available at: https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/compute-hash-values [Accessed 8 May 2025].
<br />Microsoft, 2022b. Data Seeding - EF Core. [online] Available at: https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding [Accessed 8 May 2025].
<br />Microsoft, 2023a. Creating and Configuring a Model - EF Core. [online] Available at: https://learn.microsoft.com/en-us/ef/core/modeling/ [Accessed 14 May 2025].
<br />Microsoft, 2023b. Migrations Overview - EF Core. [online] Available at: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli [Accessed 11 May 2025].
<br />Microsoft, 2024a. Introduction to Razor Pages in ASP.NET Core. [online] Available at: https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-9.0&tabs=visual-studio [Accessed 9 May 2025].
<br />Microsoft, 2024b. Model validation in ASP.NET Core MVC. [online] Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-9.0 [Accessed 7 May 2025].
<br />Microsoft, 2024c. Razor syntax reference for ASP.NET Core. [online] Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-9.0 [Accessed 9 May 2025].
<br />Microsoft, 2024d. Session in ASP.NET Core. [online] Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0 [Accessed 9 May 2025].
<br />Microsoft, 2025a. Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application, 9 of 10. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application [Accessed 7 May 2025].
<br />Microsoft, 2025b. Relationships, navigation properties, and foreign keys - EF6. [online] Available at: https://learn.microsoft.com/en-us/ef/ef6/fundamentals/relationships [Accessed 10 May 2025].
<br />Milan Jovanović, 2023. Why You Don’t Need To Abstract Away EF Core With Clean Architecture. [online] Available at: https://www.youtube.com/watch?v=IGVRVO7KTss [Accessed 10 May 2025].
<br />Nano ASP Boilerplate, 2022. Using Dependency Injection, Interfaces, & Services in ASP.NET Core - 10 Minute Guide + GitHub Sample. [online] Available at: https://www.youtube.com/watch?v=Vxq8PXvYb6I [Accessed 10 May 2025].
<br />O’Didily, M., 2023. How to Make a Password Generator in C#. [online] Available at: https://www.youtube.com/watch?v=9mRSFRvI1H8 [Accessed 12 May 2025].
<br />Patel, R., 2024. Dependency Injection and Services in ASP.NET Core: A Comprehensive Guide. [online] Available at: https://medium.com/@ravipatel.it/dependency-injection-and-services-in-asp-net-core-a-comprehensive-guide-dd69858c1eab [Accessed 10 May 2025].
<br />Pickett, W., 2024a. Part 4, add a model to an ASP.NET Core MVC app. [online] Available at: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio [Accessed 9 May 2025].
<br />Pickett, W., 2024b. Tutorial: Create a web API with ASP.NET Core. [online] Available at: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio [Accessed 8 May 2025].
<br />Pragimtech, 2020. ASP.NET Core REST API DbContext. [online] Available at: https://www.pragimtech.com/blog/blazor/asp.net-core-rest-api-dbcontext/ [Accessed 10 May 2025].
<br />Tayel, mohamed, 2024. EFCore Tutorial P4:Cleaning Up `OnModelCreating`. [online] Available at: https://dev.to/moh_moh701/efcore-tutorial-p5cleaning-up-ef-cores-onmodelcreating-45fg [Accessed 11 May 2025].
<br />Teddy Smith, 2022. ASP.NET Core Web API - 5. Repository Pattern & Dependency Injection Explained. [online] Available at: https://www.youtube.com/watch?v=-LAeEQSfOQk [Accessed 14 May 2025].
<br />Thachankary, G.J., 2019. Entity Framework Core - Code First Approach With Fluent API. [online] Available at: https://www.c-sharpcorner.com/article/entity-framework-core-code-first-approach-with-fluent-api/ [Accessed 12 May 2025].
<br />TutorialsEU - C#, 2023. How to use the Repository Design Pattern in C# and ASP.NET. [online] Available at: https://www.youtube.com/watch?v=8fFBWmbUaIg [Accessed 12 May 2025].
<br />UI Bakery, 2025. Password regex C# | UI Bakery. [online] Available at: https://uibakery.io/regex-library/password-regex-csharp [Accessed 7 May 2025].
<br />W3Schools, 2019. CSS Media Queries. [online] Available at: https://www.w3schools.com/css/css3_mediaqueries.asp [Accessed 8 May 2025].
<br />W3Schools, 2022. CSS Tutorial. [online] Available at: https://www.w3schools.com/css/default.asp [Accessed 10 May 2025].
<br />W3Schools, 2025a. ASP.NET Razor Markup. [online] Available at: https://www.w3schools.com/ASp/razor_intro.asp [Accessed 9 May 2025].
<br />W3Schools, 2025b. C# Interface. [online] www.w3schools.com. Available at: https://www.w3schools.com/cs/cs_interface.php [Accessed 6 May 2025].
<br />Walther, S., 2022a. ASP.NET MVC Controller Overview, C#. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed 10 May 2025].
<br />Walther, S., 2022b. Validating with a Service Layer, C#. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs [Accessed 7 May 2025].
<br />Zero To Mastery, 2024. CSS 101 Crash Course: Beginner’s Guide to Web Design, 8 HOURS!. [online] Available at: https://www.youtube.com/watch?v=impqUbJdkgM [Accessed 10 May 2025].
<br />ZZZ Projects, 2025a. Entity Framework Core Tutorials. [online] Available at: https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx [Accessed 7 May 2025].
<br />ZZZ Projects, 2025b. Fluent API Configuration. [online] Available at: https://www.learnentityframeworkcore.com/configuration/fluent-api [Accessed 10 May 2025].


