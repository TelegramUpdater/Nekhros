using Nekhros;
using TelegramUpdater.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var botToken = context.Configuration.GetSection("BotToken").Get<string>();

        if (botToken == null)
            throw new Exception("Woooah where is your bot token?");

        services.AddTelegramUpdater<PollingUpdateWriter>(botToken, default,
            builder => builder
                .AddDefaultExceptionHandler()
                .AutoCollectScopedHandlers());

        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
    })
    .Build();

await host.RunAsync();
