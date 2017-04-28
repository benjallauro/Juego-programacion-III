using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Game
{
    class Weather
    {
        private string weatherText = "default";
        public Weather()
        {
            try
            {
                WebRequest weatherRequest = WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22Buenos%20Aires%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                WebResponse weatherResponse = weatherRequest.GetResponse();
                Stream weatherStream = weatherResponse.GetResponseStream();
                StreamReader weatherSR = new StreamReader(weatherStream);
                JObject weatherData = JObject.Parse(weatherSR.ReadToEnd());
                weatherText = (string)weatherData["query"]["results"]["channel"]["item"]["condition"]["text"];
                Console.SetCursorPosition(0, 1);
            }
            catch (Exception cantFind)
            {
                Console.SetCursorPosition(0, 1);
                weatherText = "We could not find the weather.";
            }
        }
        public string getWeatherText()
        {
            return weatherText;
        }
    }
}
