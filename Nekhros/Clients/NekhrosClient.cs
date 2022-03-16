namespace Nekhros.Clients;

internal sealed class NekhrosClient : Telegram.Bot.TelegramBotClient
{
    public NekhrosClient(string token, HttpClient? httpClient = null, string? baseUrl = null)
        : base(token, httpClient, baseUrl)
    {
    }
}
