using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;


namespace MyFirstBot
{
    
    class Program
    {
        const string TOKEN = "706641504:AAEPcejX9kI-Xkq_e25gdcJ0VCfIu9O0uI8"; //@TstRmnBot
        static void Main()
        {
            while(true)
            {
                try
                {
                    GetMessages().Wait();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error:" + ex);
                }
            }
        }
        static async Task GetMessages()
        {
            TelegramBotClient bot = new TelegramBotClient(TOKEN);
            int offset = 0;
            int timeout = 0;
            try
            {
                await bot.SetWebhookAsync("");
                while(true)
                {
                    var updates = await bot.GetUpdatesAsync(offset, timeout);
                    foreach(var update in updates)
                    {
                        var message = update.Message;
                        //if(message.Text == "MyFirstBot")
                        //{
                        //    Console.WriteLine("Получено сообщение");
                        //    await bot.SendTextMessageAsync(message.Chat.Id, "Привет создатель, я твой бот");
                        //}
                        switch (message.Text)
                        {
                            case "привет":
                                await bot.SendTextMessageAsync(message.Chat.Id, "привет");
                                break;
                            case "как дела":
                                await bot.SendTextMessageAsync(message.Chat.Id, "Хорошо");
                                break;
                            
                        offset = update.Id+1;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex);
            }
        }
    }
}
