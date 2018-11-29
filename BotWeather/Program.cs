using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BotWeather
{
    class Program
    {
        private static void Main(string[] args)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Izhevsk&units=metric&appid=0d78fe19f22f690f09853f8d609911c6";

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            };

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            Console.WriteLine("Температура в {0} : {1} Градусов Цельсия", weatherResponse.Name, weatherResponse.Main.Temp);

            Console.ReadLine();
        }
    }
}
