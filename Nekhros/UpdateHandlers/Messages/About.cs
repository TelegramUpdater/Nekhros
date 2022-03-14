using Microsoft.Extensions.Localization;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [
        Command("about", "Read more about me.", 1,
            botCommandScopeType: BotCommandScopeType.AllPrivateChats),
        Private
    ]
    internal sealed class About : MessageHandler
    {
        private readonly IStringLocalizer<About> _localizer;

        public About(IStringLocalizer<About> localizer)
        {
            _localizer = localizer;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            await cntr.ResponseAsync(
                _localizer.GetString("AboutText"), parseMode: ParseMode.Markdown);
        }
    }
}
