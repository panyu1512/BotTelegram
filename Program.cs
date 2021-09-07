using System; 
using Telegram.Bot;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotTelegram
{
    class Program
    {
        
        static ITelegramBotClient _botClient;

        static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("1919716135:AAEdSxVsdy3wpRKYPdk1_s_UuFXdP0Y9UXc");
            var me = _botClient.GetMeAsync().Result;
            Console.WriteLine($"Hola mi id es: {me.Id} y mi nombre es: {me.FirstName}"); 

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            _botClient.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

            Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _                                       => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }  

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {

                if(update.Message.Text.Contains("Luis?") || update.Message.Text.Contains("Luis")){
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id, 
                        text:   "Luis el verduras"
                    );
                }
                else if(update.Message.Text.Contains("vlonk") || update.Message.Text.Contains("Vlonj")){
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id, 
                        text:   "Vlonnk es la peor Jett del mundo y un platilla en el lol"
                    );
                }
                else if(update.Message.Text.Contains("Greck") || update.Message.Text.Contains("Adri")){
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id, 
                        text:   "Puro AIM"
                    );
                }
                else if(update.Message.Text.Contains("ach") || update.Message.Text.Contains("Ach")){
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id, 
                        text:   "Quien es apraf?"
                    );
                }
                else if(update.Message.Text.Contains("bruno") || update.Message.Text.Contains("bruno")){
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id, 
                        text:   "Brusi el pingas"
                    );
                }
                else if(update.Message.Text.Contains("Mariano") || update.Message.Text.Contains("carvo")){
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id, 
                        text:   "Isiiiii Isiii"
                    );
                }                                
                var chatId = update.Message.Chat.Id;
                
                Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");
            } 

        }
     

    }
}