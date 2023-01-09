using Microsoft.Extensions.Logging;
using MoveToRegionException.Models;

namespace MoveToRegionException.Services;

public class DataService
{
    private readonly ILogger<DataService> _logger;

    public DataService(ILogger<DataService> logger)
	{
        _logger = logger;
    }

    public IEnumerable<City> GetCities()
    {
        List<City> cities = new();
        cities.Add(new City() { Name = "Vienna", Latitude = 48.208176, Longitude = 16.373819 });
        cities.Add(new City() { Name = "Paris", Latitude = 48.856613, Longitude = 2.352222 });
        cities.Add(new City() { Name = "London", Latitude = 51.507351, Longitude = -0.127758 });
        cities.Add(new City() { Name = "Rome", Latitude = 41.902782, Longitude = 12.496365 });
        cities.Add(new City() { Name = "New York", Latitude = 40.712776, Longitude = -74.005974 });
        cities.Add(new City() { Name = "Tokyo", Latitude = 35.810004, Longitude = 139.763695 });
        return cities;
    }
}

