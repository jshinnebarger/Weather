# Introduction
The following is a test project created for a job interview.  The purpose of this project is to have the user supply location details and retrieve the current weather as a response.

## Setup
- Download preferred IDE: I used [Visual Studio Code](https://code.visualstudio.com/download)
    - Extensions
        - C# Dev Kit (installs C# and .NET Install Tool extensions as dependencies)
- Download [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

## How To Use
- Clone the project.
- Navigate to `Data\Services\WeatherService.cs` and update the `APP_ID` const to be `&appId=<<YOUR ID HERE>>`.
- Open a terminal and run the command `dotnet run`
- Open a browser and navigate to `localhost:5194`
- Click on any of the radio buttons to choose the method with which you'd like to provide your location details.  Only one will be active at a time, so no need to worry about clearing out previous fields as the request will only consider the values from the currently checked radio button.  Once done, click the `Check Results` button to retrieve the current weather.

## Sample request / response
- Submitting a request with city name = `Ozark`, state = `MO`, and country code = `US` should provide the following response:
- ```{"coord":{"lon":-93.2053,"lat":37.0207},"weather":[{"id":801,"main":"Clouds","description":"few clouds","icon":"02d"}],"base":"stations","main":{"temp":295.43,"feels_like":295.54,"temp_min":292.94,"temp_max":300.38,"pressure":1013,"humidity":70,"sea_level":0,"grnd_level":0},"visibility":10000,"wind":{"speed":1.34,"deg":302,"gust":0},"rain":null,"clouds":{"all":21},"dt":1717692198,"sys":{"type":2,"id":2004550,"country":"US","sunrise":1717671201,"sunset":1717723809},"timezone":-18000,"id":4402245,"name":"Ozark","cod":200}```

- Submitting a request with zip code = `65721` and country code = `US` should provide the following response:
- ```{"coord":{"lon":-93.2022,"lat":37.0169},"weather":[{"id":801,"main":"Clouds","description":"few clouds","icon":"02d"}],"base":"stations","main":{"temp":295.4,"feels_like":295.51,"temp_min":293.48,"temp_max":300.36,"pressure":1013,"humidity":70,"sea_level":0,"grnd_level":0},"visibility":10000,"wind":{"speed":1.34,"deg":302,"gust":0},"rain":null,"clouds":{"all":21},"dt":1717692302,"sys":{"type":2,"id":2004550,"country":"US","sunrise":1717671201,"sunset":1717723808},"timezone":-18000,"id":4402245,"name":"Ozark","cod":200}```

- You can then use the lat / lon values from either of the above to test out the lat / lon request and the responses should match.