using System.Diagnostics;
using System.Net.Http.Json;
using MobileApp.Models;

namespace MobileApp.Services
{
    class WeatherService : IWeatherService
    {
        static readonly HttpClient _httpClient = new();

        public async Task<List<Weather>> GetWeathersAsync()
        {
            try
            {
                // サイトからデータを取得
                var response = await _httpClient.GetAsync("https://weatherforecastsampleforprism.azurewebsites.net/weatherforecast");

                // レスポンスコード（200 など）を確認
                response.EnsureSuccessStatusCode();

                // レスポンスからコンテンツ（JSON）を取得
                return await response.Content.ReadFromJsonAsync<List<Weather>>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}