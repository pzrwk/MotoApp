using MotoApp;
using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var itemAdded = new ItemAdded<Employee>(EmployeeAdded);

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), itemAdded);

AddEmployees(employeeRepository);
WriteAllToConsole(employeeRepository);

static void EmployeeAdded(object item)
{
    var employee = (Employee)item;
    Console.WriteLine($"{employee.FirstName} added.");
}

static void AddEmployees(IRepository<Employee> repository)
{

    //var businessPartners = new[]
    //{
    //    new BusinessPartner { },
    //    new BusinessPartner { },
    //    new BusinessPartner { }
    //};

    var employees = new[]
    {
        new Employee { FirstName = "Adam" },
        new Employee { FirstName = "Piotr" },
        new Employee { FirstName = "Zuzanna" }
    };

    //AddBatch(employeeRepository, employees);    // T = Employee 
    //AddBatch(businessPartnerRepository, businessPartners);    // T = BusinessPartner 

    repository.AddBatch(employees);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}