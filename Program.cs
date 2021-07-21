using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Task_5
{
    class WeatherForecast
    {
        public static string GetTemperatureByCity(string city)
        {
            string temperature;
            using (HttpClient client = new HttpClient())
            {
                string getTemperatureUrl = $"https://goweather.herokuapp.com/weather/{city}";
                var task = client.GetAsync(getTemperatureUrl);
                var jsonString = task.Result.Content.ReadAsStringAsync();

                JObject jsonObject = JObject.Parse(jsonString.Result);
                temperature = jsonObject.SelectToken("$.temperature").ToString();
            }
            return temperature;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string temperatureInKyiv = WeatherForecast.GetTemperatureByCity("Kyiv");
            string temperatureInOdesa = WeatherForecast.GetTemperatureByCity("Odesa");
            Console.WriteLine($"Kyiv: {temperatureInKyiv}");
            Console.WriteLine($"Odesa: {temperatureInOdesa}");
            Console.ReadKey();
        }
    }
}
