using TelegramUpdater;

namespace Nekhros
{
    internal sealed class ConfigureUpdater : IHostedService
    {
        private readonly IUpdater _updater;
        private readonly ILogger<ConfigureUpdater> _logger;

        public ConfigureUpdater(IUpdater updater, ILogger<ConfigureUpdater> logger)
        {
            _updater = updater;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var me = await _updater.GetMeAsync();
            _logger.LogInformation("Connected to the bot {username}, {id}",
                me.Username, me.Id);

            await _updater.SetCommandsAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _updater.EmergencyCancel();
            return Task.CompletedTask;
        }
    }
}
