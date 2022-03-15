using MotoApp.Entities;

namespace MotoApp.DataProviders;

public interface ICarsProvider
{
    // select
    List<string> GetUniqueCarColors();

    decimal GetMinimumPriceOfAllCars();

    List<Car> GetSpecificColumns();
    string AnonymousClass();

    // order by
    List<Car> OrderByName();
    List<Car> OrderByNameDescending();
    List<Car> OrderByColorAndName();
    List<Car> OrderByColorAndNameDesc();

    // where
    List<Car> WhereStartsWith(string prefix);
    List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);
    List<Car> WhereColorIs(string color);

}