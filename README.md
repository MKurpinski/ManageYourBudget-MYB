# Manage Your Budget

Manage Your Budget is a simple MVC application to help people to manage their finances by evidencing all expenditures and presenting some statistics. There is a possibility to sign in with Facebook and Google.
It was written as a learning project.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development.

### Prerequisites

What things you need to install

```
.NET SDK
Visual Studio 2017
SQL Server
```

### Installing

A step by step series of examples that tell you have to get a development env running

1. Clone the repository or download as ZIP file
2. Open solution in Visual Studio
3. Restore Nuget Packages
4. Open Package Manager Console and type 'Update-Database' to create database
5. Open web.config in project ManageYourBudget and swap the three stars with your AppId and Client secret obtained from Facebook and Google
6. Click F5 to run the application
7. Open your default browser and type adress: [https://localhost:44357/](https://localhost:44357/)

## Demo

### Main screen

### Categories of expenditures

### Statistics


## Deployment

Application is hosted with [Microsoft Azure](https://azure.microsoft.com)

## Built With

* [ASP.NET MVC](https://www.asp.net/mvc) - The web framework used
* [Entity Framework](https://docs.microsoft.com/en-us/ef/) - ORM
* [Automapper](http://automapper.org/) - Mapping
* [Autofac](https://autofac.org/) - DI container
* [Jquery](https://jquery.com/) - Javascript framework
* [Bootstrap](https://getbootstrap.com/) - CSS framework

## Authors

* **Michał Kurpiński**
## License

This project is licensed under the MIT License
