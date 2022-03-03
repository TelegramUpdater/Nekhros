using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using TelegramUpdater;
using TelegramUpdater.Hosting;

namespace Nekhros
{
    internal class PollingUpdateWriter : UpdateWriterServiceAbs
    {
        public PollingUpdateWriter(IUpdater updater) : base(updater)
        {
        }

        public override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation(
                "Getting updates from my manual writer using Polling extension."
            );

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = UpdaterOptions.AllowedUpdates,
                ThrowPendingUpdates = UpdaterOptions.FlushUpdatesQueue
            };

            try
            {
                await BotClient.ReceiveAsync(
                    HandleUpdateAsync,
                    HandleErrorAsync,
                    receiverOptions,
                    stoppingToken
                );
            }
            catch (OperationCanceledException)
            {
                // Ignore.
            }
        }

        async Task HandleUpdateAsync(ITelegramBotClient _,
                                     Update update,
                                     CancellationToken cancellationToken)
            => await EnqueueUpdateAsync(update, cancellationToken);

        Task HandleErrorAsync(ITelegramBotClient _,
                              Exception exception,
                              CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                Updater.Logger.LogError(exception: apiRequestException,
                                        message: "Error in MyManualWriter");
            }
            return Task.CompletedTask;
        }
    }
}
