using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [Command("about", "Read more about me.", 1), Private]
    internal sealed class About : MessageHandler
    {
        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            await cntr.ResponseAsync("This is all about Us!");
        }
    }
}
