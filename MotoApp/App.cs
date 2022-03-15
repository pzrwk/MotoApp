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

        var groups = cars
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
        }
    }
}