using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Net;

namespace BotWeather
{
    class Program
    {
        static TelegramBotClient Bot;

        static void Main(string[] args)
        {
            var httpProxy = new WebProxy(Address: "HSI-KBW-109-192-091-198.hsi6.kabel-badenwuerttemberg.de:53701") { };
            Bot = new TelegramBotClient("727563345:AAF-KfCs3m5ndYzia2ECTCEGf-AH9WuGsMQ", httpProxy);

            Bot.OnMessage += BotOnMessageReceived; //для получения сообщений от пользователя

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message; //сообщение от пользователя
            var a = new API();
            //string P = a.Api;
            //string S = " ";
            a.Api();
            string name = $"{message.From.FirstName} {message.From.LastName}"; //имя пользователя
            Console.WriteLine($"{name} отправил сообщение {message.Text}");
            Console.WriteLine(a.S);
            switch(message.Text)
            {
                case "/start":
                    string text =
@"Cписок команд:
/start - запуск бота
/inline - вывод меню 
/pogoda";
                    await Bot.SendTextMessageAsync(message.From.Id, text); //чат 
                    break;
                
                case "/pogoda":
                    
                    await Bot.SendTextMessageAsync(message.From.Id, a.S);
                    break;
                default:
                    break;


            }

        }
    }
}
