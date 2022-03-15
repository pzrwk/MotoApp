using System.Xml.Linq;
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
        var records = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");

        //var manufacturers = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var document = new XDocument();
        var cars = new XElement("Cars", records.Select(x => 
            new XElement("Car",
                new XAttribute("Name", x.Name),
                new XAttribute("Combined", x.Combined),
                new XAttribute("Manufacturer", x.Manufacturer))
        ));

        document.Add(cars);
        document.Save("fuel.xml");
    }
}