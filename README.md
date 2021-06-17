# Introduction 
BabaFunke.DataAccess is a NuGet Package that defines a generic repository framework for CRUD (Create, Read, Update, Delete) operations. It also includes an additional Archive feature for disabling an item instead of outright deletion. The package's sole purpose is to eliminate the need for repetitive definition of interfaces to handle basic CRUD operations. It was inspired by the need to save some time on my CRUD related client-server projects. See background info below for more.

BabaFunke.DataAccessDemo is an Asp.Net Core Web Api project to demonstrate the use of the NuGet Package. It's a simple product management system for creating, updating, archiving, reading and deleting products for a fictitious creator.

BabaFunke.DataAccessDemoTest is a Unit Test project for the demo project above. It includes tests for the Product controller.

# Getting Started
1.	Installation process
To simply install the NuGet package, navigate to [BabaFunke.DataAccess](https://www.nuget.org/packages/BabaFunke.DataAccess/). If you're using Visual Studio, open the NuGet Package Manager and search using the keyword Babafunke.DataAccess or run the command line Install-Package BabaFunke.DataAccess -Version 1.0.4 in the Package Manager Console.

# Build and Test
Clone this git repo to access the projects.

# Background
For more on the project's background, read my post [Creating more Daddy time with NuGet Packages](https://daddycreates.com/creating-more-daddy-time-with-nuget-packages-part-i/)
