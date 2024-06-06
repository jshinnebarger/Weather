using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Weather.Data.Models;

namespace Weather.Data.Services
{

    public class WeatherService
    {
        private HttpClient httpClient;
        private const string APP_ID = "<<YOUR APP ID>>";
        private const string CITY_NAME_URL_PREFIX = "geo/1.0/direct?q=";
        private const string ZIPCODE_URL_PREFIX = "geo/1.0/zip?zip=";
        private const string LAT_LON_URL_PREFIX = "data/2.5/weather?lat=";

        public WeatherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CurrentWeather> GetCurrentWeatherByCityName(string cityName, string state, string cityCountryCode)
        {
            var response = await httpClient.GetAsync(
                CITY_NAME_URL_PREFIX
                + cityName + ","
                + state + ","
                + cityCountryCode + "&limit=1"
                + APP_ID
            );

            List<CityResponse> cityResponses = await JsonSerializer.DeserializeAsync<List<CityResponse>>(response.Content.ReadAsStream());

            return await GetCurrentWeatherByLatLon(cityResponses[0].Lat, cityResponses[0].Lon);
        }

        public async Task<CurrentWeather> GetCurrentWeatherByZipcode(string zipcode, string zipCountryCode)
        {
            var response = await httpClient.GetAsync(
                ZIPCODE_URL_PREFIX
                + zipcode + ","
                + zipCountryCode
                + APP_ID
            );
            
            ZipResponse zipResponse = await JsonSerializer.DeserializeAsync<ZipResponse>(response.Content.ReadAsStream());

            return await GetCurrentWeatherByLatLon(zipResponse.Lat, zipResponse.Lon);
        }

        public async Task<CurrentWeather> GetCurrentWeatherByLatLon(double latitude, double longitude)
        {
            var latLonResponse = await httpClient.GetAsync(
                LAT_LON_URL_PREFIX
                + latitude + "&lon="
                + longitude
                + APP_ID
            );

            return await JsonSerializer.DeserializeAsync<CurrentWeather>(latLonResponse.Content.ReadAsStream());
        }
    }
}