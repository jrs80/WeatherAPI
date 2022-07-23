using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter city: ");
            string city=Console.ReadLine();
            
            var client = new HttpClient();
           
            var weatherAPI = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid=9251bac4b2ed01295a575311b97b1b30";

            var response=client.GetStringAsync(weatherAPI).Result;


            var info = JObject.Parse(response).GetValue("main").ToString();
            var currentTemp = JObject.Parse(info).GetValue("temp").ToString();
            var minTemp = JObject.Parse(info).GetValue("temp_min").ToString();
            var maxTemp = JObject.Parse(info).GetValue("temp_max").ToString();
            var humidity = JObject.Parse(info).GetValue("humidity").ToString();

            Console.WriteLine($"The current temperature (in deg F) in {city} is {currentTemp}.\n" +
            $"The low today is {minTemp} and the high today is {maxTemp}, while the humidity is {humidity} percent.");

            Console.ReadKey(true);
        }
    }
}
