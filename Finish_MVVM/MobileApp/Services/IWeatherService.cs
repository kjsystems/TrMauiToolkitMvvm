using MobileApp.Models;

namespace MobileApp.Services;
public interface IWeatherService
{
    Task<List<Weather>> GetWeathersAsync();
}