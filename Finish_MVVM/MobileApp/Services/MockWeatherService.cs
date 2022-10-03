using MobileApp.Models;

namespace MobileApp.Services;

class MockWeatherService : IWeatherService
{
    public async Task<List<Weather>> GetWeathersAsync()
    {
        var weathers = new List<Weather>
        {
            new Weather
            {
                Date = new DateTime(2021,11,1),
                Summary = "Rainy",
                Temperature = 20
            },
            new Weather
            {
                Date = new DateTime(2021,11,2),
                Summary = "Cloudy",
                Temperature = 25
            },
            new Weather
            {
                Date = new DateTime(2021,11,3),
                Summary = "Sunny",
                Temperature = 30
            }
        };

        return weathers;
    }
}
