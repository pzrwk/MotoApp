using MotoApp.Components.CsvReader;
using MotoApp.Data;

namespace MotoApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly MotoAppDbContext _motoAppDbContext;

    public App(ICsvReader csvReader, MotoAppDbContext motoAppDbContext)
    {
        _csvReader = csvReader;
        _motoAppDbContext = motoAppDbContext;
        _motoAppDbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
    }
}