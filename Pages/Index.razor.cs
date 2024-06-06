using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Weather.Data.Enums;
using Weather.Data.Models;
using Weather.Data.Services;

namespace Weather.Pages
{
    public partial class Index
    {
        [Inject]
        private WeatherService weatherService { get; set; }

        private string cityName = string.Empty;
        private string state = string.Empty;
        private string cityCountryCode = string.Empty;
        private string zipcode = string.Empty;
        private string zipCountryCode = string.Empty;
        private double latitude = 0;
        private double longitude = 0;
        private string results = string.Empty;
        private Checked CurrentChecked = Checked.CityName;

        private void OnCityNameChecked()
        {
            CurrentChecked = Checked.CityName;
        }

        private void OnZipCodeChecked()
        {
            CurrentChecked = Checked.Zipcode;
        }

        private void OnLatLonChecked()
        {
            CurrentChecked = Checked.LatLon;
        }

        private async void OnViewResults()
        {
            results = "Loading...";

            CurrentWeather currentWeather;
            
            switch (CurrentChecked)
            {
                case Checked.CityName:
                    currentWeather = await weatherService.GetCurrentWeatherByCityName(cityName, state, cityCountryCode);
                    break;
                case Checked.Zipcode:
                    currentWeather = await weatherService.GetCurrentWeatherByZipcode(zipcode, zipCountryCode);
                    break;
                case Checked.LatLon:
                    currentWeather = await weatherService.GetCurrentWeatherByLatLon(latitude, longitude);
                    break;
                default:
                    currentWeather = null;
                    break;
            }

            results = currentWeather == null ? "Uh oh! Something went wrong!" : JsonSerializer.Serialize(currentWeather);

            await InvokeAsync(StateHasChanged);            
        }
    }
}