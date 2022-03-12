using Nekhros;
using TelegramUpdater.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSystemd()
    .ConfigureServices((context, services) =>
    {
        var botToken = "5146786055:AAG1Jxm6ISmNWWvcgE6hb0GT8c5myr7tyGE";

        if (botToken == null)
            throw new Exception("Woooah where is your bot token?");

        services.AddTelegramUpdater<PollingUpdateWriter>(botToken, default,
            builder => builder
                .AddDefaultExceptionHandler()
                .AutoCollectScopedHandlers());

        services.AddHostedService<ConfigureUpdater>();

        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
    })
    .Build();

await host.RunAsync();
