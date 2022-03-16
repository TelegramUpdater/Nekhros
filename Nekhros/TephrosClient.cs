namespace Nekhros;

internal sealed class TephrosClient : Telegram.Bot.TelegramBotClient
{
    private readonly Random _random = new();

    public TephrosClient(string token, HttpClient? httpClient = null, string? baseUrl = null)
        : base(token, httpClient, baseUrl)
    {
    }

    internal bool ShellTephrosAnswer
    {
        get
        {
            var chance = _random.NextDouble();
            return chance >= 0.0 && chance <= 0.3;
        }
    }
}
