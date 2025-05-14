# AgriConnect_St10258400_Erin_PROG7311

---

##Table of contents
1.[GithubLink](#Githublink)
2.[Project Overview](#Project overview)
3.[Features](#Features)
4.[Technologies](#Technologies)
5.[How to run and install](#How to run and install)
6.[Seeded data](#Seeded data)
7.[How to use the system](#How to use the system)
8.[Refrences](#Refrences)

---

##Githublink
[GitHub](https//github.com)

---

##Project overview

#### Name - ***AgriConnect***
### Purpose - To bridge the gap between the agricultural sector and green energy Technology.
### What - Allows for Employees to create thier accounts and create farmers  and view all product. Allows for farmers to add and view thier products.

---

##Features
--Role based Authentication system allowing only logged in user with the role of "Farmer" or "Employee" to access certian pages to complete certian tasks. this is done via sessions.
- Employees can create thier own accounts if they have thier employee number.
- Employees can Login to thier accounts.
- Only Employees can add farmers to the sytem and then they must provide the login details to that farmer.
- Employees can view a list of all farmers to provide login details to the farmer.
- Employees can filter a list of all products in the system by date range, farmer or category.
- Farmers can login to thier existing accounts.
- Farmers can add products to thier profiles and view all thier products.
- User input validation in forms.

---


##Technologies

-Razor Views (ASP.NET Core MVC) and css for UI and UX
-Programing lanugage : C#
-Architecture and Design patterns: MVC with Servie and Repository
-SQL Server using Entity Framework Core for the database
-ASP.NET Core Session to manage logged in user

---

##How to run and install
1. Clone the repository
   either run the following command in the
   ```bash
   git clone
   cd
or 
open the repository link 
click the green button that says "<>Code"
clone repository

2. Ensure that you install the following nuget packages
   -Microsoft.EntityFrameworkCore.SqlServer
   -Microsoft.EntityFrameworkCore.Tools
   -Microsoft.AspNetCore.Session
   -Microsoft.AspNetCore.Identity
   (screenshot)
3.Check the connection string in the 
4. Add the migration
   In visual studion go to the tools table click NugGet Package manager then NuGet package manager console
   in the console run the following commands
   ```
   Add-Migration InitalCreate
   Update-database
6. Now you may run the project
   in visual studio you will see a green right pointing arrow with https click that and the project will run
   (screenshot)

---

##Seeded data
Here are the users that have been seeded into the database:
###Farmers:
-Jack Mcdonald(email:j.m@gmail.com, Password:Pass1234!)
-Penny Leaf(email:p.l@gmail.com, Password:Pass1234!)
-Max Verstappen(email:m.v@gmail.com, Password:Pass1234!)
-Lilly Brown(email:l.b@gmail.com, Password:Pass1234!)

###Empoloyees
-Erin Steenveld(Email:e.s@gmail.com, Password:Abcd1234!)
-Clive Frankland(Email:c.f@gmail.com, Password:Abcd1234@)

###Products
There are 23 products in the system
-Potatoes
-Carrots
-Radish
-Chicken
-Brown Eggs
-Apples
-Bananas
-Grapes
-Peaches
-Parsely
-Rosemary
-Thyme
-Jersey Milk
-Goats Milk
-Brie Cheese
-White eggs free range
-Bacon
-Beef steaks
-Rye Flour
-Wheat Flour
-Oats
-Pumkin seeds
-Sunflower seeds

---

##How to use the system
###Employee
- register a new account or login to an existing account
- add new farmers
- View a list of all farmers details int the system
- View a list of all product in the sytem this list can be filtered by product category , date and by farmer

###Farmer
-Login to existing account that was created by a employee
-Add products to your profile
- view a list of products you have ever added to your profile
RefrenceList

If farmer tries to access an employees page or visa verse or if a logged out user tryies to access any page that is not login or register the unauthrised access page will display with a button to redirect the user to the home page. This is donte through the use of sessions.

---

##Refrences
