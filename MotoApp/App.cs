using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(
        IRepository<Employee> employeesRepository,
        IRepository<Car> carsRepository,
        ICarsProvider carsProvider)
    {
        _employeesRepository = employeesRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }

    public void Run()
    {
        Console.WriteLine("I'm here in Run() method");

        var employees = new[]
        {
            new Employee {FirstName = "Adam"},
            new Employee {FirstName = "Piotr"},
            new Employee {FirstName = "Zuzanna"}
        };

        foreach (var employee in employees) _employeesRepository.Add(employee);

        _employeesRepository.Save();

        //reading

        var items = _employeesRepository.GetAll();
        foreach (var item in items) Console.WriteLine(item);

        //cars
        var cars = GenerateSampleCars();
        foreach (var car in cars) _carsRepository.Add(car);

        foreach(var car in _carsProvider.GetUniqueCarColors()) Console.WriteLine(car); 
    }

    public static List<Car> GenerateSampleCars()
    {
        return new List<Car>
        {
            new()
            {
                Id = 680,
                Name = "Car 1",
                Color = "Black",
                StandardCost = 699.09M,
                ListPrice = 1349.60M,
                Type = "44"
            },
            new()
            {
                Id = 681,
                Name = "Car 2",
                Color = "Red",
                StandardCost = 659.09M,
                ListPrice = 1249.60M,
                Type = "42"
            },
            new()
            {
                Id = 682,
                Name = "Car 3",
                Color = "Yellow",
                StandardCost = 659.09M,
                ListPrice = 1149.60M,
                Type = "41"
            },
            new()
            {
                Id = 683,
                Name = "Car 4",
                Color = "Black",
                StandardCost = 699.09M,
                ListPrice = 1349.60M,
                Type = "42"
            },
            new()
            {
                Id = 684,
                Name = "Car 5",
                Color = "Green",
                StandardCost = 599.09M,
                ListPrice = 1039.60M,
                Type = "41"
            }
        };
    }
}