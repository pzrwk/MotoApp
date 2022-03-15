using MotoApp.Components.CsvReader;

namespace MotoApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void Run()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

        var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var groups = manufacturers.GroupJoin(
            cars,
            manufacturer => manufacturer.Name,
            car => car.Manufacturer,
            (m, g) => new
            {
                Manufacturer = m,
                Cars = g
            })
            .OrderBy(x => x.Manufacturer.Name);

        foreach (var car in groups)
        {
            Console.WriteLine($"Manufacturer: {car.Manufacturer.Name}");
            Console.WriteLine($"\t Cars: {car.Cars.Count()}");
            Console.WriteLine($"\t Max {car.Cars.Max(x => x.Combined)}");
            Console.WriteLine($"\t Min {car.Cars.Min(x => x.Combined)}");
            Console.WriteLine($"\t Avg {car.Cars.Average(x => x.Combined)}");
            Console.WriteLine();
        }
    }
}