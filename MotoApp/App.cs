using MotoApp.Components.CsvReader;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

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
    }
}