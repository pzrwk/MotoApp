﻿using MotoApp;
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);

static void AddEmployees(IRepository<BusinessPartner> businessPartnerRepository)
{

    var businessPartners = new[]
    {
        new BusinessPartner { },
        new BusinessPartner { },
        new BusinessPartner { }
    };

    //var employees = new[]
    //{
    //    new Employee { FirstName = "Adam" },
    //    new Employee { FirstName = "Piotr" },
    //    new Employee { FirstName = "Zuzanna" }
    //};

    //AddBatch(employeeRepository, employees);    // T = Employee 
    //AddBatch(businessPartnerRepository, businessPartners);    // T = BusinessPartner 

    businessPartnerRepository.AddBatch(businessPartners);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}