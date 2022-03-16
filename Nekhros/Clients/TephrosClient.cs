namespace Nekhros.Clients;

internal sealed class TephrosClient : Telegram.Bot.TelegramBotClient
{
    public TephrosClient(string token, HttpClient? httpClient = null, string? baseUrl = null)
        : base(token, httpClient, baseUrl)
    {
    }
}
