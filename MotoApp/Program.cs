using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();







// using MotoApp.Data;
// using MotoApp.Entities;
// using MotoApp.Repositories;
// using MotoApp.Repositories.Extensions;



// var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
// employeeRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
//
// void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
// {
//     Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
// }
//
// AddEmployees(employeeRepository);
// WriteAllToConsole(employeeRepository);
//
// static void EmployeeAdded(Employee item)
// {
//     Console.WriteLine($"{item.FirstName} added.");
// }
//
// static void AddEmployees(IRepository<Employee> repository)
// {
//
//     //var businessPartners = new[]
//     //{
//     //    new BusinessPartner { },
//     //    new BusinessPartner { },
//     //    new BusinessPartner { }
//     //};
//
//     var employees = new[]
//     {
//         new Employee { FirstName = "Adam" },
//         new Employee { FirstName = "Piotr" },
//         new Employee { FirstName = "Zuzanna" }
//     };
//
//     //AddBatch(employeeRepository, employees);    // T = Employee 
//     //AddBatch(businessPartnerRepository, businessPartners);    // T = BusinessPartner 
//
//     repository.AddBatch(employees);
// }
//
// static void WriteAllToConsole(IReadRepository<IEntity> repository)
// {
//     var items = repository.GetAll();
//     foreach (var item in items)
//     {
//         Console.WriteLine(item);
//     }
// }