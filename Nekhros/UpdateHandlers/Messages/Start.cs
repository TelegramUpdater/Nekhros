using Microsoft.Extensions.Localization;
using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [Command("start", "Start me.", 0), Private]
    internal sealed class Start : MessageHandler
    {
        private readonly IStringLocalizer<Start> _localizer;

        public Start(IStringLocalizer<Start> localizer)
        {
            _localizer = localizer;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            await cntr.ResponseAsync(
                _localizer.GetString("StartMessage", cntr.Sender()!.FirstName),
                disableWebpagePreview: true);
        }
    }
}
