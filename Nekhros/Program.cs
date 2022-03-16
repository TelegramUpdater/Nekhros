using Nekhros;
using TelegramUpdater.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSystemd()
    .ConfigureServices((context, services) =>
    {
        var nekhrosToken = context.Configuration["NekhrosToken"];
        var tephrosToken = context.Configuration["TephrosToken"];

        if (nekhrosToken == null)
            throw new Exception("Woooah where is your Nekhros token?");

        if (tephrosToken == null)
            throw new Exception("Woooah where is your Tephros token?");

        services.AddHttpClient("tephrosClient")
            .AddTypedClient(httpClient =>
                new TephrosClient(tephrosToken));

        services.AddTelegramUpdater<PollingUpdateWriter>(nekhrosToken, default,
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
