using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.ScopedHandlers.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [Command("start"), Private]
    internal sealed class Start : ScopedMessageHandler
    {
        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            await cntr.Response("Started.");
        }
    }
}
