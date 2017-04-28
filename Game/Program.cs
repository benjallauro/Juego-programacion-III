using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Net;
//using Newtonsoft.Json.Linq;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Weather theWeather = new Weather();
            Menu theMenu = new Menu(theWeather.getWeatherText());
            Game theGame = new Game();
            /*
            string weather = "default";
            try
            {
                WebRequest weatherRequest = WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22Buenos%20Aires%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                WebResponse weatherResponse = weatherRequest.GetResponse();
                Stream weatherStream = weatherResponse.GetResponseStream();
                StreamReader weatherSR = new StreamReader(weatherStream);
                JObject weatherData = JObject.Parse(weatherSR.ReadToEnd());
                weather = (string)weatherData["query"]["results"]["channel"]["item"]["condition"]["text"];
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(weather);
            }
            catch(Exception cantFind)
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("We could not find the weather.");
            }
            */
            while (theMenu.MoveAndChoose() == true)
            {
                theGame.Run(theWeather.getWeatherText());
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}

/*
{
 "query": {
  "count": 1,
  "created": "2017-04-25T15:10:15Z",
  "lang": "es-ES",
  "results": {
   "channel": {
    "item": {
     "condition": {
      "text": "Cloudy"
     }
    }
   }
  }
 }
}
*/