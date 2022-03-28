namespace TelegramWebhook.Services;

public class TelegramService : ITelegramService
{
    private readonly IBotClient _botClient;

    public TelegramService(IBotClient botClient)
    {
        _botClient = botClient;
    }
    public async Task Send(string myMessage, long chatId)
    {
        SendText request = new(chatId: chatId, text: myMessage);

        var response = await _botClient.HandleAsync(request);

        if (response.Ok)
        {
            var message = response.Result;

            Console.WriteLine(message.Id);
            Console.WriteLine(message.Text);
            Console.WriteLine(message.Date.ToString("G"));
        }
        else
        {
            var failure = response.Failure;

            Console.WriteLine(failure.Description);
        }
    }
}