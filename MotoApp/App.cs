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

        /*var groups = cars
            .GroupBy(x => x.Manufacturer)
            .Select(g => new
            {
                Name = g.Key,
                Max = g.Max(c => c.Combined),
                Avg = g.Average(c => c.Combined)
            })
            .OrderBy(x => x.Avg);

        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Name}");
            Console.WriteLine($"\tMax: {group.Max}");
            Console.WriteLine($"\tAverage: {group.Avg}");
        }*/

        var carsInCountry = cars.Join(
                    manufacturers,
                    c => new { c.Manufacturer, c.Year },
                    m => new { Manufacturer = m.Name, m.Year},
                    (car, manufacturer) => new
                    {
                        manufacturer.Country,
                        car.Name,
                        car.Combined
                    })
                .OrderByDescending(x => x.Combined)
                .ThenBy(x => x.Name);

        foreach (var car in carsInCountry)
        {
            Console.WriteLine($"Country: {car.Country}");
            Console.WriteLine($"\tName: {car.Name}");
            Console.WriteLine($"\tCombined: {car.Combined}");
        }
    }
}